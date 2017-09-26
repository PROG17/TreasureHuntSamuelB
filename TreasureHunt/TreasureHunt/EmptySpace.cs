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
       
        public override List<Option> GetOptions(Player player,GameBoard gameBoard)
        {
            return base.GetOptions(player, gameBoard);
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
                return "";
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
