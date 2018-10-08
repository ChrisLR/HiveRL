﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Components
{
    public class Location : ComponentBase
    {
        public Location(GameObject host, Map map) : base("Location", host)
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

        public Point Point { get; set;}

        public Map Map { get; set; }
    }
}