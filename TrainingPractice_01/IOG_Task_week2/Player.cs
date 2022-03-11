using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_week2
{
    public class Player
    {
        public string Name { get; set; }
        public string Score { get; set; }
        public Player ( string name, string score)
        {
            Name = name;
            Score = score;
        }
    }
}
