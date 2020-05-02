using System;
using System.Collections.Generic;

namespace Quests
{
    class Program
    {
        static void Main(string[] args)
        {
            var камушек = new Камень() { ХП = 100, Цвет = "Прозрачный"};
            var гопота = new List<Атаковальщик>();
            гопота.Add(new Бот() { ХП = 100 });
            гопота.Add(new Персонаж() { ХП = 100 });

            foreach(var гопник in гопота)
            {
                гопник.Атаковать(камушек);
                Console.WriteLine(камушек.ХП);
            }
        }
    }
    interface Атаковальщик { void Атаковать(Тело тело); }
    abstract class Тело { public decimal ХП; }
    class Камень : Тело
    {
        public string Цвет { get; set; }
    }

    class Бот : Тело, Атаковальщик
    {
        public void Атаковать(Тело тело)
        {
            тело.ХП -= 30;
        }
    }

    class Персонаж : Тело, Атаковальщик
    {
        public void Атаковать(Тело тело)
        {
            тело.ХП -= 40;
        }
        public decimal Богатство { get; set; }
    }
}
    



