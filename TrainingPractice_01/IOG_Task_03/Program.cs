using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "password";
            var counter = 0;
            Console.WriteLine("Введите пароль");
            while (true)
            {
                if(Console.ReadLine() == password)
                {
                    Console.WriteLine("Веведено секретное сообщение");
                    break;
                }
                counter++;
                if(counter == 3)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Пароль неверный. Пожалуйста, введите пароль снова");
            }
            Console.ReadLine();
        }
    }
}
