using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class StoryTeller
    {
        Player player;
        GameBoard gameBoard;

        public StoryTeller(Player player, GameBoard gameBoard)
        {
            this.player = player;
            this.gameBoard = gameBoard;
        }

        public List<GameObject> DescribeView()
        {
            List<GameObject> gameObjects = new List<GameObject>();

            gameObjects.Add(this.gameBoard.GetObject(this.player.X, this.player.Y - 1));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X + 1, this.player.Y));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X, this.player.Y + 1));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X - 1, this.player.Y));

            GameObject isInFrontObj = null, isToTheRightObj = null, isBehindObj = null, isToTheLeftObj = null;

            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.IsInFront(player))
                    isInFrontObj = gameObject;
                else if (gameObject.IsToTheRight(player))
                    isToTheRightObj = gameObject;
                else if (gameObject.IsBehind(player))
                    isBehindObj = gameObject;
                else if (gameObject.IsToTheLeft(player))
                    isToTheLeftObj = gameObject;
            }

            if (isInFrontObj.Title == "vägg")
                Console.Write("Du står framför en vägg. ");
            else if (isInFrontObj.Title == "rum")
                Console.Write("Du står i ett rum.");

            if (isToTheRightObj.Title == "vägg")
                Console.WriteLine("Till höger om dig finns en vägg och ");
            else if (isToTheRightObj.Title == "rum")
                Console.WriteLine("Till höger om dig är det tomt och ");


            return gameObjects;
        }
    }
}
