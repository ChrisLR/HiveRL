using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.GameObjects
{
    public class Wall : Tile
    {
        public Wall(int max_health, Map map, int x, int y): base("wall", map)
        {
            this.Health = new Components.Health(this, max_health);
            this.Display = new Components.Display(this, '#', Color.Gray, Color.Black);
            this.RegisterComponent(this.Health);
            this.RegisterComponent(this.Display);
            this.Location.MoveTo(x, y);
        }

        public Components.Health Health { get; set; }
        public Components.Display Display { get; set; }
    }
}
