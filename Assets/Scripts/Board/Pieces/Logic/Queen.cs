using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

public class Queen : PieceLogic
{
    public Queen(SideType sideType) : base(sideType)
    {
        PieceType = PieceType.Queen; ;
    }

    public override List<Vector2Int> GetMoves()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // Up-Left
        for (int x = Position.x + 1, y = Position.y - 1;
            x < 8 && y >= 0; x++, y--)
        {
            validMoves.Add(new TileLogic(x, y));
        }

        // Up-Right
        for (int x = Position.x + 1, y = Position.y + 1;
            x < 8 && y < 8; x++, y++)
        {
            validMoves.Add(new TileLogic(x, y));
        }

        // Down-Left
        for (int x = Position.x - 1, y = Position.y - 1;
            x >= 0 && y >= 0; x--, y--)
        {
            validMoves.Add(new TileLogic(x, y));
        }

        // Down-Right
        for (int x = Position.x - 1, y = Position.y + 1;
            x >= 0 && y < 8; x--, y++)
        {
            validMoves.Add(new TileLogic(x, y));
        }

        // Down
        for (int x = Position.x - 1; x >= 0; x--)
        {
            validMoves.Add(new TileLogic(x, Position.y));
        }

        // Up
        for (int x = Position.x + 1; x < 8; x++)
        {
            validMoves.Add(new TileLogic(x, Position.y));
        }

        // Left
        for (int y = Position.y - 1; y >= 0; y--)
        {
            validMoves.Add(new TileLogic(Position.x, y));
        }

        // Right
        for (int y = Position.y + 1; y < 8; y++)
        {
            validMoves.Add(new TileLogic(Position.x, y));
        }

        return validMoves;
    }
}
