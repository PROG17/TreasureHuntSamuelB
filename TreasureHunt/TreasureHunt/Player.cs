using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Player
    {
        public enum Direction { North, East, South, West };

        public Direction direction = Direction.North;
        public int X { get; set; }
        public int Y { get; set; }
        public int Score { get; set; }
        public int Coins { get; set; }
        public Dictionary<string, GameObject> gameObjects { get; set; }
        public bool Won { get; set; }
        public bool Lost { get; set; }
        public string Name { get; set; }
        public int GameBoardKey { get; set; }

        public Player(string name)
        {
            this.Name = name;

            this.gameObjects = new Dictionary<string, GameObject>();

        }

        public void TurnRight()
        {
            int newDirection = ((int)(this.direction) + 1) % 4;
            this.direction = (Direction)newDirection;
        }

        public void TurnLeft()
        {
            int newDirection = ((int)(this.direction) + 4 - 1) % 4;
            this.direction = (Direction)newDirection;
        }

        public void TurnAround()
        {
            int newDirection = ((int)(this.direction) + 2) % 4;
            this.direction = (Direction)newDirection;
        }

    }
}
