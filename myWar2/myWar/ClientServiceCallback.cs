using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MyWar.ClientService;
using System.ServiceModel;

namespace MyWar
{
    [CallbackBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class ClientServiceCallback : IClientServiceCallback
    {
        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        public void GameStart()
        {
            if (OnGameStart != null)
            {
                OnGameStart();
            }
            //MessageBox.Show("Игра началась");
        }

        public void Turn(Player player, Player target)
        {
            if (OnTurn != null)
            {
                OnTurn(player, target);
            }
        }

        public void Fire(Player player, int col, int row)
        {
            if (OnFire != null)
            {
                OnFire(player, col, row);
            }
        }

        public delegate void OnGameStartHandler();
        public event OnGameStartHandler OnGameStart;

        public delegate void OnTurnHandler(Player player, Player target);
        public event OnTurnHandler OnTurn;

        public delegate void OnFireHandler(Player player, int col, int row);
        public event OnFireHandler OnFire;
    }
}
