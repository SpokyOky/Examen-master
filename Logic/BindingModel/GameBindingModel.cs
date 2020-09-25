using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    public class GameBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Master { get; set; }

        public DateTime DateCreate { get; set; }

        public List<PlayerBindingModel> Players { get; set; }
    }
}
