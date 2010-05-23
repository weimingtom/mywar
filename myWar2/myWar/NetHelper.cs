using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace MyWar
{
    internal class NetHelper
    {
        private static IPAddress _ipAddress;

        public static IPAddress GetHostAddress()
        {
            if (_ipAddress == null)
            {
                string hostname = Dns.GetHostName();
                _ipAddress = Dns.GetHostByName(hostname).AddressList[0];
            }
            return _ipAddress;
        }
    }
}
