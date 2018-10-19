using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.GameObjects
{
    public class Character : GameObject, Interfaces.IDisplayable
    {
        public Character(string name, int max_health, Maps.Map map) : base(name, map)
        {
            this.Health = new Components.Health(this, max_health);
            this.Display = new Components.Display(this, '@', Color.White, Color.Black);
            this.RegisterComponent(this.Health);
            this.RegisterComponent(this.Display);
        }

        public Components.Health Health { get; set;}
        public Components.Display Display { get; set; }
    }
}
