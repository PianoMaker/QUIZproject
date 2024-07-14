using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Models;
using static Models.Serializers;
using System.Runtime.Serialization;
namespace QUIZ_client_1
{
    public class Q_Client
    {
        private string? message;
        private Socket socket;
        public bool Ifconnected { get; set; }
        public byte[] Bin { get; set; }

       // public List<Quiz> mh_questions { get; set;  } = new ();
//        public List<SQuiz> s_questions { get; set;  } = new ();

        public event EventHandler? MessageChanged;
        public event EventHandler? Connected;
        public event EventHandler<Student>? LoggedIn;
        public event EventHandler<List<Quiz>>? Mh_questions_Received;
        public event EventHandler<List<SQuiz>>? S_questions_Received;

        public IPAddress Ip { get; set; }
        public int Port { get; set; }
        public string? Message
        {
            get => message;
            set
            {
                message = value;
                OnMessageChanged();
            }
        }
        protected virtual void OnMessageChanged()
        {
            MessageChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnConnected()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLoggedIn(Student st)
        {
            LoggedIn?.Invoke(this, st);
        }

        protected virtual void On_Mh_questions_Received(List<Quiz> quizzes)
        {
            Mh_questions_Received?.Invoke(this, quizzes);
        }

        protected virtual void On_S_questions_Received(List<SQuiz> squizzes)
        {
            S_questions_Received?.Invoke(this, squizzes);
        }

        public Q_Client(IPAddress ip, int port)
        {
            Ip = ip;
            Port = port;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public async Task StartClientAsync()
        {
            try
            {
                await socket.ConnectAsync(Ip, Port);
                Message = $"{DateTime.Now.ToLongTimeString()} session started";
                Ifconnected = true;
                OnConnected();

                // ОБРОБКА ВХІДНИХ ПОВІДОМЛЕНЬ (КЛІЄНТ)
                
                var receiveTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        byte[] _response = await ReceiveMessageAsync(socket);
                        if (_response.Length > 0)
                        {
                            //Message = $"{DateTime.Now.ToLongTimeString()} received {_response.Length} bytes";
                            if (TryDeserializeObject(_response, _response.Length, out List<Quiz> mh_questions))
                            {
                                Message = $"{mh_questions.Count} m_questions";
                                On_Mh_questions_Received(mh_questions);
                            }

                            else if (TryDeserializeObject(_response, _response.Length, out List<SQuiz> s_questions))
                            {
                                Message = $"{s_questions.Count} s_questions";
                                On_S_questions_Received(s_questions);
                            }
                            else if (TryDeserializeObject(_response, _response.Length, out Student student))
                            {
                                Message = $"{student.Name} {student.SurName} confirmed";
                                OnLoggedIn(student);
                            }

                            else if (Encoding.UTF8.GetString(_response) == "RegisterSuccess")
                            {
                                Message = $"registration succes";
                                //OnLoggedIn();
                            }

                            else if (Encoding.UTF8.GetString(_response) == "RegisterUnSuccess")
                            {
                                Message = $"register error!";
                                MessageBox.Show($"Registration failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            else if (Encoding.UTF8.GetString(_response) == "LoginSuccess")
                            {
                                Message = $"login success!";
                                //OnLoggedIn();
                            }
                            else if (Encoding.UTF8.GetString(_response) == "LoginUnSuccess")
                            {
                                Message = $"login failed!";
                                
                            }

                            else if (Encoding.UTF8.GetString(_response) == "AlreadyRegistered")
                            {
                                Message = $"User is already registered";
                                MessageBox.Show($"User with this email is already registered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                            else Message = $"unknown message: {Encoding.UTF8.GetString(_response)}";
                        }

                    }
                });
            }
            catch (Exception ex)
            {
                Message = $"{DateTime.Now.ToLongTimeString()} impossible to connect to server";
                Ifconnected = false;
                OnConnected();
            }
        }

        private async Task<byte[]> ReceiveMessageAsync(Socket socket)
        {
            byte[] buf = new byte[1024];
            List<byte> responseList = new List<byte>();

            while (true)
            {
                int len = await socket.ReceiveAsync(buf, SocketFlags.None);

                if (len <= 0)
                    break;

                byte[] receivedBytes = new byte[len];
                Array.Copy(buf, receivedBytes, len);
                responseList.AddRange(receivedBytes);

                // Check for end of file marker
                if (responseList.Count >= 9 && Encoding.UTF8.GetString(responseList.TakeLast(9).ToArray()) == "EndOfFile")
                {
                    Message = "EndOfFile";
                    responseList.RemoveRange(responseList.Count - 9, 9); 
                    break;
                }
            }

            return responseList.ToArray();
        }

        // ВІДПРАВЛЕННЯ ПОВІДОМЛЕНЬ
        public void SendMessage(byte[] data)
        {
            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, socket);
                Message = "msg sent";
            }
            catch
            {
                MessageBox.Show("Error sending data");
            }
        }

        public void SendMessage(byte[] data, string txt)
        {
            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, socket);
                Message = $"message \"{txt}\" is sent to server";
            }
            catch
            {
                MessageBox.Show("Error sending data");
            }
        }


        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                int bytesSent = clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                // Обробка помилок, якщо такі є
                MessageBox.Show($"Error in SendCallback: {ex.Message}");
            }
        }

    }
}