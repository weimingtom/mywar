using System;
using System.Collections.Generic;
using System.Text;
using MyWar.ClientService;

namespace MyWar
{
    class Game
    {
        public static IClientService ClientService = null;
        public static Server Server = null;
        public static string ServerIp = "";
        public static Player Player;
        public static Player CurrentPlayer;
        public static Player Target;

        public static Uri GetServiceUri(string host)
        {
            return new Uri(string.Format("net.tcp://{0}:6999/mywar", host));
        }

        public static bool IsServer()
        {
            return Server == ClientService;
        }
    }
}
