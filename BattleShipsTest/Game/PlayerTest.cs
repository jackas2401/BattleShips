using BattleShipsBLL.Game;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShipsBLLTest.Game
{
    public class PlayerTest
    {

        [Theory]
        [InlineData("CPU 1", Player.PlayerType.CPU, "CPU 1")]
        [InlineData("  CPU 1", Player.PlayerType.CPU, "CPU 1")]
        [InlineData("Player 1 ", Player.PlayerType.Human, "Player 1")]
        [InlineData(" Player 1 ", Player.PlayerType.Human, "Player 1")]
        public void PlayerConstructor(string playersName, Player.PlayerType playerType, string expectedName)
        {
            Player _player = new Player(new GameSettings(), playersName, playerType);

            Assert.True(_player.Name == expectedName && _player.TypeOfPlayer == playerType);
        }

        [Theory]
        [InlineData("", Player.PlayerType.CPU)]
        [InlineData(null, Player.PlayerType.CPU)]
        [InlineData("   ", Player.PlayerType.Human)]
        [InlineData(null, Player.PlayerType.Human)]
        public void PlayerConstructorDefaultName(string playersName, Player.PlayerType playerType)
        {
            Player _player = new Player(new GameSettings(), playersName, playerType);

            Assert.True(_player.Name == Player.DefaultPlayersName && _player.TypeOfPlayer == playerType);
        }

        [Theory]
        [InlineData("Player 1", Player.PlayerType.Human)]
        public void SetNameProperty(string playersName, Player.PlayerType playerType)
        {
            Player _player = new Player(new GameSettings(), string.Empty, playerType);

            _player.Name = playersName;

            Assert.True(_player.Name == playersName);
        }

        [Fact]
        public void SetTypeOfPlayerProperty()
        {
            Player _player = new Player(new GameSettings(), string.Empty, Player.PlayerType.CPU);

            _player.TypeOfPlayer = Player.PlayerType.Human;

            Assert.True(_player.TypeOfPlayer == Player.PlayerType.Human);
        }

        [Theory]
        [InlineData("Player 1", Player.PlayerType.Human)]
        public void GetPlayersBoardProperty(string playersName, Player.PlayerType playerType)
        {
            Player _player = new Player(new GameSettings(), playersName, playerType);

            _player.TypeOfPlayer = Player.PlayerType.Human;

            Assert.False(_player.PlayersBoard == null);
        }


    }
}
