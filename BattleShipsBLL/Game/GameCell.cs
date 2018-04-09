namespace BattleShipsBLL.Game
{
    /// <summary>
    /// Holds the properties of an individual cell on a players board
    /// Written as a class to make extensibility easier
    /// </summary>
    public class GameCell
    {
        public enum CellStatus { Hit = -2, Miss = -1, Blank = 0, Ship = 1 };

        public CellStatus _currentStatus = CellStatus.Blank;
        private int _shapeId = 0;
        
        public int ShapeID { get => _shapeId; set => _shapeId = value; }
        public CellStatus CurrentStatus { get => _currentStatus; set => _currentStatus = value; }     
    }
}