using Assets.Scripts.Board.Pieces;
using Board.Squares;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private BoardSquareFactory _squareFactory;
    [SerializeField]
    private PieceFactory pieceFactory;

    // Use this for initialization
    void Start () {
		DrawBoard(_squareFactory);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DrawBoard(IBoardSquareFactory squareFactory)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                SideTypes squareType = SideTypes.White;
                if ((y % 2 == 0 && x % 2 == 0) || (y % 2 != 0 && x % 2 != 0))
                {
                    squareType = SideTypes.Black;
                }

                squareFactory.CreateSquare(squareType, x, y);
            }
        }
    }

    void PopulateBoard()
    {

        pieceFactory.CreatePiece(SideTypes.White, PieceTypes.King);
    }
}
