using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_05
{
    class Program
    {
        static void Main(string[] args)
        { //(y)29 --- (x)23
            int performerX;
            int performerY;
            char[,] map = MapBuilder.ReadMap("level1", out performerX, out performerY);
            var playerPosition = new[] { performerX, performerY };
            Player player = new Player(100, 100);
            Player.HealthBar(player.HP, player.maxHP);
            Console.WriteLine(" ");
            map = MapBuilder.BanditSpawn(map);
            MapBuilder.DrawMap(map);
            while (true)
            {
                Movement.PlayerMove(map, playerPosition,player);
                Console.Clear();
                Player.HealthBar(player.HP,player.maxHP); Console.WriteLine(" ");
                MapBuilder.DrawMap(map);


                Movement.ExitCheck(playerPosition);

                //Технические данные
                Console.WriteLine(playerPosition[0] + "------" + playerPosition[1]);
                Console.WriteLine(map.GetLength(0) + "------" + map.GetLength(1));
                //Console.Clear();
            }
            Console.ReadLine();
        }
    }

}
