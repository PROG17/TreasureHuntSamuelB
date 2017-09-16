using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard("xxxxxx"+
                                                "x p  x"+
                                                "xx x x"+
                                                "xxxxxx", 6);

            TreasureHunt treasureHunt = new TreasureHunt(gameBoard);
            Player player = new Player("Samuel"); 
            treasureHunt.Run(player);

            Console.ReadKey();

        }
    }
}
