using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QUIZ_client_1
{
    public class Q_Client
    {
        private string? message;
        private Socket socket;
        public byte[] Bin { get; set; }


        public event EventHandler? MessageChanged;
        public event EventHandler? NumbersChanged;

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

        protected virtual void OnNumbersChanged()
        {
            NumbersChanged?.Invoke(this, EventArgs.Empty);
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

                var receiveTask = Task.Run(async () =>
                {
                    while (true)
                    {

                        byte[] _response = await ReceiveMessageAsync(socket);
                        if (_response.Length > 0)
                        {
                            Message = $"{DateTime.Now.ToLongTimeString()} received {_response.Length} bytes";
                            try
                            {
                                Bin = _response;
                                OnNumbersChanged();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"{DateTime.Now.ToLongTimeString()} error serializing data\n: {ex.Message}");
                            }
                        }

                    }
                });
            }
            catch (Exception ex)
            {
                Message = $"{DateTime.Now.ToLongTimeString()} impossible to connect to server";
            }
        }

        private async Task<byte[]> ReceiveMessageAsync(Socket socket)
        {
            byte[] buf = new byte[1024];
            List<byte> responseList = new List<byte>();
            Message = "waiting";
            Console.Beep(440, 200);

            while (true)
            {
                int len = await socket.ReceiveAsync(buf, SocketFlags.None);

                if (len <= 0)
                {
                    Console.Beep(770, 200);
                    break;
                }

                //Message = $"{DateTime.Now.ToLongTimeString()} received {len} bytes";

                byte[] receivedBytes = new byte[len];
                Array.Copy(buf, receivedBytes, len);

                responseList.AddRange(receivedBytes);

                // Порівняння з "EndOfFile"
                if (responseList.Count >= 9 && Encoding.UTF8.GetString(responseList.TakeLast(9).ToArray()) == "EndOfFile")
                {
                    Console.Beep(660, 200);
                    responseList.RemoveRange(responseList.Count - 9, 9); // Видалення "EndOfFile" з результату
                    break;
                }
                else
                {
                    Console.Beep(880, 200);
                }
            }

            return responseList.ToArray();
        }
        public void SendMessage(byte[] data)
        {
            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, socket);
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