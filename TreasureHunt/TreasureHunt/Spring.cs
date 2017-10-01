using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Spring : GameObject
    {
        public Spring(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {

        }

        public override List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (this.IsToTheRight(player))
                options.Add(new Option("Gå höger till brunnen", () =>
                {
                    player.X = this.X;
                    player.Y = this.Y;
                    player.Lost = true;
                    return "Du faller ner i en 200 meter djup brunn och drunknar!";

                }));
            else if (this.IsToTheLeft(player))
                options.Add(new Option("Gå vänster till brunnen", () =>
                {
                    player.X = this.X;
                    player.Y = this.Y;
                    player.Lost = true;
                    return "Du faller ner i en 200 meter djup brunn och drunknar!";
                }));

            else if (this.IsInFront(player))
                options.Add(new Option("Gå framåt till brunnen", () =>
                {
                    player.X = this.X;
                    player.Y = this.Y;
                    player.Lost = true;
                    return "Du faller ner i en 200 meter djup brunn och drunknar!";
                }));
            else if (this.IsBehind(player))
                options.Add(new Option("Gå bakåt till brunnen", () =>
                {
                    player.X = this.X;
                    player.Y = this.Y;
                    player.Lost = true;
                    return "Du faller ner i en 200 meter djup brunn och drunknar!";
                }));


            return options;
        }

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig ligger en gammal brunn.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig ligger en gammal brunn.";
            else if (this.IsInFront(player))
                return "Framför dig ligger en gammal brunn.";
            else if (this.IsBehind(player))
                return "Bakom dig ligger en gammal brunn.";
            else
                return "";
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch == 's')
                return new Spring("brunn", "brunn", "en gammal vacker brunn som saknar skyddsannordningar", x, y);
            else
                return null;
        }
    }
}
