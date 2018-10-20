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
        
        public Combat(int maxAwareness, int maxStamina, GameObject host) : base("Combat", host)
        {

        }

    }
}
