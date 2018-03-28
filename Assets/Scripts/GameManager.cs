using Assets.Scripts.Board.Pieces;
using Board.Squares;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        BoardSquareFactory squareFactory;
        [SerializeField]
        PieceFactory pieceFactory;
        [SerializeField]
        MouseInput inputDevice;

        IBoardManager boardManager;

        void Start () 
        {
            boardManager = new BoardManager(pieceFactory, squareFactory);
            CurrentTurn = SideTypes.White;
            inputDevice.LBMPressed += SelectSquare;
        }

        void SelectSquare (Vector2Int position) 
        {
            if (boardManager.SelectedPiece == null)
            {
                boardManager.SelectPiece(position);
            }
            else
            {
                boardManager.MovePiece(position);
            }
        }
    }
}
