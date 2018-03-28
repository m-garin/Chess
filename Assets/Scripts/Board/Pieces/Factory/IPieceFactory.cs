using Board.Squares;

namespace Assets.Scripts.Board.Pieces
{
    public interface IPieceFactory
    {
        Piece CreatePiece(SideTypes sideType, PieceTypes pieceType, int x, int y);
    }
}
