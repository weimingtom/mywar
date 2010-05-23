using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MyWar.ClientService
{
    [DataContract]
    public class Field
    {
        public const int Empty = 0;
        public const int Building = 1;
        public const int Miss = 2;
        public const int Fire = 3;

        public Field()
        {
            Scores = new byte[10][];
            Cells = new byte[10][];
            for (int i = 0; i < 10; i++)
            {
                Scores[i] = new byte[10];
                Cells[i] = new byte[10];
            }
        }

        [DataMember]
        public int BuildingCount;

        [DataMember]
        public byte[][] Cells;

        [DataMember]
        public byte[][] Scores;
    }
}
