using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.Attacks
{
    public class Claw : Attack
    {
        public Claw(int attackRating = 2, int staminaCost = 1) : base("Claw", attackRating, staminaCost)
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
