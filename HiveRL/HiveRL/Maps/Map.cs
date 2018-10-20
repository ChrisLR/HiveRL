using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Maps
{
    public class Map : RogueSharp.Map
    {
        public TimeSpan elapsedTime = TimeSpan.Zero;
        
        public List<GameObject> GameObjects;
        public List<Room> Rooms;
        Dictionary<Point, List<GameObject>> gameObjectsByPoint;
        Dictionary<Point, GameObjects.Tile> tilesByPoint;

        public Map(Game game, int width, int height) : base(width, height)
        {
            this.Game = game;
            this.gameObjectsByPoint = new Dictionary<Point, List<GameObject>>();
            this.GameObjects = new List<GameObject>();
            this.tilesByPoint = new Dictionary<Point, GameObjects.Tile>();
            this.Rooms = new List<Room>();
        }

        public Game Game { get; set; }

        public void AddGameObject(GameObject gameObject)
        {
            var point = gameObject.Location.Point;
            this.GameObjects.Add(gameObject);
            List<GameObject> gameObjects = null;
            this.gameObjectsByPoint.TryGetValue(point, out gameObjects);
            if (gameObjects == null)
            {
                gameObjects = new List<GameObject>() { gameObject };
            }
            else
            {
                gameObjects.Add(gameObject);
            }
            this.gameObjectsByPoint[point] = gameObjects;
        }

        public List<GameObject> GetGameObjectsByPoint(Point point)
        {
            List<GameObject> gameObjects = null;
            this.gameObjectsByPoint.TryGetValue(point, out gameObjects);

            return gameObjects;
        }

        public void MoveGameObject(GameObject gameObject, Point newPoint)
        {
            var oldPoint = gameObject.Location.Point;
            var oldGameObjects = this.gameObjectsByPoint[oldPoint];
            oldGameObjects.Remove(gameObject);

            var newGameObjects = this.GetGameObjectsByPoint(newPoint) ?? new List<GameObject>();
            newGameObjects.Add(gameObject);
            this.gameObjectsByPoint[newPoint] = newGameObjects;
            gameObject.Location.Point = newPoint;
        }

        public void AddTile(GameObjects.Tile tile)
        {
            Point point = tile.Location.Point;
            this.tilesByPoint[point] = tile;
            this.SetCellProperties(point.X, point.Y, !tile.IsBlocking, !tile.IsBlocking);
        }

        public GameObjects.Tile GetTile(Point point)
        {
            GameObjects.Tile tile = null;
            this.tilesByPoint.TryGetValue(point, out tile);

            return tile;
        }

        public void Update(GameTime time)
        {
            this.elapsedTime += time.ElapsedGameTime;
            bool mustMove = elapsedTime > TimeSpan.FromMilliseconds(250);
            if (mustMove)
                elapsedTime = TimeSpan.Zero;
            for (var i = this.GameObjects.Count() - 1; i >= 0; i--)
            {
                GameObject gameObject = this.GameObjects[i];
                if(gameObject == this.Game.Player)
                    continue;

                gameObject.Update(time);
            }
        }

    }
}
