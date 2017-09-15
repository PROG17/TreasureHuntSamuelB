using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    abstract class GameObject
    {
        public abstract string Execute(Player player, GameBoard gameBoard);
        public abstract string GetOption(Player player);

        public string Title { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public GameObject(string title, int x, int y)
        {
            this.Title = title;
            this.X = x;
            this.Y = y;
        }

        public bool IsInFront(Player player)
        {
            if (player.direction == Player.Direction.North)
                if (this.Y < player.Y)
                    return true;
                else return false;
            if (player.direction == Player.Direction.East)
                if (this.X > player.X)
                    return true;
                else return false;
            if (player.direction == Player.Direction.South)
                if (this.Y > player.Y)
                    return true;
                else return false;
            if (player.direction == Player.Direction.West)
                if (this.X < player.X)
                    return true;
                else return false;
            else throw new Exception("Player doesn´t have a valid direction.");

        }

        public bool IsToTheRight(Player player)
        {
            if (player.direction == Player.Direction.North)
                if (this.X > player.X)
                    return true;
                else return false;
            if (player.direction == Player.Direction.East)
                if (this.Y > player.Y)
                    return true;
                else return false;
            if (player.direction == Player.Direction.South)
                if (this.X < player.X)
                    return true;
                else return false;
            if (player.direction == Player.Direction.West)
                if (this.Y < player.Y)
                    return true;
                else return false;
            else throw new Exception("Player doesn´t have a valid direction.");
        }

        public bool IsToTheLeft(Player player)
        {
            if (player.direction == Player.Direction.North)
                if (this.X < player.X)
                    return true;
                else return false;
            if (player.direction == Player.Direction.East)
                if (this.Y < player.Y)
                    return true;
                else return false;
            if (player.direction == Player.Direction.South)
                if (this.X > player.X)
                    return true;
                else return false;
            if (player.direction == Player.Direction.West)
                if (this.Y > player.Y)
                    return true;
                else return false;
            else throw new Exception("Player doesn´t have a valid direction.");
        }

        public bool IsBehind(Player player)
        {
            if (player.direction == Player.Direction.North)
                if (this.Y > player.Y)
                    return true;
                else return false;
            if (player.direction == Player.Direction.East)
                if (this.X < player.X)
                    return true;
                else return false;
            if (player.direction == Player.Direction.South)
                if (this.Y < player.Y)
                    return true;
                else return false;
            if (player.direction == Player.Direction.West)
                if (this.X > player.X)
                    return true;
                else return false;
            else throw new Exception("Player doesn´t have a valid direction.");
        }

    }
}
