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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IGameObjectFactory[] gameObjectFactories = new IGameObjectFactory[]
            {
                new Coin(null, null, null, 0, 0),
                new EmptySpace(null, null, null, 0, 0),
                new Treasure(null, null, null, 0, 0),
                new Wall(null, null, null, 0, 0),
                new TreasureKey(null, null, null, 0, 0)
            };

            GameBoard gameBoard = new GameBoard("xxxxxx" +
                                                "x p kx" +
                                                "xt xcx" +
                                                "xc c x" +
                                                "xxxxxx", 6, gameObjectFactories);

            TreasureHunt treasureHunt = new TreasureHunt(gameBoard);
            Player player = new Player("Samuel");
            treasureHunt.Run(player);

            Console.ReadKey();

        }
    }
}
