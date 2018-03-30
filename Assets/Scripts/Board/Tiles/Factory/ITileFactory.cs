using Board.Squares;

public interface ITileFactory
{
    ITileGameObject CreateTile(SideType type, int x, int y);
}
