using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using SignalRServerService.Hubs;
using System;
using System.Runtime.CompilerServices;
using NLog;

namespace SignalRServerService
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        { 
            string url = "http://localhost:8089";
            using (WebApp.Start(url))
            {
                Logger.Info("Server running on {0}", url);
                Console.WriteLine("Server running on {0}", url);
                while (true)
                {
                    string key = Console.ReadLine();
                    if (key.ToUpper() == "W")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<EventStoreHub>();
                        hubContext.Clients.All.addMessage("server", "ServerMessage");
                        Console.WriteLine("Server Sending addMessage\n");
                    }
                    if (key.ToUpper() == "C")
                    {
                        break;
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
