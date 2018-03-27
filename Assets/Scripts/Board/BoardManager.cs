using Assets.Scripts.Board.Pieces;
using Board.Squares;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private BoardSquareFactory _squareFactory;
    [SerializeField]
    private PieceFactory pieceFactory;

    public Piece[,] Pieces { private set; get; }

    // Use this for initialization
    void Start () {
		DrawBoard(_squareFactory);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DrawBoard(IBoardSquareFactory squareFactory)
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

        PopulateBoard();
    }

    void PopulateBoard()
    {
        Pieces = new Piece[8, 8];

        //WHITE TEAM SPAWN
        SpawnPiece(SideTypes.White, PieceTypes.King, 4, 7);
        SpawnPiece(SideTypes.White, PieceTypes.Queen, 3, 7);
        SpawnPiece(SideTypes.White, PieceTypes.Rook, 0, 7);
        SpawnPiece(SideTypes.White, PieceTypes.Rook, 7, 7);
        SpawnPiece(SideTypes.White, PieceTypes.Bishop, 2, 7);
        SpawnPiece(SideTypes.White, PieceTypes.Bishop, 5, 7);
        SpawnPiece(SideTypes.White, PieceTypes.Knight, 1, 7);
        SpawnPiece(SideTypes.White, PieceTypes.Knight, 6, 7);

        //BLACK TEAM SPAWN
        SpawnPiece(SideTypes.Black, PieceTypes.King, 3, 0);
        SpawnPiece(SideTypes.Black, PieceTypes.Queen, 4, 0);
        SpawnPiece(SideTypes.Black, PieceTypes.Rook, 0, 0);
        SpawnPiece(SideTypes.Black, PieceTypes.Rook, 7, 0);
        SpawnPiece(SideTypes.Black, PieceTypes.Bishop, 2, 0);
        SpawnPiece(SideTypes.Black, PieceTypes.Bishop, 5, 0);
        SpawnPiece(SideTypes.Black, PieceTypes.Knight, 1, 0);
        SpawnPiece(SideTypes.Black, PieceTypes.Knight, 6, 0);
    }

    void SpawnPiece (SideTypes sideType, PieceTypes pieceType, int x, int y) 
    {
        Pieces[x, y] = pieceFactory.CreatePiece(sideType, pieceType, x, y);
    }

    public 
}
