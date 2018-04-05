using BattleShipsBLL.Game.Utilities;
using System;

namespace BattleShipsBLL.Interfaces
{
    /// <summary>
    /// Allows for extension to create new types of ship and processing multiple types polymorphically
    /// Assumption that ships require one single hit to sink the vessel    
    /// </summary>
    public interface IShape
    {
        //Multi-dim array that allows the UI to draw the ship
        bool [,] GetShape();
        int GetHeight();
        int GetWidth();
        void PickRandomPosition(int maxWidth, int maxHeight, Random random);
        Coordinate GetStartCoordinates();
        Coordinate GetEndCoordinates();
    }
}
