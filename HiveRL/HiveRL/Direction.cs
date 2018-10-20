using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL
{
    public static class Directions
    {
        public static Direction North = new Directions.Direction(0, -1);
        public static Direction South = new Directions.Direction(0, 1);
        public static Direction East = new Directions.Direction(1, 0);
        public static Direction West = new Directions.Direction(-1, 0);

        public class Direction
        {
            public int XOffset;
            public int YOffset;
            public Direction(int xoffset, int yoffset)
            {
                this.XOffset = xoffset;
                this.YOffset = yoffset;
            }

        }

        public static Direction GetByOffset(int offset_x = 0, int offset_y = 0)
        {
            var signX = Math.Sign(offset_x);
            var signY = Math.Sign(offset_y);
            if (signX == 1)
                return Directions.East;
            if (signX == -1)
                return Directions.West;
            if (signY == 1)
                return Directions.South;
            if (signY == -1)
                return Directions.North;

            return null;
        }
    }
}
