using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using ClientService;

namespace my_war
{
    public partial class CreateServerForm : Form
    {
        private Thread t;
        private ServiceHost m_host;
        private CServer m_server;

        public CreateServerForm(ServiceHost _host)
        {
            this.m_host = _host;
            this.m_server = new CServer();
            this.t = new Thread(new ThreadStart(updateListGamers));
            InitializeComponent();
        }

        ~CreateServerForm()
        {
            this.t.Abort();
        }

        private void updateListGamers()
        {
            while (true)
            {
                List<CUser> userList = new List<CUser>();
                userList = this.m_server.getUserList();
                //сделать проверку на повторное добавление
                foreach (CUser user in userList)
                {
                    this.DataGridView_Players.Rows.Add(user.getUserName());
                }
                Thread.Sleep(5000);
            }
        }

        private void Button_CreateServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Nick.Text != "")
                {
                    this.m_host.Open();
                    MessageBox.Show("Сервер создан");
                    this.t.Start();
                }
                else
                {
                    MessageBox.Show("Укажите имя игрока");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            t.Abort();
            this.m_server.setStartGame(true);
            List<CUser> userList = new List<CUser>();
            userList =  this.m_server.getUserList();
            foreach (CUser user in userList)
            {
                IClientServiceCallback callback = user.getCallback();
                callback.gameStart();
            }
        }

        private void button_getServerIP_Click(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();
            IPAddress ip = Dns.GetHostByName(hostname).AddressList[0];
            MessageBox.Show(ip.ToString());
        }
    }
}
