using System;
using System.Collections.Generic;

namespace Quests
{
    class Program
    {
        static void Main(string[] args)
        {
            var камушек = new Камень() { ХП = 100, Цвет = "Прозрачный"};
            var бот = new Бот() { ХП = 100 };
            var персонаж = new Персонаж() { ХП = 100 };
            
            var телеса = new List<Тело>();
            телеса.Add(камушек);
            телеса.Add(бот);
            телеса.Add(персонаж);

            var гопота = new List<Живой>();
            гопота.Add(бот);
            гопота.Add(персонаж);
            
            foreach (var гопник in гопота)
            {
                гопник.ВыполнитьТакт(телеса);
            }
        }
    }
    interface Живой { void ВыполнитьТакт(List<Тело> телеса); }
    abstract class Тело { public decimal ХП; }
    class Камень : Тело
    {
        public string Цвет { get; set; }
    }

    class Бот : Тело, Живой
    {
        public void ВыполнитьТакт(List<Тело> телеса)
        {
            foreach (var i in телеса)
            {
                if (i is Персонаж)
                    i.ХП -= 30;
            }
        }
    }

    class Персонаж : Тело, Живой
    {
        public void ВыполнитьТакт(List<Тело> телеса)
        {
            foreach (var i in телеса)
            {
                if (i is Бот)
                    i.ХП -= 40;
            }
        }

    public decimal Богатство { get; set; }
    }
}
    



