using UnityEngine;

public interface IGameManager
{
    void TryMovePiece(IPieceGameObject PieceGameObject, Vector2Int position);
}
