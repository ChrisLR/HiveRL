using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using HiveRL.GameObjects;
using Microsoft.Xna.Framework;

namespace HiveRL.UI
{
    public class Hud : SadConsole.Console
    {
        Character player;

        public Hud(Character player, int width, int height) : base(width, height)
        {
            this.player = player;
            var borderSurface = new SadConsole.Surfaces.Basic(width + 1, height, base.Font);
            borderSurface.DrawBox(new Rectangle(0, 0, borderSurface.Width, borderSurface.Height),
                                  new Cell(Color.White, Color.Black), null, SadConsole.Surfaces.SurfaceBase.ConnectedLineThick);
            this.Children.Add(borderSurface);
            this.Print(2, 2, "Name:");
            this.Print(7, 2, player.Name);
        }
    }
}
