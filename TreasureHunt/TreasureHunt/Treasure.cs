using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Treasure : GameObject
    {

        public Treasure(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {

        }

        public override string Execute(Player player, GameBoard gameBoard)
        {
            player.Score += 100;
            player.Coins += 1000000;
            player.Won = true;
            string message = "";

            if (this.IsToTheRight(player))
            {
                message = "Du tar ett steg till höger och tar skatten!";
                player.TurnRight();
            }
            else if (this.IsToTheLeft(player))
            {
                message = "Du tar ett steg till vänster och tar skatten!";
                player.TurnLeft();
            }
            else if (this.IsBehind(player))
            {
                message = "Du vänder dig om, tar ett steg tillbaka, och tar skatten!";
                player.TurnAround();
            }
            else
                message = "Du tar ett steg framåt och tar skatten!";

            player.X = this.X;
            player.Y = this.Y;

            int index = this.Y * gameBoard.Width + this.X;
            gameBoard.Board = gameBoard.Board.ReplaceAt(index, ' ');

            return message;
        }

        public override string GetOption(Player player)
        {
            if (this.IsToTheRight(player))
                return "Ta skatten till höger";
            else if (this.IsToTheLeft(player))
                return "Ta skatten till vänster";
            else if (this.IsInFront(player))
                return "Ta skatten framför dig";
            else if (this.IsBehind(player))
                return "Ta skatten bakom dig";
            else
                throw new Exception("Can't get relative position to this game object");
        }

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig står en skattkista på golvet.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig står en skattkista på golvet.";
            else if (this.IsInFront(player))
                return "Framför dig står en skattkista på golvet.";
            else if (this.IsBehind(player))
                return "Bakom dig står en skattkista på golvet.";
            else
                throw new Exception("Can't get relative position to this game object");
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch == 't')
                return new Treasure("skattkista", "skattkista", "en vacker skattkista med ett förgyllt lock vars smaragder glittrar i dunklet, kistan har ett stort rostigt hänglås och går tyvärr inte att öppna utan rätt nyckel", x, y);
            else
                return null;
        }
    }
}
