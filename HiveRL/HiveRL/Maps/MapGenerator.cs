using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Maps
{
    class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _maxRooms;
        private readonly int _roomMaxSize;
        private readonly int _roomMinSize;

        private readonly Maps.Map _map;

        // Constructing a new MapGenerator requires the dimensions of the maps it will create
        // as well as the sizes and maximum number of rooms
        public MapGenerator(Game game, int width, int height, int maxRooms, int roomMaxSize, int roomMinSize)
        {
            _width = width;
            _height = height;
            _maxRooms = maxRooms;
            _roomMaxSize = roomMaxSize;
            _roomMinSize = roomMinSize;
            _map = new Maps.Map(game, width, height);
        }

        // Generate a new map that places rooms randomly
        public Maps.Map CreateMap()
        {
            // Set the properties of all cells to false
            _map.Initialize(_width, _height);

            // Try to place as many rooms as the specified maxRooms
            // Note: Only using decrementing loop because of WordPress formatting
            for (int r = _maxRooms; r > 0; r--)
            {
                // Determine the size and position of the room randomly
                int roomWidth = Program.Random.Next(_roomMinSize, _roomMaxSize);
                int roomHeight = Program.Random.Next(_roomMinSize, _roomMaxSize);
                int roomXPosition = Program.Random.Next(0, _width - roomWidth - 1);
                int roomYPosition = Program.Random.Next(0, _height - roomHeight - 1);

                // All of our rooms can be represented as Rectangles
                var newRoomBox = new Rectangle(roomXPosition, roomYPosition, roomWidth, roomHeight);
                var newRoom = new Room(newRoomBox);

                // Check to see if the room rectangle intersects with any other rooms
                bool newRoomIntersects = _map.Rooms.Any(room => newRoom.Box.Intersects(room.Box));

                // As long as it doesn't intersect add it to the list of rooms
                if (!newRoomIntersects)
                {
                    _map.Rooms.Add(newRoom);
                }
            }
            // Iterate through each room that we wanted placed 
            // call CreateRoom to make it
            foreach (Room room in _map.Rooms)
            {
                CreateRoom(room);
            }

            // Iterate through each room that was generated
            // Don't do anything with the first room, so start at r = 1 instead of r = 0
            for (int r = 1; r < _map.Rooms.Count; r++)
            {
                // For all remaing rooms get the center of the room and the previous room
                int previousRoomCenterX = _map.Rooms[r - 1].Box.Center.X;
                int previousRoomCenterY = _map.Rooms[r - 1].Box.Center.Y;
                int currentRoomCenterX = _map.Rooms[r].Box.Center.X;
                int currentRoomCenterY = _map.Rooms[r].Box.Center.Y;

                // Give a 50/50 chance of which 'L' shaped connecting hallway to tunnel out
                if (Program.Random.Next(1, 2) == 1)
                {
                    CreateHorizontalTunnel(previousRoomCenterX, currentRoomCenterX, previousRoomCenterY);
                    CreateVerticalTunnel(previousRoomCenterY, currentRoomCenterY, currentRoomCenterX);
                }
                else
                {
                    CreateVerticalTunnel(previousRoomCenterY, currentRoomCenterY, previousRoomCenterX);
                    CreateHorizontalTunnel(previousRoomCenterX, currentRoomCenterX, currentRoomCenterY);
                }
            }

            return _map;
        }

        // Given a rectangular area on the map
        // set the cell properties for that area to true
        private void CreateRoom(Room room)
        {
            Rectangle box = room.Box;
            for (int x = box.Left + 1; x < box.Right; x++)
            {
                for (int y = box.Top + 1; y < box.Bottom; y++)
                {
                    if(x == box.Left || x == box.Right || y == box.Top || y == box.Bottom)
                    {
                        GameObjects.Wall newWall = new GameObjects.Wall(1, this._map, x, y);
                        this._map.AddTile(newWall);
                    }
                    else
                    {
                        GameObjects.Floor newFloor = new GameObjects.Floor(this._map, x, y);
                        this._map.AddTile(newFloor);
                    }
                }
            }
        }

        // Carve a tunnel out of the map parallel to the x-axis
        private void CreateHorizontalTunnel(int xStart, int xEnd, int yPosition)
        {
            for (int x = Math.Min(xStart, xEnd); x <= Math.Max(xStart, xEnd); x++)
            {
                GameObjects.Floor newFloor = new GameObjects.Floor(this._map, x, yPosition);
                this._map.AddTile(newFloor);
            }
        }

        // Carve a tunnel out of the map parallel to the y-axis
        private void CreateVerticalTunnel(int yStart, int yEnd, int xPosition)
        {
            for (int y = Math.Min(yStart, yEnd); y <= Math.Max(yStart, yEnd); y++)
            {
                GameObjects.Floor newFloor = new GameObjects.Floor(this._map, xPosition, y);
                this._map.AddTile(newFloor);
            }
        }
    }
}
