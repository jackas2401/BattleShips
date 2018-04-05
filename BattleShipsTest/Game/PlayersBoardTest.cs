using BattleShipsBLL.Game;
using BattleShipsBLL.Game.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShipsBLLTest.Game
{
    public class PlayersBoardTest
    {

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(11, 11)]
        public void FireMissileValid(int xCoord, int yCoord)
        {
            PlayersBoard _playersBoard = new PlayersBoard();

            Assert.True(_playersBoard.FireMissile(new Coordinate { X = xCoord, Y = yCoord }) == PlayersBoard.MissileResponse.Invalid);
        }

        [Fact]
        public void PlayersBoardDefaultConstructor()
        {
            PlayersBoard _playersBoard = new PlayersBoard();

            Assert.NotNull(_playersBoard);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void GetBoardStatusInProgress(GameSettings gameSettings)
        {
            PlayersBoard _playersBoard = new PlayersBoard(gameSettings);

            Assert.True(_playersBoard.GetBoardStatus() == PlayersBoard.BoardStatus.InProgress);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetSmallFixedGame), MemberType = typeof(GameSettingsTestData))]
        public void GetBoardStatusComplete(GameSettings gameSettings)
        {
            PlayersBoard _playersBoard = new PlayersBoard(gameSettings);

            _playersBoard.FireMissile(new Coordinate { X = 0, Y = 0 });

            Assert.True(_playersBoard.GetBoardStatus() == PlayersBoard.BoardStatus.Complete);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetSmallFixedGameNoShips), MemberType = typeof(GameSettingsTestData))]
        public void AutoFireMissileMiss(GameSettings gameSettings)
        {
            PlayersBoard _playersBoard = new PlayersBoard(gameSettings);

            Assert.True(_playersBoard.FireMissile(null) == PlayersBoard.MissileResponse.Miss);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetSmallFixedGame), MemberType = typeof(GameSettingsTestData))]
        public void AutoFireMissileHit(GameSettings gameSettings)
        {
            PlayersBoard _playersBoard = new PlayersBoard(gameSettings);

            Assert.True(_playersBoard.FireMissile(null) == PlayersBoard.MissileResponse.Hit);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetSmallFixedGame), MemberType = typeof(GameSettingsTestData))]
        public void FireMissileDuplicateHit(GameSettings gameSettings)
        {
            PlayersBoard _playersBoard = new PlayersBoard(gameSettings);

            Coordinate _coordinate = new Coordinate { X = 0, Y = 0 };

            _playersBoard.FireMissile(_coordinate);     //first shot updates status to hit

            Assert.True(_playersBoard.FireMissile(null) == PlayersBoard.MissileResponse.Wasted);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetSmallFixedGameNoShips), MemberType = typeof(GameSettingsTestData))]
        public void FireMissileWastedDuplicate(GameSettings gameSettings)
        {
            PlayersBoard _playersBoard = new PlayersBoard(gameSettings);

            Coordinate _coordinate = new Coordinate { X = 0, Y = 0 };

            //first shot will record missile already fired at coord
            _playersBoard.FireMissile(_coordinate);

            Assert.True(_playersBoard.FireMissile(_coordinate) == PlayersBoard.MissileResponse.Wasted);
        }        

    }
}
