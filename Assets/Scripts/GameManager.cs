using Assets.Scripts.Board.Moves;
using Assets.Scripts.Board.Pieces;
using Board.Squares;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField]
        TileFactory tileFactory;
        [SerializeField]
        PieceFactory pieceFactory;

        SideType CurrentTurn { set; get; }

        IBoardManager board;

        List<IMove> Moves { get; set; }	// List of all the moves

        void Start()
        {
            board = new BoardManager(this, pieceFactory, tileFactory);
            CurrentTurn = SideType.White;
            Moves = new List<IMove>();
        }

        public void TryMovePiece(IPieceGameObject pieceGameObject, Vector2Int destination)
        {
            ITileGameObject destinationTile = board.GetTile(destination);

            // Check if we move piece out of bounds and got empty tile
            if (destinationTile == null)
            {
                // Find the piece which was on the origin tile and move it back
                pieceGameObject.SyncLogicPosition();
                return;
            }

            TryMovePiece(new Move(pieceGameObject, destination));
        }

        private void TryMovePiece(IMove move)
        {
            IPieceGameObject piece = move.Piece;
            PieceLogic pieceLogic = piece.Logic;
            if (pieceLogic.Position == move.Destination)
            {
                Debug.Log("Same tile");
                piece.SyncLogicPosition();
                return;
            }
        }

        // Check all scenarios where a move can be illegal:

        //  - Whos turn is it
        //  - The piece can do this kind of move
        //  - In case of Pawn, Rook, Bishop and queen: We don't pass through other pieces
        //  - In case of Pawn, diagonal or En-passant are only legal in specific cases
        //  - If the destination has piece, that it is opponent piece
        //  - The king is not in check due to this move
        private bool IsMoveLegal(Move move)
        {
            IPieceGameObject piece = move.Piece;
            PieceLogic pieceLogic = piece.Logic;
            /*
            if (pieceLogic.Position == move.Destination.Position)
            {
                Debug.Log("Same tile");
                return false;
            }*/

            // Check if this is this color turn
            if (pieceLogic.SideType != CurrentTurn)
            {
                Debug.Log("Not your turn");
                return false;
            }

            // Check if the target tile is valid for this kind of piece
            List<Vector2Int> validMovesForPiece = pieceLogic.GetMoves();
            bool contains = false;
            foreach (Vector2Int position in validMovesForPiece)
            {
                if (position == move.Destination)
                {
                    contains = true;
                    break;
                }
            }

            if (!contains)
            {
                Debug.Log("Not a valid move for this kind of piece");
                return false;
            }

            // Check that we dont go through pieces
            List<Vector2Int> route = move.GetRoute();
            foreach (Vector2Int position in route)
            {
                if (board.GetPiece(position) != null)
                {
                    Debug.Log("Cannot move through pieces");
                    return false;
                }
            }

            // Special case of Pawn
            if (pieceLogic is Pawn)
            {
                // Check if this is a diagonal move
                if (pieceLogic.Position.y != move.Destination.y)
                {
                    // Check that destination tile is not empty
                    if (board.GetPiece(move.Destination) == null)
                    {
                        // Check private case of En passant 
                        IMove lastMove = Moves[Moves.Count - 1];
                        PieceLogic lastPieceLogic = lastMove.Piece.Logic;
                        if (!(lastPieceLogic is Pawn && lastMove.Destination.y == move.Destination.y &&
                            Mathf.Abs(lastPieceLogic.Position.x - lastMove.Destination.x) == 2))
                        {
                            Debug.Log("Illegal move: Pawn cannot move diagonally to an empty tile (excluding EnPassant)");
                            return false;
                        }
                    }
                }
            }

            // Check that the destination tile is not occupied with same color piece
            IPieceGameObject pieceDestination = board.GetPiece(move.Destination);
            if (pieceDestination != null)
            {
                if (pieceDestination.Logic.SideType == CurrentTurn)
                {
                    Debug.Log("Illegal move: destination has piece with the same color");
                    return false;
                }
            }

            // Check that the king is not exposed to check after this move
            // For this we need to copy current board, make the move and check if it is valid
            BoardLogic boardCopy = board.logic.Copy();
            Move moveCopy = new Move(boardCopy.GetTileLogic(move.origin.x, move.origin.column),
                boardCopy.GetTileLogic(move.destination.x, move.destination.column), false);
            MakeMove(moveCopy, boardCopy, false);
            TileLogic kingTile = boardCopy.GetKingTile(this.currentTurn);
            if (boardCopy.isTileChecked(kingTile, this.currentTurn))
            {
                Debug.Log("Illegal move: " + this.currentTurn.ToString() + " King is checked");
                return false;
            }

            // Check castle
            if (piece.logic is King)
            {
                if (move.type == Game.MoveType.CastleShort || move.type == Game.MoveType.CastleLong)
                {
                    // Check the king wasn't threatend
                    if (board.logic.isTileChecked(move.origin, move.color))
                    {
                        Debug.Log("Illegal move: Cannot castle while checked");
                        return false;
                    }

                    // Check we didn't pass through check
                    TileLogic t = move.GetRoute()[0];
                    if (board.logic.isTileChecked(t, move.color))
                    {
                        Debug.Log("Illegal move: Cannot castle while passing through check");
                        return false;
                    }

                    // Check the king didn't move from the start of game
                    if (piece.logic.hasMoved)
                    {
                        Debug.Log("Illegal move: Cannot castle after the king has moved");
                        return false;
                    }

                    // Check the relevant rook didn't moved
                    bool flagRookMoved = false;
                    if (move.type == Game.MoveType.CastleShort)
                    {
                        PieceLogic p = board.logic.GetPieceLogic(move.destination.x, move.destination.column + 1);
                        if (p == null)
                        {
                            flagRookMoved = true;
                        }
                        else
                        {
                            if (p.type == Game.PieceType.Rook && p.hasMoved == true)
                            {
                                flagRookMoved = true;
                            }
                            if (p.type != Game.PieceType.Rook)
                            {
                                flagRookMoved = true;
                            }
                        }
                    }
                    if (move.type == Game.MoveType.CastleLong)
                    {
                        PieceLogic p = board.logic.GetPieceLogic(move.destination.x, move.destination.column - 2);
                        if (p == null)
                        {
                            flagRookMoved = true;
                        }
                        else
                        {
                            if (p.type == Game.PieceType.Rook && p.hasMoved == true)
                            {
                                flagRookMoved = true;
                            }
                            if (p.type != Game.PieceType.Rook)
                            {
                                flagRookMoved = true;
                            }
                        }
                    }
                    if (flagRookMoved)
                    {
                        Debug.Log("Illegal move: Cannot castle after the rook has moved");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
