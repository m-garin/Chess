using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

public class King : PieceLogic
{
    public King(SideType sideType) : base(sideType)
    {
        PieceType = PieceType.King;
    }

    public override List<Vector2Int> GetMoves()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // Standard moves
        for (int x = Mathf.Max(0, Position.x - 1); x <= Mathf.Min(8 - 1, Position.x + 1); x++)
        {
            for (int y = Mathf.Max(0, Position.y - 1); y <= Mathf.Min(8 - 1, Position.y + 1); y++)
            {
                validMoves.Add(new Vector2Int(x, y));
            }
        }

        // Castle
        // IMPORTANT: These moves are also checked in the Game level, to make sure they are valid.
        if (SideType == SideType.White && Position.x == 0)
        {
            validMoves.Add(new Vector2Int(0, 6));
            validMoves.Add(new Vector2Int(0, 2));
        }
        if (SideType == SideType.Black && Position.y == 7)
        {
            validMoves.Add(new Vector2Int(7, 6));
            validMoves.Add(new Vector2Int(7, 2));
        }

        return validMoves;
    }
}
