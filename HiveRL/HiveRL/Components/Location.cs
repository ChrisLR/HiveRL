using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Components
{
    public class Location : ComponentBase
    {
        public Location(GameObject host, Maps.Map map) : base("Location", host)
        {
            this.Map = map;
        }

        public void SetPos(int x = 0, int y = 0)
        {
            var target = new Point(x, y);
            this.Point = target;
        }

        public Point Point { get; set;}

        public Maps.Map Map { get; set; }
    }
}
