using UnityEngine;

public class TileGameObject : MonoBehaviour, ITileGameObject
{
    public Vector2Int Position {
        get
        {
            return new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }
        set
        {
            transform.position = new Vector3(value.x, value.y, 0.0f);
        }
    }

    public ITileLogic Logic { get; set; }

    public void SyncLogicPosition()
    {
        Position = Logic.Position;
    }
}

