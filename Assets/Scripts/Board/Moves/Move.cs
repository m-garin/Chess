using Assets.Scripts.Board.Moves;
using System.Collections.Generic;
using UnityEngine;

public class Move : IMove
{
    public IPieceGameObject Piece { get; private set; }
    public Vector2Int Destination { get; private set; }

    public Move(IPieceGameObject piece, Vector2Int destination)
    {
        Piece = piece;
        Destination = destination;
    }

    // Get list of all tiles in route from tile origin to destination
    public List<Vector2Int> GetRoute()
    {
        PieceLogic pieceLogic = Piece.Logic;
        List<Vector2Int> route = new List<Vector2Int>();

        Vector2Int piecePosition = pieceLogic.Position;

        // Special case of knight - we return empty route
        if (pieceLogic is Knight)
        {
            return route;
        }

        // Special case - move to the same tile
        if (pieceLogic.Position == Destination)
        {
            return route;
        }

        int xDirection = Destination.x - piecePosition.x > 0 ? 1 : -1;
        int yDirection = Destination.y - piecePosition.y > 0 ? 1 : -1;

        // Along a row
        if (piecePosition.x == Destination.x)
        {
            for (int y = piecePosition.y + yDirection; y * yDirection < Destination.y * yDirection; y += yDirection)
            {
                route.Add(new Vector2Int(piecePosition.x, y));
            }
        }

        // Along a column
        else if (piecePosition.y == Destination.y)
        {
            for (int x = piecePosition.x + xDirection; x * xDirection < Destination.x * xDirection; x += xDirection)
            {
                route.Add(new Vector2Int(x, piecePosition.y));
            }
        }
        // Diagonal
        else
        {
            for (int x = piecePosition.x + xDirection, y = piecePosition.y + yDirection; 
                 x * xDirection < piecePosition.x * xDirection && y * yDirection < piecePosition.y * yDirection;
                 x += xDirection, y += yDirection)
            {
                route.Add(new Vector2Int(x, y));
            }
        }
        return route;
    }
}
