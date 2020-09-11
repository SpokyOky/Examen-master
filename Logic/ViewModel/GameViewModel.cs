using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.ViewModel
{
    [DataContract]
    public class GameViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DataMember]
        [DisplayName("Ведущий")]
        public string Master { get; set; }

        [DataMember]
        [DisplayName("Дата проведения")]
        public DateTime DateCreate { get; set; }

        public List<PlayerViewModel> Players { get; set; }
    }
}
