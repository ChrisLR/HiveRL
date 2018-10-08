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

        public GameArea(Character player, Game game, int width, int height) : base(width, height)
        {
            this.player = player;
            this.Manager = new SadConsole.Entities.EntityManager();
            this.Children.Add(this.Manager);
            this.ViewPort = new Rectangle(0, 0, width, height);
            this.game = game;
            this.origin = new Point(width / 2, height / 2);
            this.player.Display.SadEntity.Position = this.origin;

        }

        public SadConsole.Entities.EntityManager Manager { get; protected set; }

        public override void Draw(TimeSpan timeElapsed)
        {
            foreach(GameObject gameObject in this.game.activeMap.GameObjects)
            {
                var display = (Components.Display)gameObject.GetComponent(typeof(Components.Display));
                var offset = gameObject.Location.Point - this.player.Location.Point;
                var screenPosition = this.origin + offset;
                display.SadEntity.Position = screenPosition;
            }
            base.Draw(timeElapsed);
        }
    }
}
