using BattleShipsBLL.Game.Utilities;
using BattleShipsBLL.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsBLLTest.Ships
{
    public class BattleShipTestData
    {
        private static bool[,] __northShape = new bool[3, 2] { { false, true }, { true, true }, { true, true } };
        private static bool[,] __southShape = new bool[3, 2] { { true, true }, { true, true }, { true, false } };
        private static bool[,] __eastShape = new bool[2, 3] { { true, true, false }, { true, true, true } };
        private static bool[,] __westShape = new bool[2, 3] { { true, true, true }, { false, true, true } };

        private static Coordinate __startCoordinate = new Coordinate { X = 0, Y = 0 };
        private static Coordinate __endCoordinateVertical = new Coordinate { X = 1, Y = 2 };
        private static Coordinate __endCoordinateHorizontal = new Coordinate { X = 2, Y = 1 };
        
        public static IEnumerable<object[]> GetData =>
        new List<object[]>
        {
            new object[] { BattleShip.Direction.North,  __northShape },
            new object[] { BattleShip.Direction.South,  __southShape },
            new object[] { BattleShip.Direction.East,  __eastShape },
            new object[] { BattleShip.Direction.West,  __westShape },
        };

        public static IEnumerable<object[]> GetRandomPositionStartCoordinates =>
        new List<object[]>
        {
            new object[] { BattleShip.Direction.North, __startCoordinate, 2, 3},
            new object[] { BattleShip.Direction.West,  __startCoordinate, 3, 2},
        };

        public static IEnumerable<object[]> GetRandomPositionEndCoordinates =>
        new List<object[]>
        {
            new object[] { BattleShip.Direction.North, __endCoordinateVertical, 2, 3},
            new object[] { BattleShip.Direction.West, __endCoordinateHorizontal, 3, 2},
        };
    }
}
