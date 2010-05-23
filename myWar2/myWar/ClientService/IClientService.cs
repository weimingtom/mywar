using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MyWar.ClientService
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IClientServiceCallback))]
    public interface IClientService
    {
        [OperationContract(IsInitiating = true, IsOneWay = false, IsTerminating = false)]
        bool Connect(string name);

        [OperationContract(IsInitiating = false, IsOneWay = true, IsTerminating = true)]
        void Disconnect();

        [OperationContract]
        bool IsGameStarted();

        [OperationContract]
        Player GetServer();

        [OperationContract(IsOneWay = true)]
        void Ready(string playerName);

        [OperationContract]
        List<Player> GetPlayers();

        [OperationContract]
        void SetField(string playerName, Field field);

        [OperationContract(IsOneWay = true)]
        void Fire(string playerName, int col, int row);

        [OperationContract]
        bool IsAutomaticMode();
    }
}
