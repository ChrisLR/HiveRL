using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.GameObjects
{
    public class Floor : Tile
    {
        public Floor(Maps.Map map, int x, int y) : base("floor", map)
        {
            this.IsBlocking = false;
            this.Display = new Components.Display(this, '.', Color.Gray, Color.Black);
            this.RegisterComponent(this.Display);
            this.Location.SetPos(x, y);
        }

        public Components.Health Health { get; set; }
        public Components.Display Display { get; set; }
    }
}
