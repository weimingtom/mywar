using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientService;

namespace my_war
{
    //объявление методов для связи сервера с клиентом
    public class CClientCallbackHandler : IClientServiceCallback
    {
        //отсылает сообщение клиенту
        public void userEnter(string name)
        {
            MessageBox.Show("Игрок " + name + " присоединился");
        }

        public void userLeave(string name)
        {
            MessageBox.Show("Игрок " + name + " отсоединился");
        }

        public void gameStart()
        {
            MessageBox.Show("Игра началась");
        }
    }
}