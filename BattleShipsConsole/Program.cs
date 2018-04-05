using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleShipsBLL.Game;
using BattleShipsBLL.Game.Utilities;
using static BattleShipsBLL.Game.PlayersBoard;

namespace BattleShipsConsole
{
    class Program
    {
        static GameSettings __gameSettings;
        static GameBoard __gameBoard;
        static Coordinate __coordinate;

        const int __asciiCharA = 65;
        const string __missedShot = "M";
        const string __hit = "(X)";
        private const string __tab = " \t";
        const string __welcome = "Welcome to Battleships! ";
        const string __usernamePrompt = "Please enter a username: ";
        const string __missilePrompt = "Enter your next missile grid reference e.g.A5 : ";
        const string __invalidReference = "Invalid Reference!! ";
        const string __pressAnyKey = "Press any key to continue...";
        const string __winnerMessage = "{0} is the WINNNER!!!\n";
        const string __board = "Board: {0}\n";
        const string __missileResult = "{0} - Missile result: {1} !!!\n";

        public static void Main(string[] args)
        {
            __gameSettings = LoadConfiguration();

            __gameBoard = new GameBoard(__gameSettings);

            Console.Clear();
            Console.WriteLine(__welcome);
            Console.Write(__usernamePrompt);

            if (__gameSettings.Players > 0)
            {
                // add human player, multi player possible but limitation on single player due to console
                __gameBoard.AddPlayerToGame(__gameSettings, Console.ReadLine().ToString());
            }
            
            while (__gameBoard.GetGameStatus() == GameBoard.GameStatus.InProgress)
            {
                // iterate through the list of players until we have a winner
                foreach (Player player in __gameBoard.Players)
                {
                    __coordinate = null;
                    DisplayGameGrid(player);

                    if (player.TypeOfPlayer == Player.PlayerType.Human)
                    {
                        DisplayPromptForMissile();                        
                    }

                    var _missileResponse = player.PlayersBoard.FireMissile(__coordinate);

                    DisplayMissileResult(player, _missileResponse);

                    // check if this was a winning hit
                    if (_missileResponse == MissileResponse.Hit &&
                        __gameBoard.GetGameStatus() == GameBoard.GameStatus.PlayerWins)
                    {
                        DisplayGameGrid(player);
                        Console.WriteLine(String.Format(__winnerMessage, player.Name));                        
                        Console.WriteLine(__pressAnyKey + Environment.NewLine);
                        Console.ReadLine();
                        return;
                    }
                }                
            }
        }

        private static GameSettings LoadConfiguration()
        {
            // TODO: load the config settings from file and set in 
            return new GameSettings();
        }

        private static void DisplayGameGrid(Player player)
        {
            Console.Clear();
            Console.WriteLine(String.Format(__board, player.Name));

            StringBuilder _message = new StringBuilder();

            for (int y = 0; y < __gameSettings.Height; y++)
            {
                _message.Append((__gameSettings.Height - y).ToString());
                _message.Append(__tab);

                for (int x = 0; x < __gameSettings.Width; x++)
                {
                    switch (player.PlayersBoard.BoardCells[y, x].CurrentStatus)
                    {
                        case GameCell.CellStatus.Hit:
                            _message.Append(__hit);
                            break;
                        case GameCell.CellStatus.Miss:
                            _message.Append(__missedShot);
                            break;
                        case GameCell.CellStatus.Ship:
                        case GameCell.CellStatus.Blank:
                        default:
                            _message.Append("");
                            break;
                    }
                    _message.Append(__tab);
                }
                Console.WriteLine(_message);
                _message = new StringBuilder();
            }

            DisplayGameGridFooter();
        }

        private static void DisplayGameGridFooter()
        {
            StringBuilder _message = new StringBuilder(__tab);

            for (int x = 0; x < __gameSettings.Width; x++)
            {
                //use the ascii representation of A and column count to display sequential letters
                _message.Append((char)(__asciiCharA + x)).ToString();
                _message.Append(__tab);
            }
            Console.WriteLine();
            Console.WriteLine(_message);            
            Console.WriteLine();
        }

        private static void DisplayPromptForMissile()
        {

            Console.WriteLine();
            Console.Write(__missilePrompt);

            while (!Coordinate.ValidateGridReference(Console.ReadLine(), ref __coordinate, __gameSettings.Height, __asciiCharA))
            {
                Console.Write(__invalidReference + __missilePrompt);
            }
                
        }

        private static void DisplayMissileResult(Player player, MissileResponse missileResponse)
        {
            DisplayGameGrid(player);
            Console.WriteLine(String.Format(__missileResult, player.Name, missileResponse));
            Console.WriteLine(__pressAnyKey + Environment.NewLine);
            Console.ReadLine();
        }
    }
}
