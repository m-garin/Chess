using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : PieceLogic {

    public Bishop(SideType sideType) : base(sideType)
    {
        PieceType = PieceType.Bishop;
    }

    public override List<Vector2Int> GetMoves()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // Up-Left
        for (int x = Position.x + 1, y = Position.y - 1; x < 8 && y >= 0; x++, y--)
        {
            validMoves.Add(new Vector2Int(x, y));
        }

        // Up-Right
        for (int x = Position.x + 1, y = Position.y + 1; x < 8 && y < 8; x++, y++)
        {
            validMoves.Add(new Vector2Int(x, y));
        }

        // Down-Left
        for (int x = Position.x - 1, y = Position.y - 1; x >= 0 && y >= 0; x--, y--)
        {
            validMoves.Add(new Vector2Int(x, y));
        }

        // Down-Right
        for (int x = Position.x - 1, y = Position.y + 1; x >= 0 && y < 8; x--, y++)
        {
            validMoves.Add(new Vector2Int(x, y));
        }

        return validMoves;
    }
}
