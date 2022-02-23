using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab19
{
    class Door
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Cost { get; set; }
        public string Manufacturer { get; set; }
        public string Material { get; set; }
        public List<string> Composition { get; set; }
    }
    class MyClass
    {
        public string Mater { get; }
        public string Manuf { get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Door> listDoor = new List<Door>()
            {
                new Door(){Id=1, Width = 1000, Height = 2000, Cost = 10000, Manufacturer = "Zarya",Material = "Metal",
                     Composition = new List<string>(){ "Polotno","Korobka","Ruchka","Petli","Glazok","Zamok"} },
                new Door(){Id=2, Width = 2000, Height = 3000, Cost = 20000, Manufacturer = "KRALutch",Material = "Derevo",
                     Composition = new List<string>(){ "Polotno","Korobka","Ruchka","Petli"} },
                new Door(){Id=3, Width = 700, Height = 3000, Cost = 15000, Manufacturer = "Zavod",Material = "Plastic",
                     Composition = new List<string>(){ "Polotno","Korobka","Ruchka","Petli","Zamok"} },
                new Door(){Id=4, Width = 800, Height = 2000, Cost = 25000, Manufacturer = "Zavety",Material = "Derevo",
                     Composition = new List<string>(){ "Polotno","Korobka"} },
                new Door(){Id=5, Width = 1500, Height = 2100, Cost = 30000, Manufacturer = "Zarya",Material = "Metal",
                     Composition = new List<string>(){ "Polotno","Korobka","Ruchka","Petli","Glazok","Zamok"} },
                new Door(){Id=6, Width = 1200, Height = 1900, Cost = 5000, Manufacturer = "Zavod",Material = "Plastic",
                     Composition = new List<string>(){ "Polotno","Korobka","Ruchka","Petli"} },
            };
            //обычный перебор
            /* List<Door> doors = new List<Door>();
             foreach (Door d in listDoor)
             {
                 if (d.Material == "Derevo")
                 {
                     doors.Add(d);
                 }
             }*/

            /*IEnumerable<Door> doors = from d in listDoor
                                      where d.Material == "Derevo"
                                      select d;*/

            /* List<Door> doors = (from d in listDoor  //sql подобный синтаксис
                                 where d.Material == "Derevo"
                                 select d).ToList();*/

            /*List<Door> doors = listDoor // методы расширения
                .Where(d => d.Material == "Derevo")
                .ToList();*/

            /*Door doors = listDoor //находит первое значение указан хар-ки и возвращает его Id
                .Where(d => d.Material == "Derevo")
                .First();
Console.WriteLine( doors.Id);*/


            /*List<Door> doors = (from d in listDoor // выбор позиций с задан размерами
                                where d.Height > 2000 // d.Width>1000 или
                                where d.Width >1000
                                select d).ToList();*/

            /*List<Door> doors = (from d in listDoor  //sql подобный синтаксис - выбор двери с глазком
                                from p in d.Composition
                                where p== "Glazok"
                               select d).ToList();*/

            /*IEnumerable<Door> doors = listDoor //содержит глазок другим способом
                .Where(d => d.Composition.Contains("Glazok"))
                .ToList();*/

            /*List<string> doors = (from d in listDoor //вывод только произвродителей
                                    select d.Manufacturer).ToList();*/

            /* List<string> doors = listDoor //вывод производителей
                   .Select(d => d.Manufacturer)
                 .Distinct()   //убирает повторяющиеся значения
                   .ToList();*/

            /* var doors = listDoor //вывод производителей и материала
                 .Select(d => new
                 {
                     Mater = d.Material,
                     Manuf = d.Manufacturer
                 })
              // .Distinct()   //убирает повторяющиеся значения
                 .ToList();*/

            /*var doors = (from d in listDoor //вывод производителей и материала втрой способ
                select new {
                    Mater = d.Material,
                    Manuf = d.Manufacturer
                }).ToList();*/

            /*var doors = (from d in listDoor //сортировка по цене по возраст
                         orderby d.Cost, d.Id
                         select d).ToList();*/

            /*var doors = listDoor //сортировка по цене по возраст  при помощи метод расширения
                 .OrderBy(d => d.Cost)
                 .ToList();*/

            /*var doors = listDoor //кол-во дверей дороже 10000
                .Where(d => d.Cost>10000)
                .Count();
            Console.WriteLine(doors); //возвращаемой значение - число дверей*/

            var doors = (from d in listDoor //кол-во дверей дороже 10000 
                         where d.Cost>10000
                         select d).Count();
            Console.WriteLine(doors);

            /*foreach (Door d in doors)
               Console.WriteLine($"{d.Id} {d.Width} {d.Height} {d.Cost} {d.Manufacturer} {d.Material}");*/

            /*foreach (string s in doors)
            {
                Console.WriteLine(s);
            }*/

            /*foreach (var s in doors)
            {
                Console.WriteLine($"{s.Mater},{s.Manuf}");
            }*/

            /*foreach (var d in doors)
                Console.WriteLine($"{d.Id} {d.Width} {d.Height} {d.Cost} {d.Manufacturer} {d.Material}");*/

            Console.ReadKey();
        }
    }
}
