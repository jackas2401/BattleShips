using BattleShipsBLL.Game;
using Xunit;

namespace BattleShipsBLLTest.Game
{
    public class GameSettingsTest
    {
        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void HeightProperty(GameSettings gameSettings)
        {
            gameSettings.Height = 5;

            Assert.True(gameSettings.Height == 5);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void WidthProperty(GameSettings gameSettings)
        {
            gameSettings.Width = 5;

            Assert.True(gameSettings.Width == 5);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void BattleShipCountProperty(GameSettings gameSettings)
        {
            gameSettings.BattleShipsCount = 5;

            Assert.True(gameSettings.BattleShipsCount == 5);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void DestroyerCountProperty(GameSettings gameSettings)
        {
            gameSettings.DestroyerCount = 5;

            Assert.True(gameSettings.DestroyerCount == 5);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void PlayersProperty(GameSettings gameSettings)
        {
            gameSettings.Players = 5;

            Assert.True(gameSettings.Players == 5);
        }

        [Theory]
        [MemberData(nameof(GameSettingsTestData.GetData), MemberType = typeof(GameSettingsTestData))]
        public void CpuPlayersProperty(GameSettings gameSettings)
        {
            gameSettings.CpuPlayers = 5;

            Assert.True(gameSettings.CpuPlayers == 5);
        }
    }
}
