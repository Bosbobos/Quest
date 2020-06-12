using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public abstract class Body
    {
        public delegate void IGotDamage(decimal damage);
        public delegate void IDied(Body body);

        public event IGotDamage IGotDamageEvent;
        public event IDied IDiedEvent;
        

        private int x; 
        public int X {
            get
            {
                return x;
            } 
            set
            {
                if (value >= 0)
                    x = value;
                else
                    x = 0;
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0)
                    y = value;
                else
                    y = 0;
            }
        }

        private decimal hp = 100m;
        public decimal Hp
        {
            get
            {
                return hp;
            }
            set
            {
                IGotDamageEvent?.Invoke(hp - value);

                if (value > 0)
                    hp = value;
                else
                {
                    hp = 0;
                    IDiedEvent?.Invoke(this);
                }                
            }
        }

        public Guid Id = Guid.NewGuid();

        public decimal Armour { get; set; }
        public Body(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }

        public abstract void AccomplishTakt(List<Body> bodies);
    }
}
