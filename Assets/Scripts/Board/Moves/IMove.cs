using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Board.Moves
{
    public interface IMove
    {
        IPieceGameObject Piece { get; }
        Vector2Int Destination { get; }

        List<Vector2Int> GetRoute();
    }
}
