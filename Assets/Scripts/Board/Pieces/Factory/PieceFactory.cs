using Board.Squares;
using UnityEngine;

namespace Assets.Scripts.Board.Pieces
{
    public class PieceFactory : MonoBehaviour
    {
        [SerializeField]
        GameObject [] pieces;

        public Piece CreatePiece(SideTypes sideType, PieceTypes pieceType, int x, int y)
        {
            Piece piece = Instantiate(pieces[(int)pieceType * (int)sideType], transform).GetComponent<Piece>();
            piece.SetPosition(x, y);
            return piece;
        }
    }
}
