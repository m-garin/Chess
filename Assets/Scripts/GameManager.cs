using Assets.Scripts.Board.Pieces;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private BoardSquareFactory squareFactory;
        [SerializeField]
        private PieceFactory pieceFactory;

        IBoardManager boardManager;

        void Start () 
        {
            boardManager = new BoardManager(pieceFactory, squareFactory);
        }

        void SelectPiece () 
        {
            boardManager.SelectPiece();
        }

        void Update()
        {
            UpdateMousePosition();

            if (Input.GetMouseButtonDown(0))
            {
                if (mousePositionX >= 0 && mousePositionY >= 0)
                {
                    if (selectedChessPiece == null)
                    {
                        // Select the chessman
                        SelectChessPiece(mousePositionX, mousePositionY);
                    }
                    else
                    {
                        // Move the chessman
                        MoveChessPiece(mousePositionX, mousePositionY);
                    }
                }
            }
        }
    }
}
