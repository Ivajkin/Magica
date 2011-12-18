using System;

namespace MagicaXNAClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length > 1 && args[1] == "--server")
            {
                HTTPServer.Server server = new HTTPServer.Server(8123);
            }
            using (Game game = new Game())
            {
                game.Run();
            }
        }
    }
}

