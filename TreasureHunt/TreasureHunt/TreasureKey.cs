using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class TreasureKey : GameObject
    {
        bool polished;


        public TreasureKey(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {
            polished = false;
        }

        public bool Polished
        {
            get
            {
                return this.polished;
            }
        }

        public override List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (!player.gameObjects.ContainsKey(this.Key))
            {
                if (this.IsToTheRight(player) || this.IsToTheLeft(player) || this.IsInFront(player) || this.IsBehind(player))
                    return base.GetOptions(player, gameBoard);
                else
                {
                    options.Add(new Option("Ta nyckeln under dig", () =>
                    {
                        player.Score += 10;
                        player.gameObjects.Add(this.Key, this);
                        int index = this.Y * gameBoard.Width + this.X;
                        gameBoard.Board = gameBoard.Board.ReplaceAt(index, ' ');
                        return "Du tar nyckeln och hänger den runt halsen.";
                    }));
                }
            }
            else
            {
                if (player.gameObjects.ContainsKey("sandpapper"))
                    options.Add(new Option("Slipa nyckeln med sandpappret", () =>
                    {
                        this.polished = true;
                        player.Score += 20;
                        player.gameObjects.Remove("sandpapper");
                        return "Du slipar nyckeln med sandpappret";
                    }));
            }
           
            return options;
        }

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig ligger en nyckel på golvet.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig ligger en nyckel på golvet.";
            else if (this.IsInFront(player))
                return "Framför dig ligger en nyckel på golvet.";
            else if (this.IsBehind(player))
                return "Bakom dig ligger en nyckel på golvet.";
            else
                return "Under dig ligger en nyckel på golvet.";
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch == 'k')
                return new TreasureKey("Gammal nyckel", "skattkistaNyckel", "En gammal rostig nyckel som inte ser ut att vara värd någonting.", x, y);
            else
                return null;
        }
    }
}
