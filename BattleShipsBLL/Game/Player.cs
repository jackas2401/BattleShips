using System;

namespace BattleShipsBLL.Game
{
    /// <summary>
    /// Stores all the details associated with a player
    /// A game can several players playing at once
    /// </summary>
    public class Player
    {
        public enum PlayerType { Human = 0, CPU = 1 };
        private const string __defaultPlayersName = "Default Name";

        private PlayersBoard __playersBoard;
        private String __name;        
        private PlayerType __typeOfPlayer;


        public PlayersBoard PlayersBoard { get => __playersBoard; }
        public string Name { get => __name; set => __name = value; }
        public PlayerType TypeOfPlayer { get => __typeOfPlayer; set => __typeOfPlayer = value; }

        public static string DefaultPlayersName => __defaultPlayersName;

        /// <summary>
        /// Default constructructor for creating a new player for the game
        /// </summary>
        /// <param name="gameSettings">Settings allow the player to be set-up correctly the game being played</param>
        /// <param name="playersName">Identifer for the player, user input for human, random for CPU</param>
        /// <param name="playerType">Specify whether your are creating a human or cpu player</param>
        public Player(GameSettings gameSettings, string playersName, PlayerType playerType)
        {
            // check for null
            if (String.IsNullOrEmpty(playersName))
            {
                playersName = __defaultPlayersName;
            }

            // trim the name and ensure we have a valid name
            playersName = playersName.Trim();

            if (String.IsNullOrEmpty(playersName))
            {
                playersName = __defaultPlayersName;
            }

            __name = playersName;
            __typeOfPlayer = playerType;
            __playersBoard = new PlayersBoard(gameSettings);
        }        
    }
}
