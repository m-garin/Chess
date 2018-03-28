
public class Bishop : Piece {

	public override bool[,] PossibleMoves ()
	{
        bool[,] possibleMoves = new bool[8, 8];

        int XCoordinate, YCoordinate;

        // Top left
        XCoordinate = CurrentX;
        YCoordinate = CurrentY;
        while (true)
        {
            XCoordinate--;
            YCoordinate++;
            if (XCoordinate < 0 || YCoordinate >= 8)
            {
                break;
            }

            if (Move(XCoordinate, YCoordinate, ref possibleMoves))
            {
                break;
            }
        }

        // Top right
        XCoordinate = CurrentX;
        YCoordinate = CurrentY;
        while (true)
        {
            XCoordinate++;
            YCoordinate++;
            if (XCoordinate >= 8 || YCoordinate >= 8)
            {
                break;
            }

            if (Move(XCoordinate, YCoordinate, ref possibleMoves))
            {
                break;
            }
        }

        // Down left
        XCoordinate = CurrentX;
        YCoordinate = CurrentY;
        while (true)
        {
            XCoordinate--;
            YCoordinate--;
            if (XCoordinate < 0 || YCoordinate < 0)
            {
                break;
            }

            if (Move(XCoordinate, YCoordinate, ref possibleMoves))
            {
                break;
            }
        }

        // Down right
        XCoordinate = CurrentX;
        YCoordinate = CurrentY;
        while (true)
        {
            XCoordinate++;
            YCoordinate--;
            if (XCoordinate >= 8 || YCoordinate < 0)
            {
                break;
            }

            if (Move(XCoordinate, YCoordinate, ref possibleMoves))
            {
                break;
            }
        }

        return possibleMoves;
	}
}
