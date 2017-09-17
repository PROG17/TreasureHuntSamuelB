using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Wall : GameObject
    {
        public Wall(string title, int x, int y) : base(title, x, y)
        {

        }

        public override string Execute(Player player, GameBoard gameBoard)
        {
            if (player.Score > 4)
            {
                player.Score -= 5;
                return "Du får rejält ont i händerna och förlorar 5 poäng!";
            }
            else
                return "Du får rejält ont i händerna!";
        }

        public override string GetOption(Player player)
        {
            if (this.IsToTheRight(player))
                return "Banka på väggen till höger";
            else if (this.IsToTheLeft(player))
                return "Banka på väggen till vänster";
            else if (this.IsInFront(player))
                return "Banka på väggen framför dig";
            else if (this.IsBehind(player))
                return "Banka på väggen bakom dig";
            else
                throw new Exception("Can't get relative position to this game object");
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


    }
}
