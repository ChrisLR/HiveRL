using System;
using SadConsole;
using Console = SadConsole.Console;
using SadConsole.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using RogueSharp.Random;

namespace HiveRL
{
    public class Program
    {
        public static RogueSharp.Random.IRandom Random { get; private set; }

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.UtcNow.Ticks;
            Random = new DotNetRandom(seed);

            var game = new Game();
            game.Start();
        }
    }
}
