using System.ServiceModel;

namespace Service
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(serverServiceCallback))] 
    public interface serverService
    {
        [OperationContract(IsInitiating = true, IsOneWay = false, IsTerminating = false)]
        bool Join(string name);
        [OperationContract(IsInitiating = false, IsOneWay = true, IsTerminating = true)]
        void Leave();
    }

    public interface serverServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void UserEnter(string name);  

        /*[OperationContract(IsOneWay = true)]
        void UserLeave(string name);
        [OperationContract]
        void setUserName(string username);*/
    }


    [ServiceContract]
    public interface clientService
    {
        [OperationContract]
        bool isConnect();
    }
}