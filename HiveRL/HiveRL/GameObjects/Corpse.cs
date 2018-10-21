using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.GameObjects
{
    public class Corpse : GameObject
    {
        public Corpse(GameObject previousGameObject, Maps.Map map) : base("Corpse of " + previousGameObject.Name, map)
        {
            var oldPoint = previousGameObject.Location.Point;
            this.Location.SetPos(oldPoint.X, oldPoint.Y);
            map.RemoveGameObject(previousGameObject);
            this.Display = new Components.Display(this, '%', Color.Red, Color.Black);
            this.RegisterComponent(this.Display);
            map.AddGameObject(this);

            this.IsBlocking = false;
        }

        public Components.Display Display { get; set; }
    }
}
