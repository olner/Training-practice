using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOG_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            bool playerWin = false, bossWin = false;
            var data = new Dictionary<string, int>()
            {
                {"PlayerHp", rand.Next(600, 1000)},
                {"BossHp",rand.Next(600, 1000)},
                {"ColdSnapTime",0 },
                {"ForgeSpirit",0 }
            };


            Console.WriteLine("Игра - Победи БОССА");
            Console.WriteLine("Условия:");
            Console.WriteLine("Максимальный уровень жизни у Босса - " + data["BossHp"]);
            Console.WriteLine("Максимальный уровень жизни у Игрока - " + data["PlayerHp"]);
            Console.WriteLine("Ходы поочередные");
            Console.WriteLine("Величина урона, наносимого БОССОМ, для каждого хода случайна");
            Console.WriteLine("Игрок может пользоваться следующими заклинаниями:");
            SpellList();
            Console.WriteLine(" ");

            var turn = 1;
            while(playerWin == false && bossWin == false)
            {
                Console.WriteLine("         Ход " + turn);
                Console.WriteLine("Ваше здоровье: " + data["PlayerHp"]);
                Console.WriteLine("Здоровье босса: " + data["BossHp"]);
                Console.WriteLine("Кол-во ваших духов: " +data["ForgeSpirit"]);
                Console.WriteLine("Эффектов cold snap осталось: "+ data["ColdSnapTime"]);
                Console.WriteLine("Введите заклинание");

                switch (Console.ReadLine().ToLower())
                {
                    case "sun strike":
                        SunStrike(data);
                        break;
                    case "forge spirit":
                        ForgeSpirit(data);
                        break;
                    case "cold snap":
                        ColdSnap(data);
                        break;
                }

                ForgeSpiritAttack(data);
                EndGameCheck(data);

                BossAttack(data);
                EndGameCheck(data);

                Console.WriteLine(" ");
                if(data["ColdSnapTime"] >0 ){
                    data["ColdSnapTime"] -= 1;
                }
                turn++;
            }
            Console.ReadLine();
        }

        public static void SpellList()
        {
            Console.WriteLine("Forge spirit – призывает огненного духа для нанесения атаки (Отнимает 100 хп игроку) ");
            Console.WriteLine("Haganzakura (Может быть выполнен только после призыва онгенного духа) - наносит 100 ед. урона, дух при этом умирает ");
            Console.WriteLine("Sun strike - призывает луч света наносящий с вероятностью в 40% 200 урона(После использования cold snap на один ход шанс попадания увеличивается до 80%)");
            Console.WriteLine("Cold snap - Уменьшает атаку противника на 20% на 3 хода");
        }
        public static Dictionary<string, int> ColdSnap(Dictionary<string, int> data)
        {
            data["ColdSnapTime"] = 3;
            return data;
        }
        public static Dictionary<string, int> Haganzakura(Dictionary<string, int> data)
        {
            if(data["ForgeSpirit"] > 0)
            {
                Console.WriteLine("Пожертвова собой один forge spirit нанес 100 урона");
                data["BossHp"] -= 100;
                data["ForgeSpirit"] -= 1;
            }
            return data;
        }
        public static Dictionary<string, int> BossAttack(Dictionary<string, int> data)
        {
            var rnd = new Random();
            var attack = rnd.Next(80, 150);
            Console.WriteLine("Босс нанес {0} урона",attack);
            if (data["ColdSnapTime"] > 0)
            {
                data["PlayerHp"] -= (attack * 20 / 100);
            }
            else {
                data["PlayerHp"] -= attack;
            }
            return data;
        }
        public static Dictionary<string, int> SunStrike(Dictionary<string, int> data)
        {
            var rand = new Random();
            var attackChance = rand.Next(0, 100);
            if (data["ColdSnapTime"] > 0)
            {
                if (attackChance <= 80)
                {
                    Console.WriteLine("Попадание! Sun strike нанес 200 урона");
                    data["BossHp"] -= 200;
                }
            } else {
                if (attackChance <= 40)
                {
                    Console.WriteLine("Попадание! Sun strike нанес 200 урона");
                    data["BossHp"] -= 200;
                }
            }
            return data;
        }
        public static Dictionary<string, int> ForgeSpiritAttack(Dictionary<string, int> data)
        {
            Console.WriteLine("Атаки forge spirit наносят {0} урона", data["ForgeSpirit"] * 50);
            data["BossHp"] -= data["ForgeSpirit"] * 50;
            return data;
        }
        public static Dictionary<string,int> ForgeSpirit(Dictionary<string,int> data)
        {
            data["PlayerHp"] -= 100;
            data["ForgeSpirit"] += 1;
            return data;
        }
        public static string WinCheck(Dictionary<string, int> data)
        {
            if (data["PlayerHp"] <= 0)
            {
                return "босс";
            }
            if (data["BossHp"] <= 0)
            {
                return "игрок";
            }
            return "никто";
        }
        public static void EndGameCheck(Dictionary<string, int> data)
        {
            var winner = WinCheck(data);
            if (winner != "никто")
            {
                Console.WriteLine("Победил " + winner);
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
        
    }
}
