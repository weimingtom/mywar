using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

using ClientService;

namespace my_war
{
    public partial class CreateServerForm : Form
    {
        private ServiceHost m_host;
        private CServer m_server;
        public CreateServerForm(ServiceHost _host)
        {
            this.m_host = _host;
            this.m_server = new CServer();
            InitializeComponent();
        }

        private void Button_CreateServer_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_host.Open();
                MessageBox.Show("Сервер создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            this.m_server.setStartGame(true);
            List<CUser> userList = new List<CUser>();
            userList =  this.m_server.getUserList();
            foreach (CUser user in userList)
            {
                IClientServiceCallback callback = user.getCallback();
                callback.gameStart();
            }
        }
    }
}
