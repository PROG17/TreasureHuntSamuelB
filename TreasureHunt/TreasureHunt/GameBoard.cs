using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class GameBoard
    {
        string board;
        int width, height;
        IGameObjectFactory[] gameObjectFactories;
        public string Title { get; set; }
        public int Key { get; set; }
        public string Description { get; set; }

        public GameBoard(string title, string description, int key, string board, int width, IGameObjectFactory[] gameObjectFactories)
        {
            this.Title = title;
            this.Description = description;
            this.Key = key;
            this.board = board;
            this.width = width;
            this.height = board.Length / width;
            this.gameObjectFactories = gameObjectFactories;
        }

        public string Board
        {
            get
            {
                return this.board;
            }

            set
            {
                this.board = value;
            }

        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }

        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }

        }

        public GameObject GetObject(int x, int y)
        {
            int index = y * this.width + x;
            if (index < 0 || index > board.Length - 1)
                throw new ArgumentException("The provided x and y cordinates is out range.");

            char ch = board[index];

            GameObject gObject = null;
            foreach (IGameObjectFactory gameObjectFactory in this.gameObjectFactories)
            {
                gObject = gameObjectFactory.TryCreateFromChar(ch, x, y);
                if (gObject != null)
                    return gObject;
            }

            throw new Exception($"Invalid character: {ch} in board. No factory method is provided for character: {ch}");
        }

        public bool SetPlayerCordinates(Player player)
        {
            int index = this.board.IndexOf('p');
            if (index == -1)
                return false;

            player.X = index % this.width;
            player.Y = index / this.width;
            player.GameBoardKey = this.Key;
            board = board.ReplaceAt(index, ' ');

            return true;
        }

        public string GetMap(Player player)
        {

            char playerSymbol = default(char);

            switch (player.direction)
            {
                case Player.Direction.North:
                    playerSymbol = '\u2191';
                    break;
                case Player.Direction.East:
                    playerSymbol = '\u2192';
                    break;
                case Player.Direction.South:
                    playerSymbol = '\u2193';
                    break;
                case Player.Direction.West:
                    playerSymbol = '\u2190';
                    break;
            }

            string result = this.Board.ReplaceAt(player.Y * this.Width + player.X, playerSymbol);

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    sb.Append(result[y * this.width + x]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }


    }
}
