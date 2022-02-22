using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            const  int price = 100;
            Console.WriteLine("Добро пожаловтаь в магазин");
            Console.WriteLine("Введите кол-во ваших денег:");
            var money = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите сколько хотите купить кристалов");
            var crystalToBuy = int.Parse(Console.ReadLine());
             
            int moneyAfterTrade = money - (crystalToBuy * price);
            try
            {
                int[] mas = new int[moneyAfterTrade];
                Console.WriteLine("Ваши кристалы "+crystalToBuy);
            }
            catch
            {
                Console.WriteLine("Ваши деньги " + money);
            }
            Console.ReadKey();
        }
    }
}
