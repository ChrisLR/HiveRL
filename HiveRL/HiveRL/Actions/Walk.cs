using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Actions
{
    public class Walk : ActionBase
    {
        Directions.Direction direction;

        public Walk(Directions.Direction direction)
        {
            this.direction = direction;
        }

        public override void Execute(GameObject executor)
        {
            var location = executor.Location;
            var map = location.Map;
            var point = location.Point;

            var target = new Point(point.X + this.direction.XOffset, point.Y + this.direction.YOffset);
            var pointGameObjects = map.GetGameObjectsByPoint(target);
            var tile = map.GetTile(target);
            if (tile == null || tile.IsBlocking)
                return;

            if (pointGameObjects == null || !pointGameObjects.Any(g => g.IsBlocking))
                map.MoveGameObject(executor, target);
        }
    }
}
