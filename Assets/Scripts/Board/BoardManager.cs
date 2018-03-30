using Assets.Scripts.Board.Pieces;
using Board.Squares;
using UnityEngine;

public class BoardManager : IBoardManager
{
    readonly IPieceFactory pieceFactory;
    readonly IHighlights highlights;

    int width = 8;
    int height = 8;

    IPieceGameObject[,] Pieces { set; get; }
    ITileGameObject[,] Tiles { set; get; }

    public BoardManager (IGameManager gameManager, IPieceFactory _pieceFactory, ITileFactory tileFactory) 
    {
        DrawBoard(tileFactory);
        pieceFactory = _pieceFactory;
        pieceFactory.Instantiate(gameManager);
        PopulateBoard();
    }

    void DrawBoard(ITileFactory tileFactory)
    {
        Tiles = new ITileGameObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SideType tileType = SideType.White;
                if ((y % 2 == 0 && x % 2 == 0) || (y % 2 != 0 && x % 2 != 0))
                {
                    tileType = SideType.Black;
                }

                Tiles[x, y] = tileFactory.CreateTile(tileType, x, y);
            }
        }
    }

    void PopulateBoard()
    {
        Pieces = new PieceGameObject[width, height];

        //WHITE TEAM SPAWN
        SpawnPiece(SideType.White, PieceType.King, 3, 0);
        SpawnPiece(SideType.White, PieceType.Queen, 4, 0);
        SpawnPiece(SideType.White, PieceType.Rook, 0, 0);
        SpawnPiece(SideType.White, PieceType.Rook, 7, 0);
        SpawnPiece(SideType.White, PieceType.Bishop, 2, 0);
        SpawnPiece(SideType.White, PieceType.Bishop, 5, 0);
        SpawnPiece(SideType.White, PieceType.Knight, 1, 0);
        SpawnPiece(SideType.White, PieceType.Knight, 6, 0);
        for (int x = 0; x < 8; x++)
        {
            SpawnPiece(SideType.White, PieceType.Pawn, x, 1);
        }

        //BLACK TEAM SPAWN
        SpawnPiece(SideType.Black, PieceType.King, 4, 7);
        SpawnPiece(SideType.Black, PieceType.Queen, 3, 7);
        SpawnPiece(SideType.Black, PieceType.Rook, 0, 7);
        SpawnPiece(SideType.Black, PieceType.Rook, 7, 7);
        SpawnPiece(SideType.Black, PieceType.Bishop, 2, 7);
        SpawnPiece(SideType.Black, PieceType.Bishop, 5, 7);
        SpawnPiece(SideType.Black, PieceType.Knight, 1, 7);
        SpawnPiece(SideType.Black, PieceType.Knight, 6, 7);
        for (int x = 0; x < 8; x++)
        {
            SpawnPiece(SideType.Black, PieceType.Pawn, x, 6);
        }
    }

    void SpawnPiece (SideType SideType, PieceType pieceType, int x, int y) 
    {
        Pieces[x, y] = pieceFactory.CreatePiece(SideType, pieceType, new Vector2Int(x, y));
    }

    public ITileGameObject GetTile(Vector2Int position)
    {
        if (position.x >= 0 && position.x < width && position.y >= 0 && position.y < height)
        {
            return Tiles[position.x, position.y];
        }
        else
        {
            Debug.Log("Out of bounds");
            return null;
        }
    }

    public IPieceGameObject GetPiece(Vector2Int position)
    {
        if (position.x >= 0 && position.x < width && position.y >= 0 && position.y < height)
        {
            return Pieces[position.x, position.y];
        }
        else
        {
            Debug.Log("Out of bounds");
            return null;
        }
    }
}
