using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOG_Task_05
{
    class Movement
    {
        public static char[,] PlayerMove(char[,] map, int[] playerPositin, Player player)
        {
            switch(Console.ReadKey().Key) {
                case ConsoleKey.RightArrow:
                    try 
                    {
                        if (map[playerPositin[0], playerPositin[1] +1 ] == ' ' | map[playerPositin[0], playerPositin[1] + 1] == '·' | map[playerPositin[0], playerPositin[1] + 1] == '*')
                        {
                            map[playerPositin[0], playerPositin[1]] = '·';
                            CellCheck(map[playerPositin[0], playerPositin[1] + 1],player);
                            map[playerPositin[0], playerPositin[1] += 1] = '■';
                        }
                        else
                        {
                            Console.WriteLine("Там находится стена");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Вы не можете выйти за границы карты");
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    try
                    {
                        if (map[playerPositin[0], playerPositin[1] - 1] == ' ' | map[playerPositin[0], playerPositin[1] - 1] == '·' | map[playerPositin[0], playerPositin[1] - 1] == '*')
                        {
                            map[playerPositin[0], playerPositin[1]] = '·';
                            CellCheck(map[playerPositin[0], playerPositin[1] - 1],player); 
                            map[playerPositin[0], playerPositin[1] -= 1] = '■';
                        }
                        else
                        {
                            Console.WriteLine("Там находится стена");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Вы не можете выйти за границы карты");
                    }
                    break;
                    case ConsoleKey.UpArrow:
                    try
                    {
                        if (map[playerPositin[0] - 1, playerPositin[1]] == ' ' | map[playerPositin[0] - 1, playerPositin[1]] == '·' | map[playerPositin[0] - 1, playerPositin[1]] == '*')
                        {
                            map[playerPositin[0], playerPositin[1]] = '·';
                            CellCheck(map[playerPositin[0] - 1, playerPositin[1]],player);
                            map[playerPositin[0] -= 1, playerPositin[1]] = '■';
                        }
                        else
                        {
                            Console.WriteLine("Там находится стена");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Вы не можете выйти за границы карты");
                    }
                    break;
                case ConsoleKey.DownArrow:
                    try
                    {
                        if (map[playerPositin[0] + 1, playerPositin[1]] == ' ' | map[playerPositin[0] + 1, playerPositin[1]] == '·' | map[playerPositin[0] + 1, playerPositin[1]] == '*')
                        {
                            map[playerPositin[0], playerPositin[1]] = '·';
                            CellCheck(map[playerPositin[0] + 1, playerPositin[1]], player);
                            map[playerPositin[0] += 1, playerPositin[1]] = '■';
                        }
                        else
                        {
                            Console.WriteLine("Там находится стена");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Вы не можете выйти за границы карты");
                    }
                    break;
                case ConsoleKey.Spacebar:
                    player.HP = 100;
                    break;
            }
            return map;
        }
        public static void ExitCheck(int[] playerPosition)
        {
            if(playerPosition[0] == 29 & playerPosition[1] == 23)
            {
                Console.WriteLine("Вы победили!");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
        public static void CellCheck(char cell,Player player)
        {
            switch (cell)
            {
                case '*':
                    Battle.BattleProcces(player);
                    break;
            }
        }
    }
}
