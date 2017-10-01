using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class SandPaper : GameObject
    {
        public SandPaper(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {
        }

        public override List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (!player.gameObjects.ContainsKey(this.Key))
            {
                if (this.IsToTheRight(player) || this.IsToTheLeft(player) || this.IsInFront(player) || this.IsBehind(player))
                    return base.GetOptions(player, gameBoard);
                else
                    options.Add(new Option("Ta sandpappret under dig", () =>
                    {
                        player.Score += 20;
                        player.gameObjects.Add(this.Key, this);
                        int index = this.Y * gameBoard.Width + this.X;
                        gameBoard.Board = gameBoard.Board.ReplaceAt(index, ' ');
                        return "Du tar sandpappret och lägger det i fickan";
                    }));
            }

            return options;
        }

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig ligger ett sandpapper på golvet.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig ligger ett sandpapper på golvet.";
            else if (this.IsInFront(player))
                return "Framför dig ligger ett sandpapper på golvet.";
            else if (this.IsBehind(player))
                return "Bakom dig ligger sandpapper på golvet.";
            else
                return "Under dig ligger sandpapper på golvet.";
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch == 'S')
            {
                return new SandPaper("sandpapper", "sandpapper", "ett sandpapper som ser ut att vara helt oanvänt", x, y);
            }
            else
                return null;
        }
    }
}
