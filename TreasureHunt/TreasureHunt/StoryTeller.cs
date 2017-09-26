using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class StoryTeller
    {

        public StoryTeller()
        {

            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);

        }

        private void PrintPlayerInfo(Player player, GameBoard gameBoard)
        {

            int curCursorX = Console.CursorLeft, curCursorY = Console.CursorTop;
            ConsoleColor backColor = Console.BackgroundColor;

            //clear screen
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth * (gameBoard.Height + 2)));

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            string info = $"Name: {player.Name}     Score: {player.Score}     Coins: {player.Coins}";
            string emptySpaces = new string(' ', Console.WindowWidth - info.Length);
            Console.Write($"{info}{emptySpaces}");

            Console.BackgroundColor = backColor;
            Console.WriteLine($"{gameBoard.GetMap(player)}");


            Console.SetCursorPosition(curCursorX, curCursorY);

        }

        public void Speak(Player player, GameBoard gameBoard, string message)
        {
            if (Console.CursorTop < gameBoard.Height + 2)
                Console.CursorTop = gameBoard.Height + 2;

            Console.Write(message);
            PrintPlayerInfo(player, gameBoard);
        }

        public void DescribeGameBoard(Player player, GameBoard gameBoard)
        {
            this.Speak(player, gameBoard, $"Du befinner dig i {gameBoard.Description}.\r\n\r\n");
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public List<Option> DescribeView(Player player, GameBoard gameBoard)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            gameObjects.Add(gameBoard.GetObject(player.X, player.Y));
            gameObjects.Add(gameBoard.GetObject(player.X, player.Y - 1));
            gameObjects.Add(gameBoard.GetObject(player.X + 1, player.Y));
            gameObjects.Add(gameBoard.GetObject(player.X, player.Y + 1));
            gameObjects.Add(gameBoard.GetObject(player.X - 1, player.Y));

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
                this.Speak(player, gameBoard, $"{gameObject.GetView(player)} ");
                List<Option> currentOptions = gameObject.GetOptions(player, gameBoard);
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

        public Option GetChoice(Player player, GameBoard gameBoard, List<Option> options)
        {
            this.Speak(player, gameBoard, $"\r\n\r\nVad vill du göra? {this.GetOptionKeys(options)}\r\n");

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
                    this.Speak(player, gameBoard, $"\r\n{userInput} är inget giltigt val.\r\nVälj mellan: {this.GetOptionKeys(options)}\r\n");
            }
            while (selectedOption == null);

            return selectedOption;
        }
    }
}
