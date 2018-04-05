namespace BattleShipsBLL.Game
{
    /// <summary>
    /// Holds the properties of an individual cell on a players board
    /// Written as a class to make extensibility easier
    /// </summary>
    public class GameCell
    {
        public enum CellStatus { Hit = -2, Miss = -1, Blank = 0, Ship = 1 };

        private CellStatus __currentStatus = CellStatus.Blank;
        private int __shapeID = 0;
        
        public int ShapeID { get => __shapeID; set => __shapeID = value; }
        public CellStatus CurrentStatus { get => __currentStatus; set => __currentStatus = value; }     
    }
}