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
    public partial class ConnectToServerForm : Form
    {
        public ConnectToServerForm()
        {
            InitializeComponent();
        }

        private void Button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                InstanceContext context = new InstanceContext(new Client());
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                DuplexChannelFactory<serverService> factory = new DuplexChannelFactory<serverService>(context, binding);
                EndpointAddress endpoint = new EndpointAddress("net.tcp://192.168.1.1:7020/Server");

                serverService game = factory.CreateChannel(endpoint);
                string username = TextBox_Nick.Text.ToString();
                var channelFactory = new ChannelFactory<clientService>(binding, endpoint);
                var service = channelFactory.CreateChannel();
                game.Join(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
