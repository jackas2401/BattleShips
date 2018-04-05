using BattleShipsBLL.Game.Utilities;
using System;
using Xunit;

namespace BattleShipsBLLTest.Utilities
{
    public class CoordinateTest
    {
        [Theory]
        [InlineData("", 10, 65)]
        [InlineData("123", 10, 65)]
        [InlineData("AA", 10, 65)]
        [InlineData("-1", 10, 65)]
        [InlineData("##", -1, -1)]
        [InlineData("B2", 2, 75)]
        public void ValidateGridReferenceInvalid(string gridReference, int gameHeight, int asciiCharA)
        {
            Coordinate _coordinate = new Coordinate();

            Assert.False(Coordinate.ValidateGridReference(gridReference, ref _coordinate, gameHeight, asciiCharA));
        }

        [Theory]
        [InlineData("A1", 10, 65)]
        [InlineData("J10", 10, 65)]
        [InlineData("F2", 2, 70)]  
        public void ValidateGridReferenceValid(string gridReference, int gameHeight, int asciiCharA)
        {
            Coordinate _coordinate = new Coordinate();

            Assert.True(Coordinate.ValidateGridReference(gridReference, ref _coordinate, gameHeight, asciiCharA));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -2)]
        [InlineData(1, 2)]
        public void ValidateGridReferenceProps(int xCoord, int yCoord)
        {
            Coordinate _coordinate = new Coordinate();

            _coordinate.X = xCoord;
            _coordinate.Y = yCoord;

            Assert.True(_coordinate.X == xCoord && _coordinate.Y == yCoord);
        }

    }
}
