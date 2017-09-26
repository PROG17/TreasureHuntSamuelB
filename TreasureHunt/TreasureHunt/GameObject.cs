using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    abstract class GameObject : IGameObjectFactory
    {
        public abstract string Execute(Player player, GameBoard gameBoard);
        public abstract GameObject TryCreateFromChar(char ch, int x, int y);
        public abstract string GetOption(Player player);
        public abstract string GetView(Player player);

        public string Title { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }

        public GameObject(string title, string key, string description, int x, int y)
        {
            this.Title = title;
            this.Key = key;
            this.Description = description;
            this.X = x;
            this.Y = y;
        }

        public GameObject() //default constructor 
        {

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

        public virtual List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (this.IsToTheRight(player))
                options.Add(new Option("Gå till höger", () =>
                {
                    player.TurnRight();
                    player.X = this.X;
                    player.Y = this.Y;
                    return "Du tar ett steg till höger.";
                }));
            else if (this.IsToTheLeft(player))
                options.Add(new Option("Gå till vänster", () =>
                {
                    player.TurnLeft();
                    player.X = this.X;
                    player.Y = this.Y;
                    return "Du tar ett steg till vänster.";
                }));

            else if (this.IsInFront(player))
                options.Add(new Option("Gå framåt", () =>
                {
                    player.X = this.X;
                    player.Y = this.Y;
                    return "Du tar ett steg framåt.";
                }));
            else if (this.IsBehind(player))
                options.Add(new Option("Gå bakåt", () =>
                {
                    player.TurnAround();
                    player.X = this.X;
                    player.Y = this.Y;
                    return "Du tar ett steg bakåt.";
                }));
            

            return options;
        }

    }
}
