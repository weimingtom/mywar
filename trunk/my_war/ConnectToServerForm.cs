using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using ClientService;

namespace my_war
{
    public partial class ConnectToServerForm : Form
    {
        private IClientService m_gamer=null;

        public ConnectToServerForm()
        {
            InitializeComponent();
        }

        private void Button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                //Создаем объект который отвечает за обратную связь
                InstanceContext context = new InstanceContext(new CClientCallbackHandler());
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                DuplexChannelFactory<IClientService> factory = new DuplexChannelFactory<IClientService>(context, binding);
                //Uri address = new Uri("net.tcp://" + TextBox_IP.Text + ":6999/IClientService");
                if (this.TextBox_IP.Text != "")
                {
                    if (this.TextBox_Nick.Text != "")
                    {
                        EndpointAddress endpoint = new EndpointAddress("net.tcp://" + this.TextBox_IP.Text + ":6999/IClientService");
                        //Связь с сервером не устанавливается до тех пор, пока не будет вызван метод Connect
                        if (this.m_gamer == null)
                        {
                            this.m_gamer = factory.CreateChannel(endpoint);
                        }
                        if (this.m_gamer.Connect(this.TextBox_Nick.Text))
                        {
                            this.TextBox_Status.Text = "Соединен";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Укажите Ваш ник");
                    }
                }
                else
                {
                    MessageBox.Show("Укажите ip-адрес сервера");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_gamer != null)
                {
                    this.m_gamer.Disconnect();
                    this.TextBox_Status.Text = "Отсоединен";
                    this.m_gamer = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
