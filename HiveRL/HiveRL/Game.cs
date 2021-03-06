﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using Console = SadConsole.Console;
using SadConsole.Entities;
using SadConsole.Surfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp.DiceNotation;


namespace HiveRL
{
    public class Game
    {
        public const int Width = 80;
        public const int Height = 40;
        
        public Maps.Map activeMap;
        UI.GameArea gameArea;
        UI.MessageLog messageLog;
        public bool PlayerMoved = true;
        public Keybindings keyBindings = new Keybindings();

        public Game()
        {
            // Setup the engine and creat the main window.
            SadConsole.Game.Create("IBM.font", Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = this.Initialize;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;
            this.Start();
        }

        public void Initialize()
        {
            // Any custom loading and prep. We will use a sample console for now
            Console startingConsole = new Console(Width, Height);

            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = startingConsole;

            var generator = new Maps.MapGenerator(this, 50, 50, 10, 10, 6);
            this.activeMap = generator.CreateMap();

            //Add an display a character
            this.Player = new GameObjects.Character("Kek", 1, this.activeMap);
            this.Player.Location.Point = this.activeMap.Rooms.First().Box.Center;
            this.Player.RegisterComponent(new Components.Vision(this.Player, 10));
            
            this.activeMap.AddGameObject(Player);
            this.gameArea = new UI.GameArea(this.Player, this, Width - 21, Height);
            this.messageLog = new UI.MessageLog(this.Player, this, Width - 21, Height);

            //Add Npcs
            //for(var i = 0; i < 10; i++)
            //{
            //    var npc = new GameObjects.Character("Npc", 1, this.activeMap);
            //    npc.Display.SadEntity.Animation.SetForeground(0, 0, Color.Red);
            //    npc.Location.Point = new Point(i * 2, i);
            //    this.activeMap.AddGameObject(npc);
            //}

            var hud = new HiveRL.UI.Hud(this.Player, 20, Height);
            hud.Position = new Point(Width - 21, 0);
            startingConsole.Children.Add(hud);
            startingConsole.Children.Add(gameArea);
            startingConsole.Children.Add(messageLog);
            this.PlayerMoved = true;
            this.gameArea.Draw(TimeSpan.Zero);
            this.Player.Message("Welcome!");
        }

        public void Start()
        {
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private void Update(GameTime time)
        {
            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
            // DEBUG SPAWN DRONE
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F2))
            {
                var playerPoint = this.Player.Location.Point;
                var drone = new GameObjects.Aliens.Drone(this.activeMap, playerPoint.X - 1, playerPoint.Y - 1);
                
            }
            var keysReleased = SadConsole.Global.KeyboardState.KeysReleased;
            if (keysReleased.Any())
            {
                foreach(var key in keysReleased)
                {
                    var action = this.keyBindings.GetAction(key.Key);
                    if(action != null)
                    {
                        if (action.CanExecute(this.Player))
                        {
                            action.Execute(this.Player);
                            this.PlayerMoved = true;
                            break;
                        }
                    }
                }
            }

            if (this.PlayerMoved)
            {
                this.Player.Update(time);
                this.activeMap.Update(time);
                this.PlayerMoved = false;
                this.gameArea.MustRedraw = true;
            }
        }

        public GameObjects.Character Player { get; set; }
    }
}
