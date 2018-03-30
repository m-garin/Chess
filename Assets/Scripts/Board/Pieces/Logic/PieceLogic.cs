using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceLogic
{
    public PieceLogic (SideType sideType)
    {
        SideType = sideType;
    }

    public SideType SideType { get; protected set; }
    public PieceType PieceType { get; protected set; }

    public Vector2Int Position { get; set; }

    public abstract List<Vector2Int> GetMoves();
}
