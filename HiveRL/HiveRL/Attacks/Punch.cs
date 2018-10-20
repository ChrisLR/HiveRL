using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.Attacks
{
    public class Punch : Attack
    {
        public Punch(int attackRating = 1, int staminaCost = 1) : base("Punch", attackRating, staminaCost)
        {

        }

        public override void OnHit(GameObject attacker, GameObject defender)
        {
            // Message about Killing the Defender
        }

        public override void OnMiss(GameObject attacker, GameObject defender)
        {
            // Message about Missing the defender
        }

        public override void OnKill(GameObject attacker, GameObject defender)
        {
            // Message about Killing the defender
        }
    }
}
