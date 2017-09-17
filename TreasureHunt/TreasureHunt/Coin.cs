using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Coin : GameObject
    {

        public Coin(string title, int x, int y) : base(title, x, y)
        {

        }

        public override string Execute(Player player, GameBoard gameBoard)
        {
            player.Score += 10;
            player.Coins += 1;

            string message = "";

            if (this.IsToTheRight(player))
            {
                message = "Du tar ett steg till höger och tar myntet.";
                player.TurnRight();
            }
            else if (this.IsToTheLeft(player))
            {
                message = "Du tar ett steg till vänster och tar myntet.";
                player.TurnLeft();
            }
            else if (this.IsBehind(player))
            {
                message = "Du vänder dig om, tar ett steg tillbaka, och tar myntet.";
                player.TurnAround();
            }
            else
                message = "Du tar ett steg framåt och tar myntet.";

            player.X = this.X;
            player.Y = this.Y;

            int index = this.Y * gameBoard.Width + this.X;
            gameBoard.Board = gameBoard.Board.ReplaceAt(index, ' ');

            return message;
        }

        public override string GetOption(Player player)
        {
            if (this.IsToTheRight(player))
                return "Ta myntet till höger";
            else if (this.IsToTheLeft(player))
                return "Ta myntet till vänster";
            else if (this.IsInFront(player))
                return "Ta myntet framför dig";
            else if (this.IsBehind(player))
                return "Ta myntet bakom dig";
            else
                throw new Exception("Can't get relative position to this game object");
        }

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig ligger ett mynt på golvet.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig ligger ett mynt på golvet.";
            else if (this.IsInFront(player))
                return "Framför dig ligger ett mynt på golvet.";
            else if (this.IsBehind(player))
                return "Bakom dig ligger ett mynt på golvet.";
            else
                throw new Exception("Can't get relative position to this game object");
        }
    }
}
