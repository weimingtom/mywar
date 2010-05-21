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
        private List<CUser> m_userList = new List<CUser>();

        public CreateServerForm(ServiceHost _host)
       { 
            this.m_host = _host;
            this.t = new Thread(new ThreadStart(updateListGamers));
            InitializeComponent();
        }

        //работает в потоке и обновляет список если кто-то добавился или удалился
        private void updateListGamers()
        {
            while (true)
            {
                List<CUser> userList = new List<CUser>();
                userList = MainForm.m_server.getUserListOnServer();
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
                    MainForm.m_servername = this.TextBox_Nick.Text;
                    MainForm.m_server.addServerName(this.TextBox_Nick.Text);
                    MessageBox.Show("Сервер создан");
                    this.Button_Start.Enabled = true;
                    this.Button_CreateServer.Enabled = false;
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
            MainForm.m_gameStart = true;
            List<CUser> userList = new List<CUser>();
            userList = MainForm.m_server.getUserListOnServer();
            if (userList.Count != 0)
            {
                foreach (CUser user in userList)
                {
                    if (MainForm.m_servername == user.getUserName())
                    {
                        continue;
                    }
                    IClientServiceCallback callback = user.getCallback();
                    callback.gameStart();
                }
                this.Close();
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
            this.TextBox_Nick.Text = MainForm.m_servername;
            if (MainForm.m_servername != "")
            {
                this.Button_CreateServer.Enabled = false;
                this.Button_Start.Enabled = true;
            }
            List<CUser> userList = new List<CUser>();
            userList = MainForm.m_server.getUserListOnServer();
            foreach (CUser user in userList)
            {
                this.DataGridView_Players.Rows.Add(user.getUserName());
                this.m_userList.Add(user);
            }
        }
    }
}
