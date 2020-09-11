using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ViewModel
{
    public class ReportViewModel
    {
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public DateTime DateDeath { get; set; }
    }
}
