using BattleShipsBLL.Game.Utilities;
using BattleShipsBLL.Interfaces;
using System;
using System.Linq;

namespace BattleShipsBLL.Ships
{
    /// <summary>
    /// Abstract class for dictating the design of specialisations of ships
    /// Commmon methods implemented that be used by subclasses
    /// </summary>
    public abstract class Ship : IShape
    {
        public enum Direction { North, South, East, West };
        protected int __height;
        protected int __width;
        private bool[,] __shape;
        private Direction __shipDirection = Direction.North;
        protected Coordinate __startCoordinates;
        protected Coordinate __endCoordinates;


        private const int __directions = 4;

        protected bool[,] Shape { get => __shape; }
        protected static int Directions => __directions;
        protected Direction ShipDirection { get => __shipDirection; set => __shipDirection = value; }
        
        virtual protected void Draw()
        {
            __shape = new bool[GetHeight(), GetWidth()];

            for (int y = 0; y < GetHeight(); y++)
            {
                for (int x = 0; x < GetWidth(); x++)
                {
                    __shape[y, x] = true;
                }
            }
        }

        public bool[,] GetShape()
        {
            return Shape;
        }

        public int GetHeight()
        {
            return __height;
        }

        public int GetWidth()
        {
            return __width;
        }

        public Coordinate GetStartCoordinates()
        {
            return __startCoordinates;
        }

        public Coordinate GetEndCoordinates()
        {
            return __endCoordinates;
        }

        public void PickRandomPosition(int maxWidth, int maxHeight, Random random)
        {
            __startCoordinates = new Coordinate
            {
                X = random.Next(maxWidth),
                Y = random.Next(maxHeight)
            };

            __endCoordinates = new Coordinate
            {
                X = __startCoordinates.X + (__width - 1),
                Y = __startCoordinates.Y + (__height - 1)
            };

            // ensure we pick a starting position that will allow shape to fit in array
            if (__endCoordinates.X > maxWidth ||
                __endCoordinates.Y > maxHeight)
            {
                PickRandomPosition(maxWidth, maxHeight, random);
            }
        } 

    }
}
