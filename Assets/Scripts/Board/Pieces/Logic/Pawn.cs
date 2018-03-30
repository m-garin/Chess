using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : PieceLogic
{
    public Pawn(SideType sideType) : base(sideType)
    {
        PieceType = PieceType.Pawn;
    }

    public override List<Vector2Int> GetMoves()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        int nextRow = 0;

        // Check white
        if (this.color == Game.SideColor.White)
        {
            nextRow = Position.x + 1;
            validMoves.Add(new TileLogic(nextRow, Position.y));

            // Check first x for 2 jump
            if (Position.x == 1)
            {
                validMoves.Add(new TileLogic(nextRow + 1, Position.y));
            }
        }

        // Check black
        if (this.color == Game.SideColor.Black)
        {
            nextRow = Position.x - 1;
            validMoves.Add(new TileLogic(nextRow, Position.y));

            // Check first x for 2 jump
            if (Position.x == 6)
            {
                validMoves.Add(new TileLogic(nextRow - 1, Position.y));
            }
        }

        // Check diagonal takes
        // IMPORTANT: These move are also checked in the Game level, to make sure they
        //            are valid.
        validMoves.Add(new TileLogic(nextRow, Position.y - 1));
        validMoves.Add(new TileLogic(nextRow, Position.y + 1));

        return validMoves;
    }
}
