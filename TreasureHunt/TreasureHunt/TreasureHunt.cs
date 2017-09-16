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
            this.player.Score = 10;
            this.player.Coins = 5;
            this.gameBoard.SetPlayerCordinates(this.player);
            this.storyTeller = new StoryTeller(this.player, this.gameBoard);
            Console.Clear();

            while (true)
            {

                List<GameObject> gameObjects = this.storyTeller.DescribeView();

                GameObject selectedGameObject = this.storyTeller.GetChoice(gameObjects);

                string confirmMessage = selectedGameObject.Execute(this.player, this.gameBoard);

                storyTeller.Speak($"\r\n{confirmMessage}\r\n\r\n");

                if (this.player.Won)
                {
                    storyTeller.Speak($"Grattis {this.player.Name}, du har vunnit!!");
                    return;
                }

                if (this.player.Lost)
                {
                    storyTeller.Speak($"F**ck {this.player.Name}, du har förlorat stort...");                
                    return;
                }

            }

        }
    }
}
