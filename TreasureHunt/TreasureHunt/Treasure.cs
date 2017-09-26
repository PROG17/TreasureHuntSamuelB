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
        
        public override List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (this.IsToTheRight(player) || this.IsToTheLeft(player) || this.IsInFront(player) || this.IsBehind(player))
                return base.GetOptions(player, gameBoard);

            if (player.gameObjects.ContainsKey("skattkistaNyckel"))
            {
                options.Add(new Option("Lås upp skattkistan med den gamla nyckeln", () =>
                {
                    player.Score += 100;
                    player.Won = true;
                    return "Du låser upp kistan och hittar skatten!";
                }));
            }
            else
                options.Add(new Option("Försök öppna skattkistan", () =>
                {                   
                    return "Skattkistan är låst och går inte att öppna.";
                }));

            return options;
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
                return "På golvet står en skattkista.";
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
