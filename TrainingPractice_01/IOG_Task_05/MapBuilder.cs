using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_05
{
    public static class MapBuilder
    {
        public static char[,] ReadMap(string mapName, out int performerX, out int performerY)
        {
            performerX = 0;
            performerY = 0;

            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '■')
                    {
                        performerX = i;
                        performerY = j;
                    }
                }
            }
            return map;
        }
        public static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static char[,] BanditSpawn(char[,] map)
        {
            Random rnd = new Random();
            for (int i = 2; i < map.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if(rnd.Next(0,100) < 5 & map[i,j] != '║' & map[i, j] != '═' & map[i,j] != '╬' & map[i,j] != '╣' & map[i,j] != '╠' & map[i,j] != '╦' & map[i,j] != '╗' & map[i,j] != '╔' & map[i,j] != '╩' & map[i,j] != '╚')
                    {
                        map[i, j] = '*';
                    }
                }
            }
            return map;
        }
    }
}
