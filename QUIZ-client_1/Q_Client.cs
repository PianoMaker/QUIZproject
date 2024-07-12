using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Models;
using static Models.Serializers;
namespace QUIZ_client_1
{
    public class Q_Client
    {
        private string? message;
        private Socket socket;
        public bool Ifconnected { get; set; }
        public byte[] Bin { get; set; }

        public List<Quiz> ReceivedQuizzes { get; } = new ();
        public List<SQuiz> ReceivedSQuizzes { get; } = new ();

        public event EventHandler? MessageChanged;
        public event EventHandler? Connected;
        public event EventHandler<List<Quiz>>? QuizzesReceived;

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

        protected virtual void OnQuizzesReceived(List<Quiz> quizzes)
        {
            QuizzesReceived?.Invoke(this, quizzes);
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

                var receiveTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        byte[] _response = await ReceiveMessageAsync(socket);
                        if (_response.Length > 0)
                        {
                            Message = $"{DateTime.Now.ToLongTimeString()} received {_response.Length} bytes";

                            if (TryDeserializeObject(_response, _response.Length, out List<Quiz> quizzes))
                            {
                                ReceivedQuizzes.AddRange(quizzes);
                                OnQuizzesReceived(quizzes);
                                Message = $"{DateTime.Now.ToLongTimeString()} received quizz";
                            }                           
                            
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
                    responseList.RemoveRange(responseList.Count - 9, 9); // Remove "EndOfFile" from result
                    break;
                }
            }

            return responseList.ToArray();
        }
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
                Message = $"{txt} sent";
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