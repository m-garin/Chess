using Board.Squares;
using UnityEngine;

public class TileFactory : MonoBehaviour, ITileFactory
{
    [SerializeField]
    GameObject[] tiles;

    public ITileGameObject CreateTile(SideType type, int x, int y)
    {
        ITileGameObject tile = Instantiate(tiles[(int)type], transform).GetComponent<TileGameObject>();

        tile.Logic = new TileLogic(new Vector2Int(x, y), type);
        tile.SyncLogicPosition();
        return tile;
    }
}
