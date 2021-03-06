﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    class TreasureHunt
    {
        Player player;
        Dictionary<int, GameBoard> gameBoards;
        GameBoard currentGameBoard;
        StoryTeller storyTeller;

        public TreasureHunt(GameBoard gameBoard, params GameBoard[] gameBoards)
        {
            this.gameBoards = new Dictionary<int, GameBoard>();
            this.gameBoards.Add(gameBoard.Key, gameBoard);

            foreach (GameBoard currentGameBoard in gameBoards)
                this.gameBoards.Add(currentGameBoard.Key, currentGameBoard);
        }

        private void InitPlayer(Player player)
        {
            this.player = player;
            this.player.Score = 0;
            this.player.Coins = 0;
            this.player.GameBoards = this.gameBoards;

            foreach (KeyValuePair<int, GameBoard> gameBoard in gameBoards)
            {
                if (gameBoard.Value.SetPlayerCordinates(this.player))
                    return;
            }

            throw new Exception("Unable to find player symbol in game boards.");
        }

        public void Run(Player player)
        {

            InitPlayer(player);
            this.currentGameBoard = this.gameBoards[this.player.GameBoardKey];
            this.storyTeller = new StoryTeller();
            Console.Clear();
            this.storyTeller.DescribeGameBoard(this.player, this.currentGameBoard);

            while (true)
            {

                List<Option> options = this.storyTeller.DescribeView(this.player, this.currentGameBoard);
                //get inventory options
                List<Option> inventoryOptions = player.gameObjects
                             .Where(kvp => kvp.Value.GetOptions(this.player, this.currentGameBoard).Count > 0)
                             .Select(kvp => kvp.Value.GetOptions(this.player, this.currentGameBoard))
                             .SelectMany(x=>x).ToList();
                //add inventory options
                options.AddRange(inventoryOptions);

                Option selectedOption = this.storyTeller.GetChoice(this.player, this.currentGameBoard, options);

                string confirmMessage = selectedOption.Execute();

                if (this.currentGameBoard != this.gameBoards[this.player.GameBoardKey])
                {
                    currentGameBoard = this.gameBoards[this.player.GameBoardKey];

                    Console.Clear();

                    storyTeller.Speak(this.player, this.currentGameBoard, $"\r\n{confirmMessage}\r\n\r\n");
                    this.storyTeller.DescribeGameBoard(this.player, this.currentGameBoard);
                    continue;
                }

                storyTeller.Speak(this.player, this.currentGameBoard, $"\r\n{confirmMessage}\r\n\r\n");

                if (this.player.Won)
                {
                    storyTeller.Speak(this.player, this.currentGameBoard, $"Grattis {this.player.Name}, du har vunnit!!");
                    return;
                }

                if (this.player.Lost)
                {
                    storyTeller.Speak(this.player, this.currentGameBoard, $"F**ck {this.player.Name}, du har förlorat stort...");
                    return;
                }                

            }

        }
    }
}
