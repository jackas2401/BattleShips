using BattleShipsBLL.Game;
using Xunit;

namespace BattleShipsBLLTest.Game
{
    public class GameCellTest
    {
        [Theory]
        [InlineData(1, GameCell.CellStatus.Blank)]
        [InlineData(2, GameCell.CellStatus.Hit)]
        [InlineData(3, GameCell.CellStatus.Miss)]
        [InlineData(4, GameCell.CellStatus.Ship)]
        public void ValidateGridReferenceProps(int shapeID, GameCell.CellStatus cellStatus)
        {
            GameCell _gameCell = new GameCell
            {
                ShapeID = shapeID,
                CurrentStatus = cellStatus
            };

            Assert.True(_gameCell.ShapeID == shapeID && _gameCell.CurrentStatus == cellStatus);
        }
    }
}
