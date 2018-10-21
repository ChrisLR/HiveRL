using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.Components
{
    public class Combat : ComponentBase
    {
        // Combat in HiveRL must be brutal and focused on not getting hit.
        // Awareness allows to not get hit and is reduced by each attack
        //  This recovers slowly on resting out of combat.
        //  When it would be reduced to zero, the hit lands instead.

        // Stamina allows to attack and continue defending
        //  This recovers quickly both in and out of combat
        //  When this is reduced to zero, awareness cost is doubled and attacks are diminished to half

        // Aliens should have very high stamina and low awareness, 
        // they attack in a frenzy attempting to overwhelm their opponents
        // not making much efforts to avoid hits

        // Player will have the strength to finish fights quickly but will have to be careful
        // to avoid long fights, even when taking his opponents one by one.

        // Armor should take a single hit before being broken or void
        // Armor pieces should each give an advantage that is lost when broken
        // Each of these should not be replacable nor repairable
        // It places focus on maintaining awareness high at all times
        List<Attacks.Attack> naturalAttacks;

        public Combat(int maxAwareness, int maxStamina, GameObject host, List<Attacks.Attack> naturalAttacks = null) : base("Combat", host)
        {
            this.MaxAwareness = maxAwareness;
            this.CurrentAwareness = maxAwareness;
            this.MaxStamina = maxStamina;
            this.CurrentStamina = maxStamina;
            this.naturalAttacks = naturalAttacks ?? new List<Attacks.Attack>();
        }

        public int MaxAwareness { get; protected set; }
        public int CurrentAwareness { get; protected set; }
        public int MaxStamina { get; protected set; }
        public int CurrentStamina { get; protected set; }

        public void Attack(GameObject target)
        {
            // See if host has any weapons equipped
            //  If any, use the attack provided by the weapon
            // Else select a natural attack

            //TODO Use equipment Component to fetch Any Weapon and its associated attack

            //Since we have none, use natural attacks
            var attackCount = this.naturalAttacks.Count() - 1;
            var randomAttackIndex = Program.Random.Next(attackCount);
            var attack = this.naturalAttacks[randomAttackIndex];

            // TODO Use Stamina or Reduce AttackRating if not enough


            var defenderCombat = (Combat)target.GetComponent(typeof(Combat));
            if(defenderCombat.CurrentAwareness > attack.AttackRating)
            {
                defenderCombat.CurrentAwareness -= attack.AttackRating;
                attack.OnMiss(this.Host, target);
            }
            else
            {
                // TODO Use equipment to fetch any armor blocking the hit
                // TODO Then apply attack.OnHit(this.Host, target);
                // TODO Else
                attack.OnKill(this.Host, target);
                var corpse = new GameObjects.Corpse(target, target.Location.Map);
            }
        }
    }
}
