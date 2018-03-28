using Assets.Scripts.Board.Pieces;
using Board.Squares;
using UnityEngine;

public class BoardManager : IBoardManager
{
    readonly IPieceFactory pieceFactory;
    public Piece[,] Pieces { private set; get; }
    SideTypes CurrentTurn { set; get; }
    bool[,] AllowedMoves { get; set; }
    Piece selectedPiece;

    public BoardManager (IPieceFactory _pieceFactory, IBoardSquareFactory squareFactory) 
    {
        DrawBoard(squareFactory);
        pieceFactory = _pieceFactory;
        PopulateBoard();
        CurrentTurn = SideTypes.White;
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
        Pieces = new Piece[8, 8];

        //WHITE TEAM SPAWN
        SpawnPiece(SideTypes.White, PieceTypes.King, 3, 0);
        SpawnPiece(SideTypes.White, PieceTypes.Queen, 4, 0);
        SpawnPiece(SideTypes.White, PieceTypes.Rook, 0, 0);
        SpawnPiece(SideTypes.White, PieceTypes.Rook, 7, 0);
        SpawnPiece(SideTypes.White, PieceTypes.Bishop, 2, 0);
        SpawnPiece(SideTypes.White, PieceTypes.Bishop, 5, 0);
        SpawnPiece(SideTypes.White, PieceTypes.Knight, 1, 0);
        SpawnPiece(SideTypes.White, PieceTypes.Knight, 6, 0);
        for (int x = 0; x < 8; x++)
        {
            SpawnPiece(SideTypes.White, PieceTypes.Pawn, x, 1);
        }

        //BLACK TEAM SPAWN
        SpawnPiece(SideTypes.Black, PieceTypes.King, 4, 7);
        SpawnPiece(SideTypes.Black, PieceTypes.Queen, 3, 7);
        SpawnPiece(SideTypes.Black, PieceTypes.Rook, 0, 7);
        SpawnPiece(SideTypes.Black, PieceTypes.Rook, 7, 7);
        SpawnPiece(SideTypes.Black, PieceTypes.Bishop, 2, 7);
        SpawnPiece(SideTypes.Black, PieceTypes.Bishop, 5, 7);
        SpawnPiece(SideTypes.Black, PieceTypes.Knight, 1, 7);
        SpawnPiece(SideTypes.Black, PieceTypes.Knight, 6, 7);
        for (int x = 0; x < 8; x++)
        {
            SpawnPiece(SideTypes.Black, PieceTypes.Pawn, x, 6);
        }
    }

    void SpawnPiece (SideTypes sideType, PieceTypes pieceType, int x, int y) 
    {
        Pieces[x, y] = pieceFactory.CreatePiece(sideType, pieceType, x, y);
    }

    public void SelectPiece(Vector2Int position)
    {
        Piece piece = Pieces[position.x, position.y];
        if (piece == null || piece.SideType != CurrentTurn)
        {
            return;
        }

        bool hasOneMove = false;

        AllowedMoves = piece.PossibleMoves();
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (AllowedMoves[x, y])
                {
                    hasOneMove = true;
                    x = 8;
                    break;
                }
            }        
        }

        if (!hasOneMove)
        {
            return;
        }

        selectedPiece = piece;
        Debug.Log(selectedPiece);
    }
}
