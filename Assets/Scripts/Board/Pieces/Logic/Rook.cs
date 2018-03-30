using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

public class Rook : PieceLogic
{
    public Rook(SideType sideType) : base(sideType)
    {
        PieceType = PieceType.Rook;
    }

    public override List<Vector2Int> GetMoves()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // Down
        for (int x = Position.x - 1; x >= 0; x--)
        {
            validMoves.Add(new Vector2Int(x, Position.y));
        }

        // Up
        for (int x = Position.x + 1; x < 8; x++)
        {
            validMoves.Add(new Vector2Int(x, Position.y));
        }

        // Left
        for (int y = Position.y - 1; y >= 0; y--)
        {
            validMoves.Add(new Vector2Int(Position.x, y));
        }

        // Right
        for (int y = Position.y + 1; y < 8; y++)
        {
            validMoves.Add(new Vector2Int(Position.x, y));
        }
        return validMoves;
    }
}
