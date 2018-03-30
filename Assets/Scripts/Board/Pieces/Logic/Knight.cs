using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PieceLogic
{
    public Knight(SideType sideType) : base(sideType)
    {
        PieceType = PieceType.Knight;
    }

    public override List<Vector2Int> GetMoves()
    {
        List<TileLogic> validMoves = new List<TileLogic>();
        TileLogic tile;

        // Left-up 1
        tile = new TileLogic(Position.x + 1, Position.y - 2);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        // Left-up 2
        tile = new TileLogic(Position.x + 2, Position.y - 1);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        // Left-down 1
        tile = new TileLogic(Position.x - 1, Position.y - 2);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        // Left-down 2
        tile = new TileLogic(Position.x - 2, Position.y - 1);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        // Right-up 1
        tile = new TileLogic(Position.x + 1, Position.y + 2);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        // Right-up 2
        tile = new TileLogic(Position.x + 2, Position.y + 1);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        // Right-down 1
        tile = new TileLogic(Position.x - 1, Position.y + 2);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        // Right-down 2
        tile = new TileLogic(Position.x - 2, Position.y + 1);
        if (tile.IsInBoard()) { validMoves.Add(tile); }

        return validMoves;
    }
}
