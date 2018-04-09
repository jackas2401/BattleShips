using BattleShipsBLL.Game;
using System;

namespace BattleShipsBLL.Game.Utilities
{
    /// <summary>
    /// Utility class for storing x and y coordinates
    /// </summary>
    public class Coordinate
    {
        private int _x;
        private int _y;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        /// <summary>
        /// Validate the grid reference entered by a user
        /// </summary>
        /// <param name="gridReference"></param>
        /// <param name="coordinate"></param>
        /// <param name="gameHeight"></param>
        /// <param name="asciiCharA"></param>
        /// <returns></returns>
        public static bool ValidateGridReference(string gridReference, ref Coordinate coordinate, int gameHeight, int asciiCharA)
        {
            try
            {
                char _xCoordinate = char.Parse(gridReference.Trim().Substring(0, 1).ToUpper());
                int _yCoordinate = int.Parse(gridReference.Trim().Substring(1));

                coordinate = new Coordinate
                {
                    X = ((int)_xCoordinate - asciiCharA),
                    Y = gameHeight - _yCoordinate
                };

                if (!(coordinate.X >= 0 && coordinate.X < gameHeight))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
