using BattleShipsBLL.Ships;
using BattleShipsBLL.Game.Utilities;
using BattleShipsBLL.Interfaces;
using System;
using System.Collections.Generic;

namespace BattleShipsBLL.Game
{
    /// <summary>
    /// Players board will control the current state of players game
    /// On creation we will create a board, ships and randomly place ships on board
    /// Potential extensibility if we want add difficulty levels through different size boards and no.of ships
    /// </summary>
    public class PlayersBoard
    {
        public enum MissileResponse { Hit = 1, Miss = 2, Wasted = 3, Invalid = 4 };
        public enum BoardStatus { InProgress = 0, Complete =  1};

        private GameCell[,] __boardCells;
        private GameSettings __gameSettings;
        private List<IShape> __gameShapes;

        public GameCell[,] BoardCells { get => __boardCells; }

        /// <summary>
        /// Allow gameboard to be created with default game settings
        /// </summary>
        public PlayersBoard() : this(new GameSettings())
        { }

        /// <summary>
        /// Constructor allowing caller to dictate specific settings
        /// </summary>
        /// <param name="gameSettings"></param>
        public PlayersBoard(GameSettings gameSettings)
        {
            __gameSettings = gameSettings;
            InitialiseBoard();
        }

        /// <summary>
        /// Invoke this method for when the player is firing a shot
        /// Coordinates must be captured and validated before calling
        /// Default coordinates of 0, 0 will be used if not set       
        /// </summary>
        /// <returns>Hit, Miss or Wasted shot</returns>
        public MissileResponse FireMissile(Coordinate coordinate)
        {
            if (coordinate == null)
                coordinate = RandomShot();

            if (ValidateShot(coordinate) == false)
            { 
                return MissileResponse.Invalid;
            }

            return ImpactShotFired(coordinate);                        
        }

        /// <summary>
        /// Invoke this method for when CPU is firing a shot
        /// This will randomly pick coordinates using the board size
        /// Extreme coordinates will be checked to ensure they in bounds of board
        /// </summary>
        /// <returns>Hit, Miss, Invalid or Wasted shot</returns>
        private Coordinate RandomShot()
        {
            // amend to use inheritance CPU board
            Coordinate _missileCoordinates;
            Random _random = new Random();

            _missileCoordinates = new Coordinate
            {
                X = _random.Next(__gameSettings.Width),
                Y = _random.Next(__gameSettings.Height)
            };

            return _missileCoordinates;
        }

        /// <summary>
        /// This will allow you determine whether the board is complete or in-progress
        /// </summary>
        /// <returns>Complete or In-Progress</returns>
        public BoardStatus GetBoardStatus()
        {
            for (int y = 0; y < __gameSettings.Height; y++)
            {
                for (int x = 0; x < __gameSettings.Width; x++)
                {
                    if (BoardCells[y, x].CurrentStatus == GameCell.CellStatus.Ship)
                    {
                        return BoardStatus.InProgress;
                    }
                }
            }

            return BoardStatus.Complete;
        }

        private void InitialiseBoard()
        {
            CreateBlankBoard();
            CreateShapes();
            AddShapesToBoard();            
        }

        private void CreateBlankBoard()
        {
            __boardCells = new GameCell[__gameSettings.Height, __gameSettings.Height];

            for (int y = 0; y < __gameSettings.Height; y++)
            {
                for (int x = 0; x < __gameSettings.Width; x++)
                {
                    BoardCells[y, x] = new GameCell();                    
                }
            }
        }

        private void CreateShapes()
        {
            __gameShapes = new List<IShape>();

            for (int i = 0; i < __gameSettings.BattleShipsCount; i++)
            {
                __gameShapes.Add(new BattleShip(new Random()));
            }

            for (int i = 0; i < __gameSettings.DestroyerCount; i++)
            {
                __gameShapes.Add(new Destroyer());
            }
        }

        private void AddShapesToBoard()
        {            
            bool _shapeAdded;
            int _shapeCount = 0;
            Random _random = new Random();

            // work through all the shapes we need to add to the boardc
            foreach (IShape shape in __gameShapes)
            {
                _shapeCount++;
                _shapeAdded = false;

                // check that there's space on the board for scenarios where game settings have extreme values for ships/shapes
                // TODO : AJAC - loop through cells to determine if we have any free space for next shape
                
                while (!_shapeAdded)
                {
                    shape.PickRandomPosition(__gameSettings.Width - 1, __gameSettings.Height - 1, _random);

                    if (CheckCoordinatesSuitable(shape) == true)
                    {
                        AddIndividualShapeToBoard(shape, _shapeCount);
                        _shapeAdded = true;
                    }
                }             
            }
        }

        private bool CheckCoordinatesSuitable(IShape shape)
        {
            // array boundary already checked so we need to ensure the cells are empty
            for (int y = shape.GetStartCoordinates().Y; y < shape.GetEndCoordinates().Y; y++)
            {
                for (int x = shape.GetStartCoordinates().X; x < shape.GetEndCoordinates().X; x++)
                {
                    if (BoardCells[y, x].CurrentStatus != GameCell.CellStatus.Blank)
                        return false;
                }
            }         
            return true;
        }

        private void AddIndividualShapeToBoard(IShape shape, int shapeCount)
        {
            int _countY = 0;
            int _countX = 0;

            for (int y = shape.GetStartCoordinates().Y; y <= shape.GetEndCoordinates().Y; y++)
            {
                for (int x = shape.GetStartCoordinates().X; x <= shape.GetEndCoordinates().X; x++)
                {
                    // ensure that the cell being amended is not blank (irregular shapes e.g. battleship 5/6 squares
                    if (shape.GetShape()[_countY, _countX] == true)
                    {
                        BoardCells[y, x].CurrentStatus = GameCell.CellStatus.Ship;
                        BoardCells[y, x].ShapeID = shapeCount;                        
                    }
                    _countX++; ;
                }
                _countY++;
                _countX = 0;
            }            
        }
        
        private bool ValidateShot(Coordinate coordinate)
        {
            if (coordinate != null &&
                coordinate.Y >= 0 && coordinate.Y < __gameSettings.Height &&
                coordinate.X >= 0 && coordinate.X < __gameSettings.Width)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        private MissileResponse ImpactShotFired(Coordinate coordinate)
        {
            MissileResponse _shotResponse = MissileResponse.Hit;

            switch (BoardCells[coordinate.Y, coordinate.X].CurrentStatus)
            {
                case GameCell.CellStatus.Hit:
                case GameCell.CellStatus.Miss:
                    _shotResponse = MissileResponse.Wasted;
                    break;
                case GameCell.CellStatus.Blank:
                    _shotResponse = MissileResponse.Miss;
                    BoardCells[coordinate.Y, coordinate.X].CurrentStatus = GameCell.CellStatus.Miss;
                    break;
                case GameCell.CellStatus.Ship:
                default:
                    _shotResponse = MissileResponse.Hit;
                    RemoveShape(BoardCells[coordinate.Y, coordinate.X].ShapeID);
                    break;
            }

            return _shotResponse;
        }

        private void RemoveShape(int shapeID)
        {
            //use the shape ID to update all the cells
            for (int y = 0; y < __gameSettings.Height; y++)
            {
                for (int x = 0; x < __gameSettings.Width; x++)
                {
                    if (shapeID == BoardCells[y, x].ShapeID)
                    {
                        BoardCells[y, x].CurrentStatus = GameCell.CellStatus.Hit;
                    }                    
                }
            }
        }
    }
}