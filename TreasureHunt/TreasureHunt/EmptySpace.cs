using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class EmptySpace : GameObject
    {
        public override string Execute(Player player, GameBoard gameBoard)
        {
           //if (this.IsToTheRight)
        }

        public override string GetOption(Player player)
        {
            if (this.IsToTheRight(player))
                return "Gå till höger";
            else if (this.IsToTheLeft(player))
                return "Gå till vänster";
            else if (this.IsInFront(player))
                return "Gå rakt fram";
            else if (this.IsBehind(player))
                return "Gå bakåt";
            else
                throw new Exception("Can't get relative position to this game object");
        }
    }
}
