using Board.Squares;
using UnityEngine;

public interface ITileLogic
{
    SideType SideType { get; }
    Vector2Int Position { get; set; }
}
