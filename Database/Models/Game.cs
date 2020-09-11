using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Master { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public virtual List<Player> Players { get; set; }
    }
}
