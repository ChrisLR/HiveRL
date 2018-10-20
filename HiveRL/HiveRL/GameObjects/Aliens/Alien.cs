using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.GameObjects.Aliens
{
    public class Alien : Character
    {
        public Alien(string name, int max_health, Maps.Map map) : base(name, max_health, map)
        {

        }
    }
}
