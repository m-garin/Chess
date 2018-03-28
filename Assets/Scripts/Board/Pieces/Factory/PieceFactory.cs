using Board.Squares;
using UnityEngine;

namespace Assets.Scripts.Board.Pieces
{
    public class PieceFactory : MonoBehaviour, IPieceFactory
    {
        [SerializeField]
        GameObject[] whitePieces;
        [SerializeField]
        GameObject[] blackPieces;

        public Piece CreatePiece(SideTypes sideType, PieceTypes pieceType, int x, int y)
        {
            Piece piece;
            if (sideType == SideTypes.White) 
            {
                piece = Instantiate(whitePieces[(int)pieceType], transform).GetComponent<Piece>();
            }
            else
            {
                piece = Instantiate(blackPieces[(int)pieceType], transform).GetComponent<Piece>();
            }
             
            piece.SetPosition(x, y);
            return piece;
        }
    }
}
