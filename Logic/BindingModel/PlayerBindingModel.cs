using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    public class PlayerBindingModel
    {
        public int? Id { get; set; }

        public int GameId { get; set; }

        public string PlayerName { get; set; }

        public int Score { get; set; }

        public DateTime DateDeath { get; set; }

        public string Type { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
