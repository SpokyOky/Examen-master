using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.ViewModel
{
    [DataContract]
    public class PlayerViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int GameId { get; set; }

        [DataMember]
        [DisplayName("Название")]
        public string PlayerName { get; set; }

        [DataMember]
        [DisplayName("Счёт")]
        public int Score { get; set; }

        [DataMember]
        [DisplayName("Дата смерти")]
        public DateTime DateDeath { get; set; }

        [DataMember]
        [DisplayName("Тип персонажа")]
        public string Type { get; set; }
    }
}
