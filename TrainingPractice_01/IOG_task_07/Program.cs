using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа перемешивнаия массива");
            Console.Write("Введите кол-во элементов одномерного массива ");
            int[] mas = new int[int.Parse(Console.ReadLine())];
            var rnd = new Random();
            for (var i = 0;i < mas.Length; i++)
            {
                mas[i] = rnd.Next(1, 100);
            }
            Console.WriteLine("Массив до перемешивания");
            for (var i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            var shuffledMassive = Shuffle(mas);
            Console.WriteLine("Массив после перемешивания");
            for (var i = 0; i < shuffledMassive.Length; i++)
            {
                Console.WriteLine(shuffledMassive[i]);
            }
            Console.ReadLine();
        }
        static int[] Shuffle(int[] massive)
        {
            var mas = massive;
            Random rnd = new Random();

            for (int i = mas.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                int tmp = mas[j];
                mas[j] = mas[i];
                mas[i] = tmp;
            }
            return mas;
        }
    }
}
