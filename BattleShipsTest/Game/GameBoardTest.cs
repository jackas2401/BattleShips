using BattleShipsBLL.Game;
using BattleShipsBLL.Game.Utilities;
using System.Linq;
using Xunit;

namespace BattleShipsBLLTest.Game
{
    public class GameBoardTest
    {
        [Fact]
        public void DefaultConstructor()
        {
            Assert.NotNull(new GameBoard());
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void ConstructorWithSettings(GameSettings gameSettings)
        {
            Assert.NotNull(new GameBoard(gameSettings));
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void AddPlayersToGame(GameSettings gameSettings)
        {
            GameBoard _gameBoard = new GameBoard(gameSettings);

            _gameBoard.AddPlayerToGame(gameSettings, "Andrew");
            _gameBoard.AddPlayerToGame(gameSettings, "Max");

            Assert.True(_gameBoard.Players.Where(p => p.TypeOfPlayer == Player.PlayerType.Human).ToList().Count == 2);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void GetGameStatusInProgress(GameSettings gameSettings)
        {
            Assert.True(new GameBoard(gameSettings).GetGameStatus() == GameBoard.GameStatus.InProgress);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetSmallFixedGame), MemberType = typeof(GameSettingsTestData))]
        public void GetGameStatusWinner(GameSettings gameSettings)
        {
            GameBoard _gameBoard = new GameBoard(gameSettings);

            foreach (Player player in _gameBoard.Players)
                player.PlayersBoard.FireMissile(new Coordinate { X = 0, Y = 0 });

            Assert.True(_gameBoard.GetGameStatus() == GameBoard.GameStatus.PlayerWins);
        }

    }
}
