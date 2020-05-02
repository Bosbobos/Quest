using System;
using System.Collections.Generic;

namespace Quests
{
    class Program
    {
        static void Main(string[] args)
        {
            var чуваки = new List<Родитель>();

            var чувак1 = new Родитель();
            чуваки.Add(чувак1);
            чуваки.Add(new Наследник1() { Номер = 2, Цвет = "Зелёный" });
            чуваки.Add(new Наследник2() { Номер = 2, Богатство = 5.72m });

            foreach (var чувак in чуваки)
            {
                Console.WriteLine($"Номер чувака: {чувак.Номер}");

                if (чувак is Наследник1)
                    Console.WriteLine($"Чувак Наследник1 и его цвет: {(чувак as Наследник1).Цвет}");

                if (чувак is Наследник2)
                    Console.WriteLine($"Чувак Наследник2 и его богаство: {(чувак as Наследник2).Богатство}");
            }
        }
    }
    
    class Родитель
        {
            public int Номер { get; set; }
        }

    class Наследник1 : Родитель
    {
        public string Цвет { get; set; } // У первого наследника есть цвет
    }

    class Наследник2 : Родитель
    {
        public decimal Богатство { get; set; } // А у второго - богатство
    }

     
    


}
