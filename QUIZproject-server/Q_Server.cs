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

namespace QUIZproject_server
{
    internal class Q_Server
    {
        public IPAddress Host { get; set; }
        public int Port { get; set; }

        private Socket socket;
        public List<Socket> ClientSocket { get; set; }

        public List<Quiz> Mh_questions { get; set; }
        public List<SQuiz> S_questions { get; set; }

        public List<Student> Students { get; set; }

        private string message;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnMessageChanged();
            }
        }// повідомлення

        public event EventHandler MessageChanged;

        protected virtual void OnMessageChanged()
        {
            MessageChanged?.Invoke(this, EventArgs.Empty);
        }

        public byte[] BinData { get; set; }

        public Q_Server(IPAddress ip, int port)
        {
            Host = ip;
            Port = port;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Message = "test";
            ClientSocket = new List<Socket>();
        }

        public void StartServer()
        {
            socket.Bind(new IPEndPoint(Host, Port));
            socket.Listen(10);
            Message = $"{DateTime.Now.ToLongTimeString()} Server started. Waiting for connections...";
            socket.BeginAccept(AcceptCallbackMethod, null);
        }

        private void AcceptCallbackMethod(IAsyncResult result)
        {
            ClientSocket.Add(socket.EndAccept(result));
            var clientSocket = socket.EndAccept(result);
            Message = $"{DateTime.Now.ToLongTimeString()} Client {clientSocket.RemoteEndPoint} connected.";

            var state = new StateObject { WorkSocket = clientSocket };
            clientSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallbackMethod, state);

            // Відправка даних клієнту
            if (BinData != null && BinData.Length > 0)
            {
                SendData(clientSocket, BinData);
            }

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

                if (receivedBytes > 0)
                {
                    if (TryDeserializeObject(state.Buffer, receivedBytes, out StudentLogin st) == true)
                    {
                        Message = $"{st.Name} {st.SurName} have connected";

                    }
                    else if (TryDeserializeObject(state.Buffer, receivedBytes, out StudentAnswer sta) == true)
                    {
                        Message = $"{sta.Name} {sta.SurName} answered {sta.S_quiz?.Question}";
                    }
                    else if (receivedData == "Musichistory")
                    {
                        Message = $"student - {clientSocket.RemoteEndPoint} reauested MusicHistory quiz"; // Адреса клієнта
                        SendData(clientSocket, PrepareDara(Subject.Musichistory));
                    }
                    else if (receivedData == "Solfegio")
                    {
                        Message = $"student - {clientSocket.RemoteEndPoint} reauested Solfegio quiz";
                        SendData(clientSocket, PrepareDara(Subject.Solfegio));

                    }
                    else Message = $"uknonw type message: {receivedData}";
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

        // Метод для відправки даних клієнту

        private byte[] PrepareDara(Subject subj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (subj == Subject.Musichistory)
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Quiz));
                    serializer.WriteObject(memoryStream, Mh_questions);
                }
                if (subj == Subject.Solfegio)
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(SQuiz));
                    serializer.WriteObject(memoryStream, S_questions);
                }
                byte[] endOfFileMarker = Encoding.UTF8.GetBytes("EndOfFile");
                memoryStream.Write(endOfFileMarker, 0, endOfFileMarker.Length);
                byte[] bytes = memoryStream.ToArray();
                //MessageBox.Show($"{bytes.Length} bytes are prepared to send");
                return bytes;
            }
        }


        public void SendData(Socket clientSocket, byte[] data)
        {

            Message = $"Trying to send data";
            try
            {
                clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallbackMethod, clientSocket);

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
