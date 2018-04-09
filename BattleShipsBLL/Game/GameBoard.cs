using System.Collections.Generic;

namespace BattleShipsBLL.Game
{
    /// <summary>
    /// Gameboard will control the state of the players game
    /// Coordinates the processing between multiple players
    /// Controls the overall game status
    /// Currently the game completes when the first user completes the board
    /// </summary>
    public class GameBoard
    {
        public enum GameStatus { InProgress = 0, PlayerWins = 1 };
        private enum CpuNames { Anthony }

        private List<Player> __players = new List<Player>();       
        public List<Player> Players { get => __players; }


        /// <summary>
        /// Allow gameboard to be created with default game settings
        /// </summary>
        public GameBoard() : this(new GameSettings())
        {}

        /// <summary>
        /// Constructor for creating a new gameboard
        /// Immediately create all the CPU players as no user input required
        /// </summary>
        /// <param name="gameSettings">Consumer can use custom game settings</param>
        public GameBoard(GameSettings gameSettings)
        {
            string _name;
            // generate CPU players
            for (int i = 0; i < gameSettings.CpuPlayers; i++)
            {
                _name = "CPU " + i.ToString() + " " + CpuNames.Anthony.ToString();
                __players.Add(new Player(gameSettings, _name, Player.PlayerType.CPU));
            }
        }

        /// <summary>
        /// Currently we need to capture username from UI
        /// There's no reason you coulldn't have multiple human players 
        /// UI would need to handle multiple players
        /// </summary>
        /// <param name="gameSettings">Consumer can use custom game settings</param>
        /// <param name="name">Players name supplied by user input</param>
        public void AddPlayerToGame(GameSettings gameSettings, string name)
        {
            __players.Add(new Player(gameSettings, name, Player.PlayerType.Human));
        }

        /// <summary>
        /// This will allow the caller to determine if we have a winnner
        /// </summary>
        /// <returns>In-progress or Winner</returns>
        public GameStatus GetGameStatus()
        {
            foreach (Player player in __players)
            {
                if (player.PlayersBoard.GetBoardStatus() == PlayersBoard.BoardStatus.Complete)
                {
                    return GameStatus.PlayerWins;
                }
            }
            return GameStatus.InProgress;            
        }
    }
}