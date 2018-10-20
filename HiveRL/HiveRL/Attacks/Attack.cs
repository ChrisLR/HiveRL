using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.Attacks
{
    public class Attack
    {
        public string Name;
        public int AttackRating;
        public int StaminaCost;

        public Attack(string name, int attackRating, int staminaCost)
        {
            this.Name = name;
            this.AttackRating = attackRating;
            this.StaminaCost = staminaCost;
        }

        public virtual void OnHit(GameObject attacker, GameObject defender)
        {
            // Here is mostly messages about hits but could apply additional effects
        }

        public virtual void OnMiss(GameObject attacker, GameObject defender)
        {
            // Here is mostly messages about misses but could apply additional effects
        }

        public virtual void OnKill(GameObject attacker, GameObject defender)
        {
            // Here is mostly messages about killing but could apply additional effects
        }
    }
}
