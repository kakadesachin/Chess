using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessEntities;

namespace ChessEngine
{
    internal static class PawnMoves
    {
        internal static IList<Position> NextMovesPossible(Pieces piece,Position currentPosition,)
        {

        }
        /// <summary>
        /// Returns all forward moves that can be made by a pawn from a given position
        /// ignores other pieces on its path so it can be handled by validation logic
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="currentPosition"></param>
        /// <returns>IList<Position></returns>
        private static IList<Position> ForwardPosition(bool IsWhitePiece, Position currentPosition)
        {
            List<Position> moveList = null;
            if (IsWhitePiece)
            {
                var position = Moves.SingleStepForwardMove(IsWhitePiece, currentPosition);
                moveList.Add(position);
                if(currentPosition.Row == 6)
                {
                    moveList.Add(new Position { Row = position.Row - 1, Column = position.Column });
                }
            }
            else
            {
                var position = Moves.SingleStepForwardMove(IsWhitePiece, currentPosition);
                moveList.Add(position);
                if (currentPosition.Row == 1)
                {
                    moveList.Add(new Position { Row = position.Row + 1, Column = position.Column });
                }
            }
            return moveList;
        }
        /// <summary>
        /// Returns all attack moves that can be made by a pawn from a given position
        /// ignores other pieces on its path so it can be handled by validation logic
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="currentPosition"></param>
        /// <returns>IList<Position></returns>
        private static IList<Position> AttackMoves(bool IsWhitePiece, Position currentPosition)
        {
            return Moves.SingleStepForwardCrossMove(IsWhitePiece, currentPosition);            
        }
        /// <summary>
        /// Checks if the Piece is a pawn.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>Boolean</returns>
        internal static bool IsPawn(Pieces piece)
        {
            var pieceNumber = (int)piece;
            return (pieceNumber > 8 && pieceNumber < 17) || (pieceNumber > 24 && pieceNumber < 33);
        }
        /// <summary>
        /// Checks if the Piece is a white pawn.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>Boolean</returns>
        internal static bool IsWhitePawn(Pieces piece)
        {
            var pieceNumber = (int)piece;
            return (pieceNumber > 8 && pieceNumber < 17);
        }
        /// <summary>
        /// Checks if the Piece is a black pawn.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>Boolean</returns>
        internal static bool IsBlackPawn(Pieces piece)
        {
            var pieceNumber = (int)piece;
            return (pieceNumber > 24 && pieceNumber < 33);
        }
    }
}
