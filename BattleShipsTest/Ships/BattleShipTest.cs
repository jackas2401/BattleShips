using BattleShipsBLL.Ships;
using BattleShipsBLL.Game.Utilities;
using BattleShipsBLLTest.Mock;
using System;
using System.Collections.Generic;
using Xunit;

namespace BattleShipsBLLTest.Ships
{
    
    public class BattleShipTest
    {
        
        [Theory]
        [MemberData(nameof(BattleShipTestData.GetData), MemberType = typeof(BattleShipTestData))]       
        public void ValidateDrawDirectionShape(BattleShip.Direction shipDirection, bool[,] expectedShape)
        {
            RandomMock _random = new RandomMock((int)shipDirection);

            BattleShip _battleShip = new BattleShip(_random);
            
            Assert.Equal(_battleShip.GetShape(), expectedShape);
        }

        // test that settinng position works and coordinates are set correctly.
        [Theory]
        [MemberData(nameof(BattleShipTestData.GetRandomPositionStartCoordinates), MemberType = typeof(BattleShipTestData))]
        public void ValidateStartCoordinates(BattleShip.Direction shipDirection, Coordinate startCoordinate, int boardWidth, int boardHeight)
        {
            RandomMock _randomMock = new RandomMock((int) shipDirection);

            BattleShip _battleShip = new BattleShip(_randomMock);

            _randomMock = new RandomMock(0);

            _battleShip.PickRandomPosition(boardWidth, boardHeight, _randomMock);
                
            Assert.True(_battleShip.GetStartCoordinates().X == startCoordinate.X && _battleShip.GetStartCoordinates().Y == startCoordinate.Y);
        }

        [Theory]
        [MemberData(nameof(BattleShipTestData.GetRandomPositionEndCoordinates), MemberType = typeof(BattleShipTestData))]
        public void ValidateEndCoordinates(BattleShip.Direction shipDirection, Coordinate endCoordinate, int boardWidth, int boardHeight)
        {
            RandomMock _randomMock = new RandomMock((int)shipDirection);

            BattleShip _battleShip = new BattleShip(_randomMock);

            _randomMock = new RandomMock(0);

            _battleShip.PickRandomPosition(boardWidth, boardHeight, _randomMock);

            Assert.True(_battleShip.GetEndCoordinates().X == endCoordinate.X && _battleShip.GetEndCoordinates().Y == endCoordinate.Y);
        }    
        
        [Fact]
        public void TestShapeDoesNotFitOnBoard()
        {
            RandomMock _randomMock = new RandomMock((int)BattleShip.Direction.North);

            BattleShip _battleShip = new BattleShip(_randomMock);

            _randomMock = new RandomMock(new List<int> { 10, 10, 5, 5 });

            _battleShip.PickRandomPosition(10, 10, _randomMock);

            Assert.True(_battleShip.GetStartCoordinates().X == 5 && _battleShip.GetStartCoordinates().Y == 5);
        }
    }
}
