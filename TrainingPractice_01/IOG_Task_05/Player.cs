using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_05
{
    class Player
    {
        public int maxHP;
        public int maxMP;
        public int HP;
        public int MP;
        public int attackPower = 25;
        public Player(int maxHP,int maxMP)
        {
            this.HP = maxHP;
            this.MP = maxMP;
            this.maxHP = maxHP;
            this.maxMP = maxMP;
        }
        public static void HealthBar(int currentHP,int maxHp)
        {
            int percent = currentHP * 100 / maxHp;
            string healthBar = "[__________]";
            if (percent <= 10) { healthBar = "[#________]"; };
            if (percent <= 20 & percent > 10) { healthBar = "[##________]"; };
            if (percent <= 30 & percent > 20) { healthBar = "[###_______]"; };
            if (percent <= 40 & percent > 30) { healthBar = "[####______]"; };
            if (percent <= 50 & percent > 40) { healthBar = "[#####_____]"; };
            if (percent <= 60 & percent > 50) { healthBar = "[######____]"; };
            if (percent <= 70 & percent > 60) { healthBar = "[#######___]"; };
            if (percent <= 80 & percent > 70) { healthBar = "[########__]"; };
            if (percent <= 90 & percent > 80) { healthBar = "[#########_]"; };
            if (percent <= 100 & percent > 90) { healthBar = "[##########]"; };
            Console.WriteLine("Ваше здоровье: " + currentHP +" "+healthBar);
        }
    }
}
