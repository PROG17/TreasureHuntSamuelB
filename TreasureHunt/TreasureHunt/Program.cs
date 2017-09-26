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

            GameBoard smallCellarRoom = new GameBoard("Litet källarrum", "ett litet källarrum med gråa betongvägger så långt ögat kan nå", 0,
                                                "xxxxxx" +
                                                "x    x" +
                                                "x  xcx" +
                                                "xc c x" +
                                                "xxxxxx", 6, gameObjectFactories);

            GameBoard bigCellarRoom = new GameBoard("Stort källarrum", "ett stort källarrum med en hel del gammal bråte", 1,
                                                "xxxxxxxxxxxx" +
                                                "x   p   c  x" +
                                                "x xxxx   t x" +
                                                "x  c xxx   x" +
                                                "x  x k  x  x" +
                                                "x  c       x" +
                                                "xxxxxxxxxxxx", 12, gameObjectFactories);


            TreasureHunt treasureHunt = new TreasureHunt(smallCellarRoom, bigCellarRoom);
            Player player = new Player("Samuel");
            treasureHunt.Run(player);

            Console.ReadKey();

        }
    }
}
