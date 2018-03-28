
public class Knight : Piece {

	public override bool[,] PossibleMoves ()
	{
        bool[,] possibleMoves = new bool[8, 8];

        // Up left
        Move(CurrentX - 1, CurrentY + 2, ref possibleMoves);

        // Up right
        Move(CurrentX + 1, CurrentY + 2, ref possibleMoves);

        // Down left
        Move(CurrentX - 1, CurrentY - 2, ref possibleMoves);

        // Down right
        Move(CurrentX + 1, CurrentY - 2, ref possibleMoves);

        // Left Down
        Move(CurrentX - 2, CurrentY - 1, ref possibleMoves);

        // Right Down
        Move(CurrentX + 2, CurrentY - 1, ref possibleMoves);

        // Left Up
        Move(CurrentX - 2, CurrentY + 1, ref possibleMoves);

        // Right Up
        Move(CurrentX + 2, CurrentY + 1, ref possibleMoves);

        return possibleMoves;
	}
}
