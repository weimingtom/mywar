using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

using Service;

namespace my_war
{
    public partial class CreateServerForm : Form
    {
        public CreateServerForm()
        {
            InitializeComponent();
        }

        private void Button_CreateServer_Click(object sender, EventArgs e)
        {
            using (var serviceHost = new ServiceHost(typeof(Server)))
            {
                try
                {
                    NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                    String address = ("net.tcp://192.168.1.1:7020/Server");
                    serviceHost.AddServiceEndpoint(typeof(serverService), binding, address);
                    serviceHost.Open();
                    Console.WriteLine("Service running...");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
