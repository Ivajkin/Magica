
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace HTTPServer
{
    public class Interaction
    {
        const string Server_Directory = "C:\\Work\\HTTPServer\\page_content\\";
        const string Error_Message = "None";
        const string Main_Page = "nsu.htm";

        TcpClient Client;
        Hashtable Contents = new Hashtable();
        /// <summary>
        /// По строке запроса вычисляем путь к файлу.
        /// </summary>
        public string GetPath(string request)
        {
            int space1 = request.IndexOf(" ");
            int space2 = request.IndexOf(" ", space1 + 1);
            string url = request.Substring(space1 + 2, space2 - space1 - 2);
            if (url == "")
                url = Main_Page;
            return Server_Directory + url;
        }
        /// <summary>
        /// По файлу вычисляем тип содержимого в нём
        /// </summary>
        public string GetContent(string file_path)
        {
            string ext = "";
            int dot = file_path.LastIndexOf(".");
            if (dot >= 0)
                ext = file_path.Substring(dot, file_path.Length - dot).ToUpper();
            if (Contents[ext] == null)
                return "application/" + ext;
            else
                return (string)Contents[ext];
        }
        /// <summary>
        /// Отправляем заголовок клиенту.
        /// </summary>
        public void WriteHeaderToClient(string content_type, long length)
        {
            string str = "HTTP/1.1 200 OK\nContent-type: " + content_type
                   + "\nContent-Encoding: 8bit\nContent-Length:" + length.ToString()
                   + "\n\n";
            Client.GetStream().Write(Encoding.ASCII.GetBytes(str), 0, str.Length);
        }
        /// <summary>
        ///  Отвечаем на запрос клиенту
        /// </summary>
        public void WriteToClient(string request)
        {
            string file_path = GetPath(request);
            if (file_path.IndexOf("..") >= 0 || !File.Exists(file_path))
            {
                WriteHeaderToClient("text/plain", Error_Message.Length);
                Client.GetStream().Write(Encoding.ASCII.GetBytes(Error_Message), 0, Error_Message.Length);
                return;
            }
            FileStream file = File.Open(file_path, FileMode.Open);
            WriteHeaderToClient(GetContent(file_path), file.Length);
            byte[] buf = new byte[1024];
            int len;
            while ((len = file.Read(buf, 0, 1024)) != 0)
                Client.GetStream().Write(buf, 0, len);
            file.Close();
        }
        public void Interact()
        {
            try
            {
                byte[] buffer = new byte[1024];
                string request = "";
                while (true)
                {
                    int count = Client.GetStream().Read(buffer, 0, 1024);
                    request += Encoding.ASCII.GetString(buffer, 0, count);
                    if (request.IndexOf("\r\n\r\n") >= 0) // Запрос обрывается \r\n\r\n последовательностью
                    {
                        WriteToClient(request);
                        request = "";
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        protected void SetContents()
        {
            Contents.Add("", "application/unknown");
            Contents.Add(".HTML", "text/html");
            Contents.Add(".HTM", "text/html");
            Contents.Add(".TXT", "text/plain");
            Contents.Add(".GIF", "image/gif");
            Contents.Add(".JPG", "image/jpeg");
        }
        public Interaction(TcpClient client)
        {
            Client = client;
            SetContents();
            Thread interact = new Thread(new ThreadStart(Interact));
            interact.Start();
        }
    }

    public class Server
    {
        private TcpListener Listener;

        public Server(int port)
        {
            Listener = new TcpListener(port);
            Listener.Start();
            Listen();
        }
        ~Server()
        {
            if (Listener != null)
                Listener.Stop();
        }
        /// <summary>
        /// Ждём подключений к нашему серверу и обрабатываем их
        /// </summary>
        public void Listen()
        {
            while (true)
                new Interaction(Listener.AcceptTcpClient());
        }
        /*[STAThread]
        static void Main(string[] args)
        {
            Server server = new Server(8123);
        }*/
    }
}