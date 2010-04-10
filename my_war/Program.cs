using System;
using System.Net;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

using ClientService;

namespace my_war
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(CServer)))
            {
                try
                {
                    string hostname = Dns.GetHostName();
                    IPAddress ip = Dns.GetHostByName(hostname).AddressList[0];
                    NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                    Uri address = new Uri("net.tcp://"+ip.ToString()+":6999/IClientService");
                    host.AddServiceEndpoint(typeof(IClientService), binding, address.ToString());
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm(host));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
