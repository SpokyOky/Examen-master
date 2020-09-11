using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Models
{
    public class Player
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public DateTime DateDeath { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual Game Game { get; set; }
    }
}
