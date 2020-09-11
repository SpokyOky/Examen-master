using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class PlayerBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int GameId { get; set; }

        [DataMember]
        public string PlayerName { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public DateTime DateDeath { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}
