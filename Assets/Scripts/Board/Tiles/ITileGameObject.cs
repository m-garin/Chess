using UnityEngine;

public interface ITileGameObject
{
    ITileLogic Logic { get; set; }
    void SyncLogicPosition();
}

