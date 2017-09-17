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

        public GameBoard(string board, int width)
        {
            this.board = board;
            this.width = width;
            this.height = board.Length / width;
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

        public GameObject GetObject(int x, int y)
        {
            int index = y * this.width + x;
            if (index < 0 || index > board.Length - 1)
                throw new ArgumentException("The provided x and y cordinates is out range.");

            char ch = board[index];
            switch (ch)
            {
                case 'x':
                    return new Wall("vägg",x,y);
                case ' ':
                    return new EmptySpace("rum", x, y);
                case 'c':
                    return new Coin("mynt", x, y);
                case 's':
                    return new Treasure("skattkista", x, y);
                default:
                    throw new Exception($"Invalid character: {ch} in board.");

            }
        }

        public void SetPlayerCordinates(Player player)
        {
            int index = this.board.IndexOf('p');
            if (index == -1)
                throw new Exception("Unable to find player in board.");

            player.X = index % this.width;
            player.Y = index / this.width;
            board = board.ReplaceAt(index, ' ');
        }


    }
}
