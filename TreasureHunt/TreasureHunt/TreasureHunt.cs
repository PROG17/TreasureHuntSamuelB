using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class TreasureHunt
    {
        Player player;
        GameBoard gameBoard;
        StoryTeller storyTeller;

        public TreasureHunt(GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public void Run(Player player)
        {
            this.player = player;
            this.gameBoard.SetPlayerCordinates(this.player);
            this.storyTeller = new StoryTeller(this.player, this.gameBoard);
            Console.Clear();


            List<GameObject> gameObjects = this.storyTeller.DescribeView();




        }
    }
}
