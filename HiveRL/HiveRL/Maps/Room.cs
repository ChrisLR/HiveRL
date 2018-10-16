using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Maps
{
    public class Room
    {
        public Rectangle Box;

        public Room(Rectangle box)
        {
            this.Box = box;
        }
    }
}
