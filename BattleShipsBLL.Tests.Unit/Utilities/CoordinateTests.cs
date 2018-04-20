using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BattleShipsBLL.Game.Utilities;
using Moq;
using NUnit.Framework;

namespace BattleShipsBLL.Tests.Unit.Utilities
{
    [TestFixture]
    class CoordinateTests
    {
        [TestCase("", 10, 65)]
        [TestCase("123", 10, 65)]
        [TestCase("AA", 10, 65)]
        [TestCase("-1", 10, 65)]
        [TestCase("##", -1, -1)]
        [TestCase("B2", 2, 75)]
        public void InvalidGridReference(string gridReference, int gameHeight, int asciiCharA)
        {
            Coordinate coordinate = new Coordinate();

            Assert.IsFalse(Coordinate.ValidateGridReference(gridReference, ref coordinate, gameHeight, asciiCharA));
        }
    }
}
