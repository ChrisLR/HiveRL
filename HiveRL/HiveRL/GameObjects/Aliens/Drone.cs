using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.GameObjects.Aliens
{
    public class Drone : Alien
    {
        public Drone(Maps.Map map, int x, int y) : base("Alien Drone", 10, map)
        {
            this.Display.SadEntity.Animation.SetGlyph(0, 0, 'D');
            this.RegisterComponent(new Components.SimpleVision(this, 10));
            this.RegisterComponent(new Components.AI(this));

            // TODO This should not be here
            this.Location.SetPos(x, y);
            map.AddGameObject(this);
        }
    }
}
