using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Coin : GameObject
    {
        static int count = 0;

        public Coin(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {
            count++;
        }

        public override List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (this.IsToTheRight(player) || this.IsToTheLeft(player) || this.IsInFront(player) || this.IsBehind(player))
                return base.GetOptions(player, gameBoard);
            else
                options.Add(new Option("Ta myntet under dig", () =>
                {
                    player.Score += 10;
                    player.Coins += 1;
                    player.gameObjects.Add(this.Key, this);
                    int index = this.Y * gameBoard.Width + this.X;
                    gameBoard.Board = gameBoard.Board.ReplaceAt(index, ' ');
                    return "Du tar myntet och stoppar det i fickan";
                }));

            return options;
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
                return "Under dig ligger ett mynt på golvet.";
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch == 'c')
            {
                return new Coin("mynt", $"mynt{count}", "ett rostigt gammalt mynt med ett ansikte på en kung vars namn är svårt att minnas", x, y);
            }
            else
                return null;
        }
    }
}
