using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Program
    {
        static string InputPlayerName()
        {
            string name="";
            do
            {
                Console.Write("Skriv in ditt namn: ");
                name = Console.ReadLine();

                if (name.Length > 2)
                    return name;
                else
                    Console.WriteLine("Namnet måste vara minst tre bokstäver långt.");
            }
            while (true);

        }

        static void Main(string[] args)

        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IGameObjectFactory[] gameObjectFactories = new IGameObjectFactory[]
            {
                new Coin(null, null, null, 0, 0),
                new EmptySpace(null, null, null, 0, 0),
                new Treasure(null, null, null, 0, 0),
                new Wall(null, null, null, 0, 0),
                new TreasureKey(null, null, null, 0, 0),
                new Door(null, null, null, 0, 0),
                new Spring(null, null, null, 0, 0),
                new SandPaper(null, null, null, 0, 0)
            };

            GameBoard smallCellarRoom = new GameBoard("Litet källarrum", "ett litet källarrum med gråa betongvägger så långt ögat kan nå", 0,
                                                "x1xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                                                "x  c                                      x" +
                                                "x  xcxxxxxxxxxxxxxxxxx                 t  x" +
                                                "x  c x               x                    x" +
                                                "xxxxxx               xxxxxxxxxxxxxx2xxxxxxx", 43, gameObjectFactories);

            GameBoard bigCellarRoom = new GameBoard("Stort källarrum", "ett stort källarrum med en hel del gammal bråte", 1,
                                                "xxxxx0xxxxxx" +
                                                "x       c  x" +
                                                "x xxxx     x" +
                                                "x  c xxx   x" +
                                                "x  x    x  2" +
                                                "x  c    S  x" +
                                                "xxxxxxxxxxxx", 12, gameObjectFactories);

            GameBoard RectangularCellarRoom = new GameBoard("Avlångt källarrum", "ett avlångt källarrum där luften luktar unken, här verkar ingen ha varit på mycket länge", 2,
                                               "xxxxx1xxxxxxxxxxxxxxxxx" +
                                               "x  c   x   kx     p   x" +
                                               "x  x  c   s    0x   c x" +
                                               "xxxxxxxxxxxxxxxxxxxxxxx",
                                                23, gameObjectFactories);


            TreasureHunt treasureHunt = new TreasureHunt(smallCellarRoom, bigCellarRoom, RectangularCellarRoom);

            Console.Clear();
            Console.WriteLine("*** Välkommen till spelet Treasure Hunt! ***\r\n");
            Player player = new Player(InputPlayerName());
            treasureHunt.Run(player);

            Console.ReadKey();

        }
    }
}
