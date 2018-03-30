using Board.Squares;
using UnityEngine;

namespace Assets.Scripts.Board.Pieces
{
    public interface IPieceFactory
    {
        void Instantiate(IGameManager gameManager);

        IPieceGameObject CreatePiece(SideType sideType, PieceType pieceType, Vector2Int position);
    }
}
