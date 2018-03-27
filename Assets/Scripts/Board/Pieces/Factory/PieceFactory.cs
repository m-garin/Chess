using Board.Squares;
using UnityEngine;

namespace Assets.Scripts.Board.Pieces
{
    public class PieceFactory : MonoBehaviour
    {
        [SerializeField]
        GameObject [] pieces;

        public Piece CreatePiece(SideTypes sideType, PieceTypes pieceType)
        {
            GameObject pieceGameObject = Instantiate(pieces[(int)pieceType * (int)sideType], transform);
            return pieceGameObject.GetComponent<Piece>();
        }
    }
}
