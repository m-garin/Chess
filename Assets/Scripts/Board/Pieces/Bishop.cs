
public class Bishop : Piece {

	public override bool[,] PossibleMoves (Piece[,] pieces)
	{/*
		bool[,] r = new bool[8, 8];

		Piece c;
		int i, j;

		i = CurrentX;
		j = CurrentY;
		while (true) {
			i--;
			j++;
			if (i < 0 || j >= 8) 
			{
				break;
			}

			c = pieces[i, j];
			if (c == null) {
				r [i, j] = true;
			} 
			else 
			{
				if (IsWhite != c.IsWhite) {
					r [i, j] = true;	
				}
				break;
			}	
		}

		i = CurrentX;
		j = CurrentY;
		while (true) {
			i--;
			j--;
			if (i < 0 || j < 0) 
			{
				break;
			}

			c = pieces[i, j];
			if (c == null) {
				r [i, j] = true;
			} 
			else 
			{
				if (IsWhite != c.IsWhite) {
					r [i, j] = true;	
				}
				break;
			}	
		}

		i = CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j--;
			if (i >= 8 || j < 0) 
			{
				break;
			}

			c = pieces [i, j];
			if (c == null) {
				r [i, j] = true;
			} 
			else 
			{
				if (IsWhite != c.IsWhite) {
					r [i, j] = true;	
				}
				break;
			}	
		}

		i = CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j++;
			if (i >= 8 || j >= 8) 
			{
				break;
			}

			c = pieces [i, j];
			if (c == null) {
				r [i, j] = true;
			} 
			else 
			{
				if (IsWhite != c.IsWhite) {
					r [i, j] = true;	
				}
				break;
			}	
		}

		return r;*/
	    return null;
	}
}
