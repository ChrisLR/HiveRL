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

        public void MoveByOffset(int x = 0, int y = 0)
        {
            var target = new Point(this.Point.X + x, this.Point.Y + y);
            var pointGameObjects = this.Map.GetGameObjectsByPoint(target);
            if (pointGameObjects == null || !pointGameObjects.Any(g => g.IsBlocking))
                this.Map.MoveGameObject(this.Host, target);
        }

        public void MoveTo(int x = 0, int y = 0)
        {
            var target = new Point(x,  y);
            this.Map.MoveGameObject(this.Host, target);
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
