using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEntities
{
    public static class PieceType
    {
        public static bool IsWhitePiece(Pieces piece)
        {
            var pieceType = (int)piece;
            return (pieceType > 0 && pieceType < 17);
        }
        public static bool IsWhitePawn(Pieces piece)
        {
            var pieceType = (int)piece;
            return (pieceType > 8 && pieceType < 17);
        }
        public static bool IsBlackPawn(Pieces piece)
        {
            var pieceType = (int)piece;
            return (pieceType > 24 && pieceType < 33);
        }
    }
}
