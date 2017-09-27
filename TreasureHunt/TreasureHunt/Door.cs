using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class Door : GameObject
    {
        public Door(string title, string key, string description, int x, int y) : base(title, key, description, x, y)
        {

        }

        public override List<Option> GetOptions(Player player, GameBoard gameBoard)
        {
            List<Option> options = new List<Option>();

            if (this.IsToTheRight(player))
                options.Add(new Option("Gå ut genom dörren till höger", () =>
                {
                    int oldGameBoardKey = player.GameBoardKey;

                    if (!int.TryParse(this.Key[this.Key.Length - 1].ToString(), out int newGameBoardKey))
                        throw new Exception($"Unable to parse door.key: {this.Key}");

                    player.GameBoardKey = newGameBoardKey;
                    player.GameBoards[player.GameBoardKey].SetPlayerAround(player, oldGameBoardKey.ToString()[0]);

                    return "Du går ut genom dörren till höger.";

                }));
            else if (this.IsToTheLeft(player))
                options.Add(new Option("Gå ut genom dörren till vänster", () =>
                {
                    int oldGameBoardKey = player.GameBoardKey;

                    if (!int.TryParse(this.Key[this.Key.Length - 1].ToString(), out int newGameBoardKey))
                        throw new Exception($"Unable to parse door.key: {this.Key}");

                    player.GameBoardKey = newGameBoardKey;
                    player.GameBoards[player.GameBoardKey].SetPlayerAround(player, oldGameBoardKey.ToString()[0]);

                    return "Du går ut genom dörren till vänster.";
                }));

            else if (this.IsInFront(player))
                options.Add(new Option("Gå ut genom dörren framför dig", () =>
                {
                    int oldGameBoardKey = player.GameBoardKey;

                    if (!int.TryParse(this.Key[this.Key.Length - 1].ToString(), out int newGameBoardKey))
                        throw new Exception($"Unable to parse door.key: {this.Key}");

                    player.GameBoardKey = newGameBoardKey;
                    player.GameBoards[player.GameBoardKey].SetPlayerAround(player, oldGameBoardKey.ToString()[0]);

                    return "Du går ut genom dörren framför dig.";
                }));
            else if (this.IsBehind(player))
                options.Add(new Option("Gå ut genom dörren bakom dig", () =>
                {
                    int oldGameBoardKey = player.GameBoardKey;

                    if (!int.TryParse(this.Key[this.Key.Length - 1].ToString(), out int newGameBoardKey))
                        throw new Exception($"Unable to parse door.key: {this.Key}");

                    player.GameBoardKey = newGameBoardKey;
                    player.GameBoards[player.GameBoardKey].SetPlayerAround(player, oldGameBoardKey.ToString()[0]);

                    return "Du går ut genom dörren bakom dig.";
                }));


            return options;
        }

        public override string GetView(Player player)
        {
            if (this.IsToTheRight(player))
                return "Till höger om dig finns en dörr.";
            else if (this.IsToTheLeft(player))
                return "Till vänster om dig finns en dörr.";
            else if (this.IsInFront(player))
                return "Framför dig finns en dörr.";
            else if (this.IsBehind(player))
                return "Bakom dig finns en dörr.";
            else
                return "";
        }

        public override GameObject TryCreateFromChar(char ch, int x, int y)
        {
            if (ch >= '0' && ch <= '6')
                return new Door("dörr", $"dörr{ch.ToString()[0]}", "en gammal trädörr med rostiga gångjärn", x, y);
            else
                return null;
        }
    }
}
