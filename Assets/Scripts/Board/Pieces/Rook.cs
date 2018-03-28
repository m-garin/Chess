
public class Rook : Piece {

	public override bool[,] PossibleMoves ()
	{
        bool[,] possibleMoves = new bool[8, 8];

        int CurrentCoordinate;

        // Right
        CurrentCoordinate = CurrentX;
        while (true)
        {
            CurrentCoordinate++;
            if (CurrentCoordinate >= 8)
                break;

            if (Move(CurrentCoordinate, CurrentY, ref possibleMoves))
                break;
        }

        // Left
        CurrentCoordinate = CurrentX;
        while (true)
        {
            CurrentCoordinate--;
            if (CurrentCoordinate < 0)
                break;

            if (Move(CurrentCoordinate, CurrentY, ref possibleMoves))
                break;
        }

        // Up
        CurrentCoordinate = CurrentY;
        while (true)
        {
            CurrentCoordinate++;
            if (CurrentCoordinate >= 8)
                break;

            if (Move(CurrentX, CurrentCoordinate, ref possibleMoves))
                break;
        }

        // Down
        CurrentCoordinate = CurrentY;
        while (true)
        {
            CurrentCoordinate--;
            if (CurrentCoordinate < 0)
                break;

            if (Move(CurrentX, CurrentCoordinate, ref possibleMoves))
                break;

        }

        return possibleMoves;
	}
}
