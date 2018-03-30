using UnityEngine;

public interface IBoardManager
{
    ITileGameObject GetTile(Vector2Int position);
    IPieceGameObject GetPiece(Vector2Int position);
}
