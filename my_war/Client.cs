using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientService;

namespace my_war
{
    public class CClientCallbackHandler : IClientServiceCallback
    {
        public void userEnter(string name)
        {
            MessageBox.Show("Игрок " + name + " присоединился");
        }

        public void userLeave(string name)
        {
            MessageBox.Show("Игрок " + name + " вышел");
        }

        public void gameStart()
        {
            MessageBox.Show("Игра началась");
        }
    }
}