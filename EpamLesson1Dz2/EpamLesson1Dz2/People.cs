using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLesson1Dz2
{
    abstract class Person : IPerson
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        // Person go to home.
        public abstract string Move();

        // Person stoped hear a home.
        public abstract string Stop();

        // Person enter in home.
        public abstract string Enter();

        // Person can crash a home.
        public abstract bool Crashed();
    }

    class Mouse : Person
    {
        public Mouse(string name) : base("Мышка-" + name)
        {
        }

        public override bool Crashed()
        {
            return new Random().Next(10) == 1;
        }

        public override string Enter()
        {
            string[] actions = { "Запрыгнула", "Забежала" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Бежала", "Шла мимо", "Проходила", "Идет", "Бежит" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Остановилась", "Посмотрела", "Подумала" };
            return actions[new Random().Next(actions.Length)];
        }
    }

    class Frog : Person
    {
        public Frog(string name) : base("Лягушка-" + name)
        {
        }

        public override bool Crashed()
        {
            return new Random().Next(8) == 0;
        }

        public override string Enter()
        {
            string[] actions = { "Прыгнула", "Вошла", "Забралась" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Прискакала", "Проходила", "Скачет", "Бежит" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Подпрыгнула", "Посмотрела" };
            return actions[new Random().Next(actions.Length)];
        }
    }

    class Rabbit : Person
    {
        public Rabbit(string name) : base("Зайчик-" + name)
        {
        }

        public override bool Crashed()
        {
            return new Random().Next(6) == 0;
        }

        public override string Enter()
        {
            string[] actions = { "Прыгнул", "Вошел", "Забежал" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Бежал", "Идет" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Подошел", "Останавливается" };
            return actions[new Random().Next(actions.Length)];
        }
    }

    class Wolf : Person
    {
        private int _Mass;

        public Wolf(string name,int mass) : base("Волчок-" + name)
        {
            _Mass = mass;
        }

        public override bool Crashed()
        {
            return _Mass/2*3< (new Random().Next(_Mass));
        }

        public override string Enter()
        {
            string[] actions = { "Вошел", "Залез" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Бежал", "Проходил" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Подошел", "Остановился" };
            return actions[new Random().Next(actions.Length)];
        }
    }

    class Fox : Person
    {

        private int _Mass;

        public Fox(string name, int mass) : base("Лисичка-" + name)
        {
            _Mass = mass;
        }

        public override bool Crashed()
        {
            return _Mass * (new Random().Next(_Mass)) < _Mass/3;
        }

        public override string Enter()
        {
            string[] actions = { "Вошла", "Забралась" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Пришла", "Бежит" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Остановилась", "Посмотрела" };
            return actions[new Random().Next(actions.Length)];
        }
    }

    class Bear : Person
    {
        private int _Mass;

        private int _Height;

        public Bear(string name, int mass, int height) : base("Медведь-" + name)
        {
            _Mass = mass;
            _Height = height;
        }

        public override bool Crashed()
        {
            return new Random().Next(_Mass*_Height)> _Mass*_Height/2;
        }

        public override string Enter()
        {
            string[] actions = { "Залез", "Вошел", "Забрался" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Пробирается", "Идет" };
            return actions[new Random().Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Посмотрел", "Подошел" };
            return actions[new Random().Next(actions.Length)];
        }
    }
}
