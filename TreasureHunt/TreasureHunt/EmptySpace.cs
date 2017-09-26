using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class EmptySpace : GameObject
    {
        public EmptySpace(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {

        }
        public override string Execute(Player player, GameBoard gameBoard)
        {
            string message = "";

            if (this.IsToTheRight(player))
            {
                message = "Du tar ett steg till höger.";
                player.TurnRight();
            }
            else if (this.IsToTheLeft(player))
            {
                message = "Du tar ett steg till vänster.";
                player.TurnLeft();
            }
            else if (this.IsBehind(player))
            {
                message = "Du vänder dig om och tar ett steg framåt.";
                player.TurnAround();
            }
            else
                message = "Du tar ett steg framåt";

            player.X = this.X;
            player.Y = this.Y;

            return message;
        }

        public override string GetOption(Player player)
        {
            if (this.IsToTheRight(player))
                return "Gå till höger";
            else if (this.IsToTheLeft(player))
                return "Gå till vänster";
            else if (this.IsInFront(player))
                return "Gå rakt fram";
            else if (this.IsBehind(player))
                return "Gå bakåt";
            else
                throw new Exception("Can't get relative position to this game object");
        }

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig är det tomt.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig är det tomt.";
            else if (this.IsInFront(player))
                return "Framför dig är det tomt.";
            else if (this.IsBehind(player))
                return "Bakom dig är det tomt.";
            else
                throw new Exception("Can't get relative position to this game object");
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch == ' ')
                return new EmptySpace("tomrum", "tomrum", "ett tomrum som bara innehåller luften du andas och en hel del damm med för den delen", x, y);
            else
                return null;
        }
    }
}
