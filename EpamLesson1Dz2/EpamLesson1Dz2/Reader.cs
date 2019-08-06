using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLesson1Dz2
{
    /// <summary>
    /// Class read story.
    /// </summary>
    class Reader
    {
        // Person will be selected randomly or consistently.
        public bool _Random { get; set; } = false;

        // End of story is happy constantly.
        public bool _HappyEnd { get; set; } = false;

        // Contains everyone person in story.
        public List<Person> People { get; private set; }

        public Reader()
        {
            People = new List<Person>();
        }

        public Reader(List<Person> people)
        {
            People = people;
        }

        // Void reads and writes story.
        public void StartReading(IWriter writer)
        {
            // Contains people in home.
            var inHome = new List<Person>();
            // Home had crashed.
            var crash = false;
            writer.Write("Стоит в поле теремок.");
            while (People.Count != inHome.Count && !crash)
            {
                var personIndex = 0;
                var person = GetPerson(inHome, out personIndex);
                _Moving(person, writer);
                _Answer(inHome, person, writer, out crash);
                inHome.Add(person);
            }
            if (crash)
                _Crashing(inHome, writer);
            else
                _Happy(writer);
            writer.Write("Конец.");
        }

        // When home is crashing.
        private void _Crashing(List<Person> people, IWriter writer)
        {
            writer.Write("Вдруг, затрещал теремок, упал набок и весь развалился");
            StringBuilder refugees = new StringBuilder("Еле-еле удалось выбраться из него: ");
            foreach (var p in people)
                refugees.Append($"{p.Name},");
            refugees.Remove(refugees.Length - 1, 1);
            refugees.Append(" - в целости и сохранности.");
            writer.Write(refugees.ToString());
            if(people.Count>1)
            writer.Write("Принялись они бревна носить, доски пилить — новый теремок строить. " +
                         " Лучше прежнего получился!");

        }

        // Happy end
        private void _Happy(IWriter writer)
        {
            writer.Write("Стоял теремок еще много лет и все жили в нем долго и счастливо.");
        }

        // Person go to home.
        private void _Moving(Person person,IWriter writer)
        {
            var action = person.Move() + " " + person.Name + ".";
            writer.Write(action);
            action = $"{person.Stop()} и спрашивает: ";
            writer.Write(action);
            writer.Write("--- Терем - теремок! Кто в тереме живет?");
        }

        // People in home are answering.
        private void _Answer(List<Person> inHome, Person person, IWriter writer, out bool crash)
        {
            if (inHome.Count == 0)
            {
                writer.Write("Никто не отзывается");
                writer.Write($"{person.Enter()} {person.Name} и живет в теремке.");
            }
            else
            {
                foreach (var i in inHome)
                    writer.Write($"--- Я, {i.Name}!");
                writer.Write("--- А ты кто?");
                writer.Write($"--- А я - {person.Name}.");
                writer.Write(inHome.Count > 1 ? "--- Иди к нам жить" : "--- Иди ко мне жить");
                writer.Write($"{person.Enter()} в теремок.");
            }
            crash = !_HappyEnd? person.Crashed():false;
            if (!crash&&inHome.Count>0)
                writer.Write($"Стали они в{inHome.Count + 1}-ем жить.");

        }

        //Takes a new person
        private Person GetPerson(List<Person> inHome,out int index)
        {
            if(!_Random)
            {
                index = 0;
                return People.First(p => !inHome.Contains(p));
            }
            else
            {
                var freePeople = People.Where(p => !inHome.Contains(p)).ToList();
                                
                index = new Random().Next(freePeople.Count);
                return freePeople[index];
            }
        }
    }
}
