using Board.Squares;
using UnityEngine;

namespace Assets.Scripts.Board.Pieces
{
    public class PieceFactory : MonoBehaviour, IPieceFactory
    {
        [SerializeField]
        GameObject[] whitePieces;
        [SerializeField]
        GameObject[] blackPieces;

        IGameManager gameManager;

        public void Instantiate(IGameManager _gameManager)
        {
            gameManager = _gameManager;
        }

        public IPieceGameObject CreatePiece(SideType sideType, PieceType pieceType, Vector2Int position)
        {
            IPieceGameObject piece;
            if (sideType == SideType.White) 
            {
                piece = Instantiate(whitePieces[(int)pieceType], transform).GetComponent<PieceGameObject>();
            }
            else
            {
                piece = Instantiate(blackPieces[(int)pieceType], transform).GetComponent<PieceGameObject>();
            }

            PieceLogic logic;
            switch (pieceType)
            {
                case PieceType.King:
                    logic = new King(sideType);
                    break;
                case PieceType.Queen:
                    logic = new Queen(sideType);
                    break;
                case PieceType.Bishop:
                    logic = new Bishop(sideType);
                    break;
                case PieceType.Knight:
                    logic = new Knight(sideType);
                    break;
                case PieceType.Rook:
                    logic = new Rook(sideType);
                    break;
                default:
                    logic = new Pawn(sideType);
                    break;
            }
            logic.Position = position;
            piece.Instantiate(gameManager, logic);
            piece.SyncLogicPosition();
            return piece;
        }
    }
}
