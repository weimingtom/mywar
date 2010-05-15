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
        private List<CUser> m_userList = new List<CUser>();

        public CreateServerForm(ServiceHost _host)
       { 
            this.m_host = _host;
            this.m_server = new CServer();
            this.t = new Thread(new ThreadStart(updateListGamers));
            InitializeComponent();
        }

        private void updateListGamers()
        {
            while (true)
            {
                List<CUser> userList = new List<CUser>();
                userList = this.m_server.getUserList();
                if (userList.Count < this.m_userList.Count) //если кто-то отсоединился
                {
                    this.m_userList.Clear();
                    this.DataGridView_Players.Rows.Clear();
                }
                foreach (CUser user in userList) //добавление нового игрока в список
                {
                    bool isExists = false;
                    for (int index = 0; index < m_userList.Count; index++)
                    {
                        if (m_userList[index] == user)
                        {
                            isExists = true;
                        }
                    }
                    if (!isExists)
                    {
                        this.DataGridView_Players.Rows.Add(user.getUserName());
                        this.m_userList.Add(user);
                    }
                }
                Thread.Sleep(100);
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
                    t.Start();
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
            if (userList.Count != 0)
            {
                foreach (CUser user in userList)
                {
                    IClientServiceCallback callback = user.getCallback();
                    callback.gameStart();
                }
            }
            else
            {
                MessageBox.Show("Извините, игра не может быть начата, т.к к Вам никто не присоединился");
            }
        }

        private void button_getServerIP_Click(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();
            IPAddress ip = Dns.GetHostByName(hostname).AddressList[0];
            MessageBox.Show(ip.ToString());
        }

        private void CreateServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }

        private void CreateServerForm_Load(object sender, EventArgs e)
        {
            List<CUser> userList = new List<CUser>();
            userList = this.m_server.getUserList();
            foreach (CUser user in userList)
            {
                this.DataGridView_Players.Rows.Add(user.getUserName());
                this.m_userList.Add(user);
            }
        }
    }
}
