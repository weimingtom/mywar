using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;
using ClientService;

namespace my_war
{
    public partial class ConnectToServerForm : Form
    {
        private List<string> m_ListUser = new List<string>();
        private Thread t = null;

        private void isStartGame()
        {
            while (true)
            {
                if (MainForm.m_iClientService.getStart())
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            this.Close();
        }

        public ConnectToServerForm(string _username)
        {
            InitializeComponent();
        }
         
        private void Button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                this.t = new Thread(new ThreadStart(isStartGame));
                //Создаем объект который отвечает за обратную связь
                InstanceContext context = new InstanceContext(new CClientCallbackHandler());
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                DuplexChannelFactory<IClientService> factory = new DuplexChannelFactory<IClientService>(context, binding);
                if (this.TextBox_IP.Text != "")
                {
                    if (this.TextBox_Nick.Text != "")
                    {
                        EndpointAddress endpoint = new EndpointAddress("net.tcp://" + this.TextBox_IP.Text + ":6999/IClientService");
                        //Связь с сервером не устанавливается до тех пор, пока не будет вызван метод Connect
                        if (MainForm.m_iClientService == null)
                        {
                            MainForm.m_iClientService = factory.CreateChannel(endpoint);
                        }
                        if (MainForm.m_iClientService.Connect(this.TextBox_Nick.Text))
                        {
                            MainForm.m_userName = this.TextBox_Nick.Text;
                            MainForm.m_serverIp = this.TextBox_IP.Text;
                            this.TextBox_Status.Text = "Соединен";
                            this.Button_Cancel.Enabled = true;
                            this.Button_ListGamer.Enabled = true;
                            this.Button_Connect.Enabled = false;
                            this.t.Start();
                        }
                        else
                        {
                            MainForm.m_iClientService = null;
                            MessageBox.Show("Извините, данный ник занят");
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
                MainForm.m_iClientService = null;
                MessageBox.Show("Извините, сервер не найден!");
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainForm.m_iClientService != null)
                {
                    if (this.t != null)
                    {
                        this.t.Abort();
                        this.t = null;
                    }
                    MainForm.m_iClientService.Disconnect();
                    this.Button_Connect.Enabled = true;
                    this.Button_ListGamer.Enabled = false;
                    this.TextBox_Status.Text = "Отсоединен";
                    MainForm.m_iClientService = null;
                    this.Button_Cancel.Enabled = false;
                    this.Button_ListGamer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_ListGamer_Click(object sender, EventArgs e)
        {
            this.m_ListUser = MainForm.m_iClientService.getUserListOnNet();  
        }

        private void ConnectToServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.t != null)
            {
                this.t.Abort();
            }
        }

        private void ConnectToServerForm_Load(object sender, EventArgs e)
        {
            if (MainForm.m_iClientService != null)
            {
                this.TextBox_IP.Text = MainForm.m_serverIp;
                this.Button_Cancel.Enabled = true;
                this.Button_ListGamer.Enabled = true;
                this.Button_Connect.Enabled = false;
                this.TextBox_Nick.Text = MainForm.m_userName;
                this.TextBox_Status.Text = "Соединен";
            }
        }
    }
}
