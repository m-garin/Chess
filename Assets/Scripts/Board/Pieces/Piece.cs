using Board.Squares;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }

    [SerializeField]
    SideTypes sideType;

    public SideTypes SideType
    {
        get { return sideType; }
    }

    public IBoardManager BoardManager { get; set; }

    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
        transform.position = new Vector3(x, y, 0.0f);
    }

    public abstract bool[,] PossibleMoves();

    protected bool Move(int x, int y, ref bool[,] AllPossibleMoves)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            Piece piece = BoardManager.Pieces[x, y];
            if (piece == null)
            {
                AllPossibleMoves[x, y] = true;
            }
            else
            {
                if (SideType != piece.SideType)
                {
                    AllPossibleMoves[x, y] = true;
                }
                return true;
            }
        }
        return false;
    }
}
