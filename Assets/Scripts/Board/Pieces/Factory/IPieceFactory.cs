using Board.Squares;

namespace Assets.Scripts.Board.Pieces
{
    interface IPieceFactory
    {
        Piece CreatePiece(SideTypes sideType, PieceTypes pieceType);
    }
}
