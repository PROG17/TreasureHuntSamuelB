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

        public void Speak(string message)
        {
            Console.Write(message);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public List<GameObject> DescribeView()
        {
            List<GameObject> gameObjects = new List<GameObject>();

            gameObjects.Add(this.gameBoard.GetObject(this.player.X, this.player.Y - 1));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X + 1, this.player.Y));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X, this.player.Y + 1));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X - 1, this.player.Y));

            GameObject[] sortedGameObjects = new GameObject[4];

            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.IsInFront(player))
                    sortedGameObjects[0] = gameObject;
                else if (gameObject.IsToTheRight(player))
                    sortedGameObjects[1] = gameObject;
                else if (gameObject.IsBehind(player))
                    sortedGameObjects[3] = gameObject;
                else if (gameObject.IsToTheLeft(player))
                    sortedGameObjects[2] = gameObject;
            }

            foreach (GameObject gameObject in sortedGameObjects)
                this.Speak($"{gameObject.GetView(player)} ");


            return sortedGameObjects.ToList();
        }

        private string GetOptions(List<GameObject> gameObjects)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gameObject in gameObjects)
            {
                sb.Append($"| {gameObject.GetOption(player)} ");
            }
            sb.Append("|");

            return sb.ToString();
        }

        public GameObject GetChoice(List<GameObject> gameObjects)
        {
            this.Speak($"\r\n\r\nVad vill du göra? {this.GetOptions(gameObjects)}\r\n");

            GameObject selectedGameObject = null;

            do
            {
                string userInput = this.GetInput().ToUpper();

                foreach (var gameObject in gameObjects)
                {
                    if (userInput == gameObject.GetOption(player).ToUpper())
                    {
                        selectedGameObject = gameObject;
                        break;
                    }
                }
                if (selectedGameObject == null)
                    this.Speak($"\r\n{userInput} är inget giltigt val.\r\nVälj mellan: {this.GetOptions(gameObjects)}\r\n");
            }
            while (selectedGameObject == null);

            return selectedGameObject;
        }
    }
}
