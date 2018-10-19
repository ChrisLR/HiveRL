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
    public class GameArea : SadConsole.Console
    {
        Character player;
        Game game;
        Point origin;
        List<Point> points;
        public bool MustRedraw = true;

        public GameArea(Character player, Game game, int width, int height) : base(width, height)
        {
            this.player = player;
            this.ViewPort = new Rectangle(0, 0, width, height);
            this.game = game;
            this.origin = new Point(width / 2, height / 2);
            this.player.Display.SadEntity.Position = this.origin;
            this.points = new List<Point>();

        }

        public override void Draw(TimeSpan timeElapsed)
        {
            if (!this.MustRedraw)
            {
                base.Draw(timeElapsed);
                return;
            }
                

            this.Clear();
            Components.Vision vision = (Components.Vision)this.player.GetComponent(typeof(Components.Vision));
            for ( var world_x = 0; world_x <= this.ViewPort.Width; world_x++)
            {
                for (var world_y = 0; world_y <= this.ViewPort.Height; world_y++)
                {
                    var screenOffset = new Point(this.origin.X - world_x, this.origin.Y - world_y );
                    Point gamePoint = this.player.Location.Point - screenOffset;
                    
                    if(!vision.CanSee(gamePoint))
                    {
                        continue;
                    }
                    Tile tile = this.game.activeMap.GetTile(gamePoint);
                    if(tile != null)
                    {
                        var display = (Components.Display)tile.GetComponent(typeof(Components.Display));
                        this.SetGlyph(world_x, world_y, display.SadEntity.Animation.GetGlyph(0, 0));
                    }
                }
            }

            
            foreach(GameObject gameObject in this.game.activeMap.GameObjects)
            {
                if (!vision.CanSee(gameObject.Location.Point))
                {
                    continue;
                }
                var display = (Components.Display)gameObject.GetComponent(typeof(Components.Display));
                var offset = gameObject.Location.Point - this.player.Location.Point;
                var screenPosition = this.origin + offset;
                this.SetGlyph(screenPosition.X, screenPosition.Y, display.SadEntity.Animation.GetGlyph(0, 0));
            }
            base.Draw(timeElapsed);
            this.MustRedraw = false;
        }
    }
}
