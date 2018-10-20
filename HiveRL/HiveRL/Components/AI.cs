using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Components
{
    public class SimpleAI : ComponentBase
    {
        GameObject target = null;

        public SimpleAI(GameObject host) : base("SimpleAI", host)
        {
            
        }

        public override void Update(GameTime deltatime)
        {
            base.Update(deltatime);
            // Currently, only a very basic AI is required
            // If no target, acquire one if it is seen
            // If a target, walk to it and "bump"
            var map = this.Host.Location.Map;
            if (target == null)
            {
                this.acquireTarget(map, this.Host);
                return;
            }
            else
            {
                this.WalkToTarget(map, this.Host);
            }
                

        }

        public void acquireTarget(Maps.Map map, GameObject host)
        {
            // Currently, only the player will be considered enemy.
            var vision = (SimpleVision)host.GetComponent(typeof(Components.SimpleVision));
            if (vision == null)
                return;
            var player = map.Game.Player;
            var playerPoint = player.Location.Point;
            if (vision.CanSee(playerPoint))
                this.target = player;
        }

        public void WalkToTarget(Maps.Map map, GameObject host)
        {
            // Attempt to walk, do nothing if we can't

            var player = map.Game.Player;
            var playerPoint = player.Location.Point;
            var hostPoint = host.Location.Point;
            var delta = playerPoint - hostPoint;
            var horizontalDirection = Directions.GetByOffset(delta.X);
            var verticalDirection = Directions.GetByOffset(0, delta.Y);
            if(horizontalDirection != null)
            {
                var action = new Actions.Walk(horizontalDirection);
                var result = action.Execute(this.Host);
                if (result)
                {
                    return;
                }
            }
            if (verticalDirection != null)
            {
                var action = new Actions.Walk(verticalDirection);
                action.Execute(this.Host);
            }
        }
    }
}
