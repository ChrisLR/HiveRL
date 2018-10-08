using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Entities;
using Microsoft.Xna.Framework;

namespace HiveRL.Components
{
    public class Display : ComponentBase
    {
        

        public Display(GameObject host, Char symbol, Color foreground, Color background) : base("Location", host)
        {
            this.SadEntity = new Entity(1, 1);
            this.SadEntity.Animation.SetGlyph(0, 0, symbol, foreground, background);
        }

        public Entity SadEntity { get; set; }
    }
}

