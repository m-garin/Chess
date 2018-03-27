using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }

    [SerializeField]
    bool isWhite;

    public bool IsWhite
    {
        get { return isWhite; }
    }

    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public abstract bool[,] PossibleMoves(Piece[,] pieces);
}
