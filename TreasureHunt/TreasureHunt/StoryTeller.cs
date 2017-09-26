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
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);

        }

        private void PrintPlayerInfo()
        {

            int curCursorX = Console.CursorLeft, curCursorY = Console.CursorTop;
            ConsoleColor backColor = Console.BackgroundColor;

            //clear screen
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth * (this.gameBoard.Height + 2)));

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            string info = $"Name: {this.player.Name}     Score: {this.player.Score}     Coins: {this.player.Coins}";
            string emptySpaces = new string(' ', Console.WindowWidth - info.Length);
            Console.Write($"{info}{emptySpaces}");

            Console.BackgroundColor = backColor;
            Console.WriteLine($"{this.gameBoard.GetMap(this.player)}");


            Console.SetCursorPosition(curCursorX, curCursorY);

        }

        public void Speak(string message)
        {
            if (Console.CursorTop < this.gameBoard.Height + 2)
                Console.CursorTop = this.gameBoard.Height + 2;

            Console.Write(message);
            PrintPlayerInfo();
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public List<Option> DescribeView()
        {
            List<GameObject> gameObjects = new List<GameObject>();

            gameObjects.Add(this.gameBoard.GetObject(this.player.X, this.player.Y));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X, this.player.Y - 1));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X + 1, this.player.Y));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X, this.player.Y + 1));
            gameObjects.Add(this.gameBoard.GetObject(this.player.X - 1, this.player.Y));

            GameObject[] sortedGameObjects = new GameObject[5];

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
                else
                    sortedGameObjects[4] = gameObject;
            }

            //Output the view and retrive all options for all gameobjects
            List<Option> options = new List<Option>();
            foreach (GameObject gameObject in sortedGameObjects)
            {
                this.Speak($"{gameObject.GetView(player)} ");
                List<Option> currentOptions = gameObject.GetOptions(this.player, this.gameBoard);
                options.AddRange(currentOptions);
            }

            return options;
        }

        private string GetOptionKeys(List<Option> options)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Option option in options)
            {
                sb.Append($"| {option.Key} ");
            }
            sb.Append("|");

            return sb.ToString();
        }

        public Option GetChoice(List<Option> options)
        {
            this.Speak($"\r\n\r\nVad vill du göra? {this.GetOptionKeys(options)}\r\n");

            Option selectedOption = null;

            do
            {
                string userInput = this.GetInput();

                foreach (Option option in options)
                {
                    if (userInput.ToUpper() == option.Key.ToUpper())
                    {
                        selectedOption = option;
                        break;
                    }
                }
                if (selectedOption == null)
                    this.Speak($"\r\n{userInput} är inget giltigt val.\r\nVälj mellan: {this.GetOptionKeys(options)}\r\n");
            }
            while (selectedOption == null);

            return selectedOption;
        }
    }
}
