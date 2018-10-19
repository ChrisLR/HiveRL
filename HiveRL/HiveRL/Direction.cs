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
    }
}
