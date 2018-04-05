namespace BattleShipsBLL.Game
{
    /// <summary>
    /// Store configurable settings for the game being played
    /// Set-up with defaults but allow overrides
    /// Could be enhances to allow user to update these settings
    /// Application playing the game can change how the game behaves
    /// </summary>
    public class GameSettings
    {
        private const int __defaultBoardSize = 10;
        private const int __defaultBattleShips = 1;
        private const int __defaultDestroyers = 2;
        private const int __defaultPlayers = 1;                 
        private const int __defaultCpuPlayers = 1;              

        private int __width = __defaultBoardSize;
        private int __height = __defaultBoardSize;
        private int __battleShipsCount = __defaultBattleShips;
        private int __destroyer = __defaultDestroyers;
        private int __players = __defaultPlayers;
        private int __cpuPlayers = __defaultCpuPlayers;

        /// <summary>
        /// Height of the players game grid you want create Y-axis
        /// </summary>
        public int Height { get => __height; set => __height = value; }
        
        /// <summary>
        /// Height of the players game grid you want create X-axis
        /// </summary>
        public int Width { get => __width; set => __width = value; }
        
        /// <summary>
        /// Dictates how many Battleships will be randomly places on players board
        /// </summary>
        public int BattleShipsCount { get => __battleShipsCount; set => __battleShipsCount = value; }
        
        /// <summary>
        /// Dictates how many Destroyers will be randomly places on players board
        /// </summary>
        public int DestroyerCount { get => __destroyer; set => __destroyer = value; }
        
        /// <summary>
        /// Number of human players you want to create at the start of the game
        /// This can be 0 if you want to just watch the computer play
        /// </summary>
        public int Players { get => __players; set => __players = value; }
        
        /// <summary>
        /// Number of CPU players you want to create at the start of the game
        /// This can be 0 if you want human players
        /// </summary>
        public int CpuPlayers { get => __cpuPlayers; set => __cpuPlayers = value; }
    }
}
