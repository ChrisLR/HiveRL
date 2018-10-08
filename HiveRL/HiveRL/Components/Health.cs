using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.Components
{
    public class Health : ComponentBase
    {
        private int max;
        private int current;

        public Health(GameObject host, int MaxHealth) : base("Health", host)
        {
            this.max = MaxHealth;
            this.current = MaxHealth;
        }

        public void Damage(int amount)
        {
            this.current -= amount;
            if (this.current <= 0)
                this.current = 0;
        }

        public void Heal(int amount)
        {
            this.current += amount;
            if (this.current > this.max)
                this.current = this.max;
        }


        public int Current
        {
            get { return this.current; }
        }
        public int Max
        {
            get { return this.max; }
        }

        public bool IsDead
        {
            get { return this.current <= 0; }
        }
    }
}
