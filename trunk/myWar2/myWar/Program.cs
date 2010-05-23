using System;
using System.Net;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
using MyWar.ClientService;

namespace MyWar
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(Server)))
            {
                try
                {
                    Uri address = Game.GetServiceUri(Dns.GetHostName());
                    NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                    host.AddServiceEndpoint(typeof(IClientService), binding, address);

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
