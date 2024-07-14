using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models;
using static Models.Serializers;
using System.Runtime.Serialization;
using DbLayer;
using System.Diagnostics.Eventing.Reader;
using Microsoft.VisualBasic.Logging;

namespace QUIZproject_server
{
    internal class Q_Server
    {
        private IPAddress host;
        private int port;
        private Socket socket;
        private List<Socket> clientSocket;
        private List<Quiz> mh_questions;
        private List<SQuiz> s_questions;
        private StudentsDbContextFactory factory;
        private byte[] marker = Encoding.UTF8.GetBytes("EndOfFile");
        private string[] args = { "stupid rules", "stupid row"};


        private string message = "";

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnMessageChanged();
            }
        }// повідомлення

        public List<Quiz> Mh_questions { get => mh_questions; set => mh_questions = value; }
        public List<SQuiz> S_questions { get => s_questions; set => s_questions = value; }

        public event EventHandler? MessageChanged;

        protected virtual void OnMessageChanged()
        {
            MessageChanged?.Invoke(this, EventArgs.Empty);
        }


        public Q_Server(IPAddress ip, int port)
        {
            host = ip;
            this.port = port;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Message = "test";
            clientSocket = new List<Socket>();
        }

        public Q_Server(IPAddress ip, int port, List<Quiz> mhq, List<SQuiz> sq, StudentsDbContextFactory _factory)
        {
            host = ip;
            this.port = port;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Message = "test";
            clientSocket = new List<Socket>();
            Mh_questions = mhq;
            S_questions = sq;
            factory = _factory;            
        }

        public void StartServer()
        {
            socket.Bind(new IPEndPoint(host, port));
            socket.Listen(10);
            Message = $"{DateTime.Now.ToLongTimeString()} Server started. Waiting for connections...";
            socket.BeginAccept(AcceptCallbackMethod, null);
        }

        private void AcceptCallbackMethod(IAsyncResult result)
        {
            this.clientSocket.Add(socket.EndAccept(result));
            var clientSocket = socket.EndAccept(result);
            Message = $"{DateTime.Now.ToLongTimeString()} Client {clientSocket.RemoteEndPoint} connected.";

            var state = new StateObject { WorkSocket = clientSocket };
            clientSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallbackMethod, state);

            socket.BeginAccept(AcceptCallbackMethod, null);
        }

        private void ReceiveCallbackMethod(IAsyncResult result)
        {
            var state = (StateObject)result.AsyncState;
            var clientSocket = state.WorkSocket;
            try
            {
                int receivedBytes = clientSocket.EndReceive(result);
                var receivedData = Encoding.UTF8.GetString(state.Buffer, 0, receivedBytes);
                
                // ОБРОБКА ВХІДНИХ ПОВІДОЛМЕНЬ (СЕРВЕР)

                if (receivedBytes > 0)
                {
                    try
                    {
                        // ЛОГІН
                        
                        if (TryDeserializeObject(state.Buffer, receivedBytes, out StudentLogin st) == true)
                        {
                            Message = $"{st.Name} {st.SurName} connected";                            
                            bool ifregistered = CheckIfRegistered(st);
                            if (ifregistered && st.Ifnew)
                            {
                                //MessageBox.Show($"registered new {st.Password} : {st.Email} : {st.Ifnew}");
                                byte[] msg = Encoding.UTF8.GetBytes("AlreadyRegistered");
                                SendTextMessage(clientSocket, msg);
                            }
                            else if (ifregistered && !st.Ifnew)
                            {
                                //MessageBox.Show($"registered !new {st.Password} : {st.Email} : {st.Ifnew}");
                                string loginsuccess = TryLogin(st, clientSocket);
                                
                                byte[] msg = Encoding.UTF8.GetBytes(loginsuccess);

                                SendTextMessage(clientSocket, msg);
                                
                            }
                            else if (!ifregistered && st.Ifnew)
                            {
                                //MessageBox.Show($"!registered new {st.Password} : {st.Email} : {st.Ifnew}");
                                string registerresult = TryRegister(st, clientSocket);
                                byte[] msg = Encoding.UTF8.GetBytes(registerresult);
                                

                                SendTextMessage(clientSocket, msg);
                                
                            }
                            else if (!ifregistered && !st.Ifnew)
                            {
                                //MessageBox.Show($"!registered !new {st.Password} : {st.Email} : {st.Ifnew}");
                                byte[] msg = Encoding.UTF8.GetBytes("LoginUnSuccess");
                                SendTextMessage(clientSocket, msg);
                            }
                        }
                        // ВИБІР ДИСЦИПЛІНИ
                        else if (receivedData == "Musichistory")
                        {
                            Message = $"student - {clientSocket.RemoteEndPoint} requested MusicHistory quiz"; // Адреса клієнта
                            SendData(clientSocket, PrepareDara(Subject.Musichistory));
                        }
                        else if (receivedData == "Solfegio")
                        {
                            Message = $"student - {clientSocket.RemoteEndPoint} requested Solfegio quiz";
                            SendData(clientSocket, PrepareDara(Subject.Solfegio));

                        }
                        // ВІДПОВІДЬ НА ПИТАННЯ
                        else if (TryDeserializeObject(state.Buffer, receivedBytes, out StudentAnswer sta) == true)
                        {
                            Message = $"{sta.Name} {sta.SurName} answered {sta.S_quiz?.Question}";
                        }
                        else if (TryDeserializeObject(state.Buffer, receivedBytes, out ShortAnswer sha) == true)
                        {
                            Message = $"{sha.Email} answered question # {sha.Questionid}";

                        }
                        else Message = $"uknonw type message: {receivedData}";
                    }
                    catch {
                        Message = $"unknown prepare failure";
                    }
                }
                else
                {
                    Message = $"unknown message from {clientSocket.RemoteEndPoint} ";
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }

                // Продовжуємо очікувати нові повідомлення
                clientSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallbackMethod, state);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to receive messages\n{ex.Message}", "Receive Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientSocket?.Shutdown(SocketShutdown.Both);
                clientSocket?.Close();
            }
        }

        private void SendTextMessage(Socket clientSocket, byte[] msg)
        {
            SendData(clientSocket, msg);
            SendData(clientSocket, marker);
        }

        private string TryRegister(StudentLogin st, Socket clientSocket)
        {
            using (var db = factory.CreateDbContext(args))
            {
                try
                {
                    db.Students.Add(st);
                    db.SaveChanges();
                    Message = $"New student {st.Name} {st.SurName} just have registered";                                  
                    ExtractAndSend(st, clientSocket);
                    return "RegisterSuccess";
                }
                catch
                {
                    Message = $"Unsuccesful atempt to register {st.Name} {st.SurName}";
                    return "RegisterUnSuccess";                    
                }
            }
        }

        
        private bool CheckIfRegistered(StudentLogin st)
        {
            
            using (var db = factory.CreateDbContext(args))
                foreach( var student in  db.Students) 
                { 
                    if(st.Email == student.Email)
                        return true;
                }
            return false;
        }

        private string TryLogin(StudentLogin st, Socket clientSocket)
        {

            //MessageBox.Show($"login attempt {st.Email}");
            using (var db = factory.CreateDbContext(args))
                foreach (var student in db.Students)
                {
                    if (st.Email == student.Email
                        && st.Password == student.Password)
                    {
                        SendLogin(student, clientSocket);
                        return "LoginSuccess";
                    }
                }
            return "LoginUnSuccess";
        }

        private void SendLogin(Student student, Socket clientSocket)
        {
            byte[] data = SerializeObject(student);
            SendData(clientSocket, data);
            SendData(clientSocket, marker);
            Message = "Student info sent";
        }

        private void ExtractAndSend(StudentLogin st, Socket clientSocket)
        {
            using (var db = factory.CreateDbContext(args))
                foreach (var student in db.Students)
                {
                    if (st.Email == student.Email
                        && st.Password == student.Password)
                    {
                        SendLogin(student, clientSocket);                        
                    }
                }
        }

        // Метод для відправки даних клієнту

        private byte[] PrepareDara(Subject subj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (subj == Subject.Musichistory)
                {
                    // Serialize Music History quizzes
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Quiz>));
                    serializer.WriteObject(memoryStream, Mh_questions);
                    //Message = $"{Mh_questions.Count} mh_questions are prepared";
                }
                else if (subj == Subject.Solfegio)
                {
                    // Serialize Solfegio quizzes
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<SQuiz>));
                    serializer.WriteObject(memoryStream, S_questions);
                    //Message = $"{S_questions.Count} s_questions are prepared";
                }                
                
                // Add end-of-file marker                
                memoryStream.Write(marker, 0, marker.Length);
                                
                byte[] bytes = memoryStream.ToArray();
                
                return bytes;
            }
        }

        public void SendData(Socket clientSocket, byte[] data)
        {
                        
            try
            {
                clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallbackMethod, clientSocket);
                Message = $"data {data.Length} is sent";
            }
            catch (Exception ex)
            {
                Message = $"Failed to send data\n{ex.Message}";
                clientSocket?.Shutdown(SocketShutdown.Both);
                clientSocket?.Close();
            }
        }

        private void SendCallbackMethod(IAsyncResult result)
        {
            try
            {
                var clientSocket = (Socket)result.AsyncState;
                int bytesSent = clientSocket.EndSend(result);
                Message = $"{DateTime.Now.ToLongTimeString()} Sent {bytesSent} bytes to client {clientSocket.RemoteEndPoint}.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send data\n{ex.Message}", "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal class StateObject
        {
            internal Socket WorkSocket { get; set; }
            internal byte[] Buffer { get; } = new byte[1024];
        }
    }
}
