using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace MyWar.ClientService
{
    [DataContract]
    public class Player
    {
        private IClientServiceCallback _callback;

        [DataMember]
        private string _name;

        public bool IsReady;

        [DataMember]
        public Field Field;

        public bool IsDead
        {
            get { return Field.BuildingCount <= 0; }
        }

        public Player(string name)
        {
            _name = name;
            Field = new Field();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public IClientServiceCallback Callback
        {
            get { return _callback; }
            set { _callback = value; }
        }
    }
}