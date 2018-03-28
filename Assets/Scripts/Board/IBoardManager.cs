using Assets.Scripts.Board.Pieces;
using Board.Squares;
using UnityEngine;

public interface IBoardManager
{
    Piece[,] Pieces { get; }

    void SelectPiece(Vector2Int position);
}
