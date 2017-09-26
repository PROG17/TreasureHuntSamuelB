using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Wall : GameObject
    {
        public Wall(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {

        }     

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig finns en vägg.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig finns en vägg.";
            else if (this.IsInFront(player))
                return "Du står framför en vägg.";
            else if (this.IsBehind(player))
                return "Bakom dig finns en vägg.";
            else
                throw new Exception("Can't get relative position to this game object");
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch == 'x')
                return new Wall("vägg", "vägg", "en gammal grå betongvägg som sett sina bästa dagar för länge sedan", x, y);
            else
                return null;
        }

        public override List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (this.IsToTheRight(player))
                options.Add(new Option("Banka på väggen till höger", () =>
                {
                    if (player.Score > 4)
                    {
                        player.Score -= 5;
                        return "Du får rejält ont i händerna och förlorar 5 poäng!";
                    }
                    else
                        return "Du får rejält ont i händerna!";
                }));
            else if (this.IsToTheLeft(player))
                options.Add(new Option("Banka på väggen till vänster", () =>
                {
                    if (player.Score > 4)
                    {
                        player.Score -= 5;
                        return "Du får rejält ont i händerna och förlorar 5 poäng!";
                    }
                    else
                        return "Du får rejält ont i händerna!";
                }));

            else if (this.IsInFront(player))
                options.Add(new Option("Banka på väggen framför dig", () =>
                {
                    if (player.Score > 4)
                    {
                        player.Score -= 5;
                        return "Du får rejält ont i händerna och förlorar 5 poäng!";
                    }
                    else
                        return "Du får rejält ont i händerna!";
                }));
            else if (this.IsBehind(player))
                options.Add(new Option("Banka på väggen bakom dig", () =>
                {
                    if (player.Score > 4)
                    {
                        player.Score -= 5;
                        return "Du får rejält ont i händerna och förlorar 5 poäng!";
                    }
                    else
                        return "Du får rejält ont i händerna!";
                }));


            return options;
        }


    }
}
