using Board.Squares;
using UnityEngine;

public class TileLogic : ITileLogic
{
    public TileLogic (Vector2Int position, SideType sideType)
    {
        SideType = sideType;
        Position = position;
    }
    public SideType SideType { get; set; }
    public Vector2Int Position { get; set; }
}

