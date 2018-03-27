
using Board.Squares;
using UnityEngine;

public interface IBoardSquareFactory
{
    GameObject CreateSquare(SideTypes type, int x, int y);
}
