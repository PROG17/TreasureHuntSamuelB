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

        public GameObject GetObject(int x, int y)
        {
            int index = y * this.width + x;
            if (index < 0 || index > board.Length - 1)
                throw new ArgumentException("The provided x and y cordinates is out range.");

            char ch = board[index];
            switch (ch)
            {
                case 'x':
                    return new Wall("Vägg",x,y);

            }
        }


    }
}
