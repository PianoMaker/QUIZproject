using System.Net.Sockets;
using System.Net;
using System.Text;
using Models;
using static Utilities.Serializers;
using Utilities;
using QuizHolder;
//using Quiz = Utilities.Quiz;
//using SQuiz = Utilities.SQuiz;
//using Subject = Utilities.Subject;

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
        public event EventHandler<List<TQuiz>>? T_questions_Received;
        public event EventHandler<List<SQuiz>>? S_questions_Received;
        public event EventHandler? QuizLoaded;
        
        public event EventHandler? Relogin;
        public void TriggerRelogin()
        {
            Relogin?.Invoke(this, EventArgs.Empty);
        }


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
        private void OnMessageChanged()
        {
            MessageChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnConnected()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoggedIn(Student st)
        {
            // ПРИ ЛОГУВАННІ КОРИСТУВАЧА
            LoggedIn?.Invoke(this, st);
        }


        private void OnQuizLoaded()
        {
            QuizLoaded?.Invoke(this, EventArgs.Empty);
            Message = $"{DateTime.Now.ToLongTimeString()} quiz has been loaded";
        }

        private void On_T_questions_Received(List<TQuiz> quizzes)
        {
            T_questions_Received?.Invoke(this, quizzes);
        }

        private void On_S_questions_Received(List<SQuiz> squizzes)
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
                            Message = $"trying to recognise {_response.Length} bytes";
                            if (TryDeserializeObject(_response, _response.Length, out List<TQuiz> t_questions))
                            {
                                Message = $"{t_questions.Count} t_questions";
                                await Task.Run(OnQuizLoaded);
                                await Task.Run(() => On_T_questions_Received(t_questions));

                            }

                            else if (TryDeserializeObject(_response, _response.Length, out List<SQuiz> s_questions))
                            {
                                Message = $"{s_questions.Count} s_questions";
                                await Task.Run(OnQuizLoaded);
                                await Task.Run(() => On_S_questions_Received(s_questions));

                            }
                            // ОТРИМАННЯ ПРОФІЛЮ З РЕЗУЛЬТАТАМИ
                            else if (TryDeserializeObject(_response, _response.Length, out Student student))
                            {
                                Message = $"login {student.Name} {student.SurName} confirmed";
                                OnLoggedIn(student);
                            }

                            else if (Encoding.UTF8.GetString(_response) == "RegisterSuccess")
                            {
                                Message = $"registration succes";
                                //OnLoggedIn(student);
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
                            else if (Encoding.UTF8.GetString(_response) == "EndOfFileLoginSuccess")
                            {
                                Message = $"login success with warning!";
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


                            else
                            {
                                Message = $"unknown message: {Encoding.UTF8.GetString(_response)}";
                                TriggerRelogin();
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
                Message = $"{DateTime.Now.ToLongTimeString()} processing message {len} bytes";
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
               // Message = "msg sent";
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