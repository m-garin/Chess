using UnityEngine;

public interface IPieceGameObject
{
    void Instantiate(IGameManager _gameManager, PieceLogic _logic);
    PieceLogic Logic { get; }
    Vector2Int Position { get; set; }

    void SyncLogicPosition();
}

