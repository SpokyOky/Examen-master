using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.ViewModel
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string PlayerName { get; set; }

        public int Score { get; set; }

        public DateTime DateDeath { get; set; }

        public string Type { get; set; }
    }
}
