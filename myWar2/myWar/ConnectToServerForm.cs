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
using MyWar.ClientService;

namespace MyWar
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
                if (this.TextBox_IP.Text != "")
                {
                    if (this.TextBox_Nick.Text != "")
                    {
                        //Создаем объект который отвечает за обратную связь
                        var callback = new ClientServiceCallback();
                        var callbackInstance = new InstanceContext(callback);
                        var binding = new NetTcpBinding(SecurityMode.None);
                        var factory = new DuplexChannelFactory<IClientService>(callbackInstance, binding);
                        var endpoint = new EndpointAddress(Game.GetServiceUri(this.TextBox_IP.Text).ToString());

                        //Связь с сервером не устанавливается до тех пор, пока не будет вызван метод Connect
                        IClientService clientService = Game.ClientService;
                        if (clientService == null)
                        {
                            clientService = factory.CreateChannel(endpoint);
                        }

                        string playerName = this.TextBox_Nick.Text;
                        if (clientService.Connect(playerName))
                        {
                            callback.OnGameStart += () =>
                            {
                                this.Close();
                            };

                            Player player = new Player(playerName);
                            player.Callback = callback;

                            Game.Player = player;
                            Game.ClientService = clientService;
                            Game.ServerIp = this.TextBox_IP.Text;

                            this.TextBox_Status.Text = "Соединен";
                            this.Button_Cancel.Enabled = true;
                            this.Button_Connect.Enabled = false;
                        }
                        else
                        {
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
                MessageBox.Show(ex.Message);
//                MessageBox.Show("Извините, сервер не найден!");
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Game.ClientService != null)
                {
                    Game.ClientService.Disconnect();
                    Game.Player = null;
                    Game.ClientService = null;

                    this.Button_Connect.Enabled = true;
                    this.TextBox_Status.Text = "Отсоединен";
                    this.Button_Cancel.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnectToServerForm_Load(object sender, EventArgs e)
        {
            if (Game.ClientService != null)
            {
                this.TextBox_IP.Text = Game.ServerIp;
                this.Button_Cancel.Enabled = true;
                this.Button_Connect.Enabled = false;
                this.TextBox_Nick.Text = Game.Player.Name;
                this.TextBox_Status.Text = "Соединен";
            }
            else
            {
                this.TextBox_IP.Text = NetHelper.GetHostAddress().ToString();
            }
        }
    }
}
