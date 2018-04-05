using BattleShipsBLL.Game.Utilities;
using System;

namespace BattleShipsBLL.Ships
{
    /// <summary>
    /// Specialisation of ship that is a bit more complex
    /// Irreegular shape and different rotations mean that it needs additional logic
    /// </summary>
    public class BattleShip : Ship
    {
                 
        public BattleShip(Random shipDirection)
        {
            SetShipDirection(shipDirection);
            Draw();
        }

        private void SetShipDirection(Random shipDirection)
        {
            ShipDirection = (Direction)shipDirection.Next(Directions);

            // determine if horizontal or vertical
            if (ShipDirection == Direction.East || ShipDirection == Direction.West)
            {
                __width = 3;
                __height = 2;
            }
            else
            {
                __width = 2;
                __height = 3;
            }
        }       

        protected override void Draw()
        {
            Coordinate __blankCoordinate = new Coordinate();
     
            base.Draw();
            
            switch (ShipDirection)
            {
                case Direction.West:
                    __blankCoordinate.X = 0;
                    __blankCoordinate.Y = GetHeight() - 1;
                    break;
                case Direction.South:
                    __blankCoordinate.X = GetWidth() - 1;
                    __blankCoordinate.Y = GetHeight() -1;
                    break;
                case Direction.East:
                    __blankCoordinate.X = GetWidth() - 1;
                    __blankCoordinate.Y = 0;
                    break;
                case Direction.North:                    
                default:
                    __blankCoordinate.X = 0;
                    __blankCoordinate.Y = 0;
                    break;
            }

            Shape[__blankCoordinate.Y, __blankCoordinate.X] = false;
        }        
    }
}