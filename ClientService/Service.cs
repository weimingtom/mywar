using System.Windows.Forms;
using System.ServiceModel;
using System.Collections.Generic;

namespace ClientService
{
    [ServiceContract(SessionMode=SessionMode.Required, CallbackContract=typeof(IClientServiceCallback))]
    public interface IClientService
    {
        [OperationContract(IsInitiating = true, IsOneWay = false, IsTerminating = false)]
        bool Connect(string name);

        [OperationContract(IsOneWay=false)]
        bool getStart();

        [OperationContract(IsOneWay = false)]
        List<string> getUserListOnNet();

        [OperationContract(IsOneWay = false)]
        int getUserListSize();

        [OperationContract(IsInitiating = false, IsOneWay = true, IsTerminating = true)]
        void Disconnect();
    }

    public interface IClientServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void userEnter(string name);

        [OperationContract(IsOneWay = true)]
        void userLeave(string name);

        [OperationContract(IsOneWay = true)]
        void gameStart();
    }
}