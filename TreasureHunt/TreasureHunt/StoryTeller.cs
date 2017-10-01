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
            this.Speak(player, gameBoard, $"{new string('-', Console.WindowWidth)}");
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

        private Option MatchOptionStrings(string userInput, List<Option> options)
        {
            List<string> optionStrings = options.Select(option => option.Key.Replace(" ", "").ToUpper()).ToList();

            if (optionStrings.ContainsSingle(userInput.ToUpper(), out int index))
                return options[index];
            else
                return null;

        }

        private Option MatchOptionCkeys(ConsoleKeyInfo cki, List<Option> options)
        {
            List<Option> optionsWithCkey = options.Where(option => option.CKey != ConsoleKey.X).ToList();

            foreach (Option option in optionsWithCkey)
            {
                if (cki.Key == option.CKey)
                    return option;
            }
            return null;
        }

        public Option GetChoice(Player player, GameBoard gameBoard, List<Option> options)
        {
            this.Speak(player, gameBoard, $"\r\n\r\nVad vill du göra? {this.GetOptionKeys(options)}\r\n");

            Option selectedOption = null;

            string userInput = "";

            do
            {
                userInput = StringExtensions.GetInput(userInput, out ConsoleKeyInfo cki);

                if (cki.Key == ConsoleKey.Enter)
                {
                    selectedOption = MatchOptionStrings(userInput, options);
                    if (selectedOption != null)
                        break;
                    else
                    {
                        this.Speak(player, gameBoard, $"\r\n{userInput} är inget giltigt val.\r\nVälj mellan: {this.GetOptionKeys(options)}\r\n");
                        userInput = "";
                    }
                }
                else
                {
                    selectedOption = MatchOptionCkeys(cki, options);
                    if (selectedOption != null)
                        break;                    
                }
            }
            while (selectedOption == null);

            return selectedOption;
        }
    }
}
