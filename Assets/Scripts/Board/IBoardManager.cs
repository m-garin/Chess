using Assets.Scripts.Board.Pieces;
using Board.Squares;
using UnityEngine;

public interface IBoardManager
{
    Piece[,] Pieces { get; }
    Piece SelectedPiece { get; }
    void TrySelectPiece(Vector2Int position);
    void TryMovePiece(Vector2Int position);
}
