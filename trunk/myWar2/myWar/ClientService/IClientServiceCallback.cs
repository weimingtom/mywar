using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace MyWar.ClientService
{
    public interface IClientServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Message(string message);

        [OperationContract(IsOneWay = true)]
        void GameStart();

        [OperationContract(IsOneWay = true)]
        void Turn(Player player, Player target);

        [OperationContract(IsOneWay = true)]
        void Fire(Player player, int col, int row);
    }
}
