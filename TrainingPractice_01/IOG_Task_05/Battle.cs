using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOG_Task_05
{
    class Battle
    {
        public static void BattleProcces( Player player)
        {
            Console.Clear();
            Console.WriteLine("На вас напал Бандит");
            Bandit bandit = new Bandit();
            while(bandit.Hp > 0 & player.HP > 0)
            {
                Console.WriteLine("Ваше здоровье " + player.HP);
                Console.WriteLine("Здоровье бандита " + bandit.Hp);
                Console.WriteLine("Выберите вариант действия:");
                Console.WriteLine("Для выбора введите цифру соответствующую действию");
                Console.WriteLine("1 - Атака");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        StandartAttack(bandit,player);
                        break;
                }
                Console.WriteLine("Бандит атакует. Бандит наносит {0} урона",bandit.attackPower);
                player.HP -= bandit.attackPower;
            }
            if(player.HP <= 0)
            {
                Console.WriteLine("Вас убил бандит");
                Console.WriteLine("Вы проиграли");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
            Console.WriteLine("Вы победили бандита");
        }
        private static void StandartAttack(Bandit bandit,Player player)
        {
            Console.WriteLine("Вы атакуете бандита");
            Console.WriteLine("Вы наносте 20 урона");
            bandit.Hp -= player.attackPower;
        }
    }
}
