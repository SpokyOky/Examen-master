using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class GameBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Master { get; set; }

        [DataMember]
        public DateTime DateCreate { get; set; }

        public List<PlayerBindingModel> Players { get; set; }
    }
}
