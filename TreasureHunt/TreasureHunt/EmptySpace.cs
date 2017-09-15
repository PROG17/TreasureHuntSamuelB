using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class EmptySpace : GameObject
    {
        public EmptySpace(string title, int x, int y) : base(title, x, y)
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
                message = "Du vänder dig om och tar ett steg tillbaka.";
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
    }
}
