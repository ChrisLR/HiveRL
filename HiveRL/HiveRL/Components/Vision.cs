using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace HiveRL.Components
{
    public class Vision : ComponentBase
    {
        int radius;
        RogueSharp.FieldOfView fov;
        Maps.Map currentMap;

        public Vision(GameObject host, int radius) : base("Vision", host)
        {
            this.radius = radius;
            this.currentMap = this.Host.Location.Map;
            this.fov = new RogueSharp.FieldOfView(this.currentMap);
            var origin = this.Host.Location.Point;
            this.fov.ComputeFov(origin.X, origin.Y, this.radius, true);

        }

        public override void Update(GameTime deltatime)
        {
            base.Update(deltatime);
            var map = this.Host.Location.Map;
            if(map != this.currentMap)
            {
                this.currentMap = map;
                this.fov = new RogueSharp.FieldOfView(this.currentMap); 
            }
            var origin = this.Host.Location.Point;
            this.fov.ComputeFov(origin.X, origin.Y, this.radius, true);
        }

        public bool CanSee(Point point)
        {
            return this.fov.IsInFov(point.X, point.Y);
        }
    }
}

