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
    public class MessageLog : SadConsole.Console
    {
        Character player;
        Game game;
        SadConsole.Surfaces.Basic logBox;
        public bool MustRedraw = true;
        int originX;
        int originY;

        public MessageLog(Character player, Game game, int width, int height) : base(width, height)
        {
            this.player = player;
            this.game = game;
            logBox = new SadConsole.Surfaces.Basic(width + 1, height, base.Font);
            logBox.DrawBox(new Rectangle(0, height - 10, logBox.Width, 10),
                                  new Cell(Color.White, Color.Black), null, SadConsole.Surfaces.SurfaceBase.ConnectedLineThick);
            originX = 1;
            originY = height - 9;
            this.Children.Add(logBox);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            if (!this.MustRedraw)
            {
                base.Draw(timeElapsed);
                return;
            }
            this.Clear();
            var logCount = this.player.MessageLog.Count();
            var maxI = logCount > 9 ? 9 : logCount;
            for (int i = 0; i < maxI; i++)
            {
                this.logBox.Print(originX, originY + i, this.player.MessageLog[i]);
            }
            
            base.Draw(timeElapsed);
            this.MustRedraw = false;
        }
    }
}
