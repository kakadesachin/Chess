using ChessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine
{
    internal static class Moves
    {
        /// <summary>
        /// Returns single forward move applicable to King, Queen, Rook and Pawn
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>Position</returns>
        internal static Position SingleStepForwardMove(bool IsWhitePiece, Position currentPosition)
        {
            Position position = null;
            if (IsWhitePiece)
            {
                if (currentPosition.Row > 0)
                {
                    position = new Position { Column = currentPosition.Column, Row = currentPosition.Row - 1 };
                }
            }
            else
            {
                if (currentPosition.Row < 7)
                {
                    position =  new Position { Column = currentPosition.Column, Row = currentPosition.Row + 1 };
                }
            }
            return position;           
        }

        /// <summary>
        /// Returns multiple forward move applicable to Queen and Rook.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>List<Position></returns>
        internal static IList<Position> MultiStepForwardMove(bool IsWhitePiece, Position currentPosition)
        {
            var moveList = new List<Position>();
            var currentRow = currentPosition.Row;
            if (IsWhitePiece)
            {
                while (currentRow>0)
                {                    
                    currentRow--;
                    moveList.Add(new Position { Column = currentPosition.Column, Row = currentRow });
                }
            }
            else
            {
                while (currentRow < 7)
                {
                    currentRow++;
                    moveList.Add(new Position { Column = currentPosition.Column, Row = currentRow });
                }
            }
            return moveList;
        }

        /// <summary>
        /// Returns Position of single step backward move applicable to King, Queen and Rook
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>Position</returns>
        internal static Position SingleStepBackwardMove(bool IsWhitePiece, Position currentPosition)
        {
            Position position = null;
            if (IsWhitePiece)
            {
                if (currentPosition.Row < 7)
                {
                    position = new Position { Column = currentPosition.Column, Row = currentPosition.Row + 1 };
                }
            }
            else
            {
                if (currentPosition.Row > 0)
                {
                    position = new Position { Column = currentPosition.Column, Row = currentPosition.Row - 1 };
                }
            }
            return position;
        }

        /// <summary>
        /// Returns multiple backward move applicable to Queen and Rook.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>List<Position></returns>
        internal static IList<Position> MultiStepBackwardMove(bool IsWhitePiece, Position currentPosition)
        {
            var moveList = new List<Position>();
            var currentRow = currentPosition.Row;
            if (IsWhitePiece)
            {
                while (currentRow > 0)
                {
                    currentRow--;
                    moveList.Add(new Position { Column = currentPosition.Column, Row = currentRow });
                }
            }
            else
            {
                while (currentRow < 7)
                {
                    currentRow++;
                    moveList.Add(new Position { Column = currentPosition.Column, Row = currentRow });
                }
            }
            return moveList;
        }

        /// <summary>
        /// Returns List of single step forward cross move applicable to King, Queen, Bishop and Pawn.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>IList<Position></returns>
        internal static IList<Position> SingleStepForwardCrossMove(bool IsWhitePiece, Position currentPosition)
        {
            var movesList = new List<Position>();
            if (IsWhitePiece)
            {
                if (currentPosition.Row > 0)
                {
                    if (currentPosition.Column == 0)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row - 1 });
                    }
                    if (currentPosition.Column > 0 && currentPosition.Column < 7)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column - 1, Row = currentPosition.Row - 1 });
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row - 1 });
                    }
                }
            }
            else
            {
                if (currentPosition.Row < 7)
                {
                    if (currentPosition.Column == 0)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row + 1 });
                    }
                    if (currentPosition.Column > 0 && currentPosition.Column < 7)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row + 1 });
                        movesList.Add(new Position { Column = currentPosition.Column - 1, Row = currentPosition.Row + 1 });
                    }
                }
            }
            return movesList;
        }

        /// <summary>
        /// Returns multiple forward cross move applicable to Queen and Bishop.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>List<Position></returns>
        internal static IList<Position> MultiStepForwardCrossMove(bool IsWhitePiece, Position currentPosition)
        {
            var moveList = new List<Position>();
            var currentRow = currentPosition.Row;
            var currentColumn = currentPosition.Column;
            if (IsWhitePiece)
            {
                //Right Cross Move
                while (currentRow > 0 && currentColumn < 7 )
                {
                    currentRow--;
                    currentColumn++;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
                //Left Cross Move
                while (currentColumn > 0 && currentRow > 0)
                {
                    currentRow--;
                    currentColumn--;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
            }
            else
            {
                //Right Cross Move
                while (currentRow < 7 && currentColumn > 0)
                {
                    currentRow++;
                    currentColumn--;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
                //Left Cross Move
                while (currentColumn < 7 && currentRow < 7)
                {
                    currentRow++;
                    currentColumn++;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
            }
            return moveList;
        }

        /// <summary>
        /// Returns List of single step forward cross move applicable to King, Queen and Bishop.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>IList<Position></returns>
        internal static IList<Position> SingleStepBackwardCrossMove(bool IsWhitePiece, Position currentPosition)
        {
            var movesList = new List<Position>();
            if (IsWhitePiece)
            {
                if (currentPosition.Row < 7)
                {
                    if (currentPosition.Column == 0)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row + 1 });
                    }
                    if (currentPosition.Column > 0 && currentPosition.Column < 7)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column - 1, Row = currentPosition.Row + 1 });
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row + 1 });
                    }
                }
            }
            else
            {
                if (currentPosition.Row > 0)
                {
                    if (currentPosition.Column == 0)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row - 1 });
                    }
                    if (currentPosition.Column > 0 && currentPosition.Column < 7)
                    {
                        movesList.Add(new Position { Column = currentPosition.Column + 1, Row = currentPosition.Row - 1 });
                        movesList.Add(new Position { Column = currentPosition.Column - 1, Row = currentPosition.Row - 1 });
                    }
                }
            }
            return movesList;
        }

        /// <summary>
        /// Returns multiple backward cross move applicable to Queen and Bishop.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>List<Position></returns>
        internal static IList<Position> MultiStepBackwardCrossMove(bool IsWhitePiece, Position currentPosition)
        {
            var moveList = new List<Position>();
            var currentRow = currentPosition.Row;
            var currentColumn = currentPosition.Column;
            if (IsWhitePiece)
            {
                //Right Cross Move
                while (currentRow < 7 && currentColumn < 7)
                {
                    currentRow++;
                    currentColumn++;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
                //Left Cross Move
                while (currentColumn > 0 && currentRow < 7)
                {
                    currentRow++;
                    currentColumn--;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
            }
            else
            {
                //Right Cross Move
                while (currentRow > 0 && currentColumn > 0)
                {
                    currentRow--;
                    currentColumn--;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
                //Left Cross Move
                while (currentColumn < 7 && currentRow > 0)
                {
                    currentRow--;
                    currentColumn++;
                    moveList.Add(new Position { Column = currentColumn, Row = currentRow });
                }
            }
            return moveList;
        }
        /// <summary>
        /// Returns a list of positions a knight can make in forward move
        /// </summary>
        /// <param name="IsWhitePiece"></param>
        /// <param name="currentPosition"></param>
        /// <returns>IList<Position></returns>

        internal static IList<Position> ForwardKnightMove(bool IsWhitePiece, Position currentPosition)
        {
            var moveList = new List<Position>();
            if (IsWhitePiece)
            {
                //Forward 1 up 2 right moves
                if ((currentPosition.Row-1 < -1) && (currentPosition.Column+2 < 8))
                {
                    moveList.Add(new Position { Row = currentPosition.Row - 1, Column = currentPosition.Column + 2 });
                }
                //Forward 2 up 1 right moves
                if ((currentPosition.Row - 2 < -1) && (currentPosition.Column + 1 < 8))
                {
                    moveList.Add(new Position { Row = currentPosition.Row - 2, Column = currentPosition.Column + 1 });
                }
                //Forward 1 up 2 left moves
                if ((currentPosition.Row - 1 < -1) && (currentPosition.Column - 2 > -1))
                {
                    moveList.Add(new Position { Row = currentPosition.Row - 1, Column = currentPosition.Column - 2 });
                }
                //Forward 2 up 1 left moves
                if ((currentPosition.Row - 2 < -1) && (currentPosition.Column - 1 > -1))
                {
                    moveList.Add(new Position { Row = currentPosition.Row - 2, Column = currentPosition.Column - 1 });
                }
            }
            else
            {
                //Forward 1 up 2 right moves
                if ((currentPosition.Row + 1 > 8) && (currentPosition.Column - 2 > -1))
                {
                    moveList.Add(new Position { Row = currentPosition.Row + 1, Column = currentPosition.Column - 2 });
                }
                //Forward 2 up 1 right moves
                if ((currentPosition.Row + 2 > 8) && (currentPosition.Column - 1 > -1))
                {
                    moveList.Add(new Position { Row = currentPosition.Row + 2, Column = currentPosition.Column - 1 });
                }
                //Forward 1 up 2 left moves
                if ((currentPosition.Row + 1 > 8) && (currentPosition.Column + 2 < 8))
                {
                    moveList.Add(new Position { Row = currentPosition.Row + 1, Column = currentPosition.Column + 2 });
                }
                //Forward 2 up 1 left moves
                if ((currentPosition.Row + 2 > 8) && (currentPosition.Column + 1 < 8))
                {
                    moveList.Add(new Position { Row = currentPosition.Row + 2, Column = currentPosition.Column + 1 });
                }
            }

            return moveList;
        }

    }
}
