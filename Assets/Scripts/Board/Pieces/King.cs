
public class King : Piece {

    public override bool[,] PossibleMoves ()
	{
        bool[,] possibleMoves = new bool[8, 8];

        Move(CurrentX + 1, CurrentY, ref possibleMoves); // up
        Move(CurrentX - 1, CurrentY, ref possibleMoves); // down
        Move(CurrentX, CurrentY - 1, ref possibleMoves); // left
        Move(CurrentX, CurrentY + 1, ref possibleMoves); // right
        Move(CurrentX + 1, CurrentY - 1, ref possibleMoves); // up left
        Move(CurrentX - 1, CurrentY - 1, ref possibleMoves); // down left
        Move(CurrentX + 1, CurrentY + 1, ref possibleMoves); // up right
        Move(CurrentX - 1, CurrentY + 1, ref possibleMoves); // down right

        return possibleMoves;
	}
}
