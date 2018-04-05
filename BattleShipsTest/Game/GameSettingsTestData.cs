using BattleShipsBLL.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsBLLTest.Game
{
    class GameSettingsTestData
    {
        public static IEnumerable<object[]> GetData =>
        new List<object[]>
        {
            new object[] { new GameSettings { Height = 10, Width = 10, BattleShipsCount = 1, DestroyerCount = 2, CpuPlayers = 1, Players = 2 } },            
        };

        public static IEnumerable<object[]> GetSmallFixedGame =>
        new List<object[]>
        {
            new object[] { new GameSettings { Height = 2, Width = 2, BattleShipsCount = 0, DestroyerCount = 1, CpuPlayers = 1, Players = 0 } },
        };

        public static IEnumerable<object[]> GetSmallFixedGameNoShips =>
        new List<object[]>
        {
            new object[] { new GameSettings { Height = 2, Width = 2, BattleShipsCount = 0, DestroyerCount = 0, CpuPlayers = 1, Players = 0 } },
        };

        public static IEnumerable<object[]> GetImpossibleBoardTooManyShapes =>
        new List<object[]>
        {
            new object[] { new GameSettings { Height = 2, Width = 2, BattleShipsCount = 100, DestroyerCount = 100, CpuPlayers = 1, Players = 0 } },
        };
    }
}
