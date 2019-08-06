using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLesson1Dz2
{
    class Program
    {
        static Reader Creating()
        {
            Reader reader;
            List<Person> people=new List<Person>();
            Console.WriteLine("Произвести настройку персонажей (1-да, 2-автоматически):");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                do
                {
                    Console.Clear();
                    foreach (var p in people)
                        Console.WriteLine(p.Name);
                    Console.WriteLine("\n1-добавить персонажа, 2-удалить, 3-закончить настройку :");
                    i = int.Parse(Console.ReadLine());
                    if (i == 1)
                        _Add(people);
                    if (i == 2)
                        _Delete(people);
                } while (i != 3);
            }
            else
                people = _Initialization();
            reader = new Reader(people);
            Console.Clear();
            Console.WriteLine("Персонажи в случайном порядке?(1-да, 2-нет):");
            i = int.Parse(Console.ReadLine());
            reader._Random = i == 1;
            Console.Clear();
            Console.WriteLine("Всегда счастливый конец?(1-да, 2-нет):");
            i = int.Parse(Console.ReadLine());
            reader._HappyEnd = i == 1;
            return reader;
        }

        //Add new person.
        static void _Add(List<Person> people)
        {
            Console.Clear();
            Console.WriteLine("1-мышка, " +
                              "2-жабка, " +
                              "3-зайчик,\n" +
                              "4-лисичка, " +
                              "5-волк, " +
                              "6-медведь,\n" +
                              "7-отмена");
            var i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    people.Add(new Mouse(_GetName()));
                    break;
                case 2:
                    people.Add(new Frog(_GetName()));
                    break;
                case 3:
                    people.Add(new Rabbit(_GetName()));
                    break;
                case 4:
                    people.Add(new Fox(_GetName(), _GetMass()));
                    break;
                case 5:
                    people.Add(new Wolf(_GetName(), _GetMass()));
                    break;
                case 6:
                    people.Add(new Bear(_GetName(), _GetMass(), _GetHeight()));
                    break;
            }
        }

        static string _GetName()
        {
            Console.Clear();
            Console.WriteLine("Имя:");
            return Console.ReadLine();
        }

        static int _GetMass()
        {
            Console.Clear();
            Console.WriteLine("Вес: ");
            return int.Parse(Console.ReadLine());
        }

        static int _GetHeight()
        {
            Console.Clear();
            Console.WriteLine("Рост: ");
            return int.Parse(Console.ReadLine());
        }

        //Delete person
        static void _Delete(List<Person> people)
        {
            if (people.Count > 0)
            {
                Console.WriteLine("Индекс:");
                var i = int.Parse(Console.ReadLine());
                people.RemoveAt(i);
            }
        }
        
        //Basic order
        static List<Person> _Initialization()
        {
            var people = new List<Person>();
            people.Add(new Mouse("норушка"));
            people.Add(new Frog("квакушка"));
            people.Add(new Fox("сестричка", 100));
            people.Add(new Wolf("братик", 150));
            people.Add(new Bear("косолапый", 500, 10));
            return people;
        }

        static void Main(string[] args)
        {
            Reader reader = Creating();
            var consoleWriter = new ConsoleWriter(ConsoleColor.White, ConsoleColor.Black);
            reader.StartReading(consoleWriter);
           
        }
    }
}
