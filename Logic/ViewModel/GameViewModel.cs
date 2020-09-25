using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.ViewModel
{
    public class GameViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Master { get; set; }

        public DateTime DateCreate { get; set; }

        public List<PlayerViewModel> Players { get; set; }
    }
}
