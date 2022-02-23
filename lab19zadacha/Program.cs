using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Модель компьютера  характеризуется  кодом  и  названием  марки компьютера,
    типом  процессора, частотой  работы  процессора, объемом оперативной памяти,
    объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера
    в условных единицах и количеством экземпляров, имеющихся в наличии.
    Создать список, содержащий 6-10 записей с различным набором значений характеристик.
    Определить:
-все компьютеры с указанным процессором. Название процессора запросить у пользователя;
-все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
-вывести весь список, отсортированный по увеличению стоимости;
-вывести весь список, сгруппированный по типу процессора;
-найти самый дорогой и самый бюджетный компьютер;
-есть ли хотя бы один компьютер в количестве не менее 30 штук?*/

namespace lab19zadacha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer (){Id=1, Name="HP", Processor="CoreI5", Frequency=31, RAM = 8, HDD=512, VideoRAM = 4, Price=70, Numbers=10 },
                new Computer (){Id=2, Name="Acer", Processor="CoreI5",Frequency=27, RAM = 8,HDD=256, VideoRAM = 8,Price=100, Numbers=30 },
                new Computer (){Id=3, Name="Dell", Processor="CoreI5",Frequency=27, RAM = 8,HDD=256, VideoRAM = 4,Price=73, Numbers=10 },
                new Computer (){Id=4, Name="AppleMcB", Processor="Apple",Frequency=32, RAM = 8,HDD=256,VideoRAM = 0,Price=85, Numbers=5 },
                new Computer (){Id=5, Name="Lenovo", Processor="Ryzen5",Frequency=33, RAM = 16,HDD=512,VideoRAM = 6, Price=135, Numbers=3 },
                new Computer (){Id=6, Name="Asus", Processor="Ryzen7",Frequency=29, RAM = 8,HDD=512, VideoRAM = 4,Price=79, Numbers=20 },
                new Computer (){Id=7, Name="Lenovo", Processor="Ryzen3",Frequency=26,RAM = 8, HDD=512, VideoRAM = 0,Price=41, Numbers=50 }
            };
            Console.Write("Укажите серию процессора (CoreI5, Apple, Ryzen3, Ryzen5, Ryzen7): ");
            string processor = Console.ReadLine();
            List<Computer> computers1 = computers.Where(x => x.Processor == processor).ToList();
            Print(computers1);
            Console.ReadKey();

            Console.Write("Укажите объем памяти ОЗУ (RAM), Гб: ");
            int memRAM = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = computers.Where(x => x.RAM >= memRAM).ToList();
            Print(computers2);
            Console.ReadKey();

            Console.WriteLine("Перечень по возрастанию цены: ");
            List<Computer> computers3 = computers.OrderBy(x => x.Price).ToList();
            Print(computers3);
            Console.ReadKey();

            Console.WriteLine("Группировка по процессору: "); 
            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(x => x.Processor);
            foreach (IGrouping<string, Computer> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"{c.Id}-{c.Name}-{c.Processor}-{c.Frequency}-{c.RAM}-{c.HDD}-{c.VideoRAM}-{c.Price}-{c.Numbers}");
                }
            }

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Самая низкая цена: ");
            Computer computer5 = computers.OrderBy(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{computer5.Id}-{computer5.Name}-{computer5.Processor}-{computer5.Frequency}-{computer5.RAM}-{computer5.HDD}-{computer5.VideoRAM}-{computer5.Price}-{computer5.Numbers}");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Самый дорогой: ");
            Computer computer6 = computers.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{computer6.Id}-{computer6.Name}-{computer6.Processor}-{computer6.Frequency}-{computer6.RAM}-{computer6.HDD}-{computer6.VideoRAM}-{computer6.Price}-{computer6.Numbers}");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Есть ли каких нибудь больше 40 штук на складе: ");
            Console.WriteLine(computers.Any(x => x.Numbers > 40));
            Console.WriteLine();
            Console.WriteLine("Ноутбуки с жестким диском 512 Гб: ");
            List<Computer> computers8 = computers.Where(x => x.HDD == 512).ToList();
            Print(computers8);
            Console.ReadKey();

        }
        static void Print(List<Computer> computers)
        {
            foreach (Computer c in computers)
            {
                Console.WriteLine($"{c.Id}-{c.Name}-{c.Processor}-{c.Frequency}-{c.RAM}-{c.HDD}-{c.VideoRAM}-{c.Price}-{c.Numbers}");
            }
            Console.WriteLine();
        }
    }
    class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Processor { get; set; }
        public int Frequency { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int VideoRAM { get; set; }
        public int Price { get; set; }
        public int Numbers { get; set; }
    }
}
