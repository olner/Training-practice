using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] name = new string[] { };
            string[] job = new string[] { };
            while (true)
            {
                Console.WriteLine("Отдел кадров");
                Console.WriteLine("1 - добавить досье");
                Console.WriteLine("2 - вывести все досье");
                Console.WriteLine("3 - удалить досье");
                Console.WriteLine("4 - поиск по фамилии");
                Console.WriteLine("5 - выход из программы");
                Console.Write("Выберите пункт меню: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        name = AddName(name);
                        job = AddJob(job);
                        break;
                    case "2":
                        Console.Clear();
                        PrintPersons(name, job);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Удаление досье");
                        Console.Write("Введите номер досье которое хотите удалить :");
                        var index = int.Parse(Console.ReadLine())-1;
                        name = Delete(name, index);
                        job = Delete(job, index);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Поиск по фамилии");
                        Console.Write("Введите фамилию: ");
                        Search(name, job, Console.ReadLine());
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static string[] AddName(string[] name)
        {
            Console.WriteLine("Добавление досье: ");
            Console.Write("Введите фамилию: ");
            var surName = Console.ReadLine(); 
            Console.Write("Введите имя: ");
            var firstName = Console.ReadLine(); 
            Console.Write("Введите отчество: ");
            var thirdName = Console.ReadLine(); 
            Array.Resize(ref name, name.Length + 1);
            //Console.WriteLine(name.Length);
            name[name.Length - 1] = surName + " " + firstName + " " + thirdName;
            return name;
            //Array.ForEach(name, Console.WriteLine);
            //Console.ReadLine();
        }
        public static string[] AddJob(string[] job)
        {
            Console.Write("Введите должность: ");
            var employeeJob = Console.ReadLine();
            Array.Resize(ref job, job.Length + 1);
            //Console.WriteLine(job.Length);
            job[job.Length - 1] = employeeJob;
            return job;
        }
        public static void PrintPersons(string[] name,string[] job)
        {
            if (name.Length > 0)
            {
                for (var i = 0; i < name.Length; i++)
                {
                    Console.WriteLine((i + 1) + "-" + "     " + name[i] + "     " + job[i]);
                }
            }
            else
            {
                Console.WriteLine("Здесь нет записей");
            }
        }
        static string[] Delete(string[] array, int indexToDelete)
        {
            if (array.Length == 0) return array;
            if (array.Length <= indexToDelete) return array;

            var output = new string[array.Length - 1];
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i == indexToDelete) continue;
                output[counter] = array[i];
                counter++;
            }

            return output;
        }
        static void Search(string[] name, string[] job,string surName)
        {
            if (name.Length > 0)
            {
                var counter = 0;
                for (var i = 0; i < name.Length; i++)
                {
                    if (name[i].Contains(surName))
                    {
                        Console.WriteLine((i + 1) + "-" + "     " + name[i] + "     " + job[i]);
                        counter++;
                    }
                }
                Console.WriteLine("Кол-во людей с фамилией {0} - {1}",surName,counter);
            }
            else
            {
                Console.WriteLine("Нет человека с такой фамилией");
            }
        }
    }
}
