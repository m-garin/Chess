using UnityEngine;

public class PieceGameObject : MonoBehaviour, IPieceGameObject
{
    IGameManager gameManager;
    Vector3 distance;

    public PieceLogic Logic { get; private set; }

    public Vector2Int Position
    {
        set
        {
            transform.position = new Vector3(value.x, value.y, 0);
        }
        get
        {
            return Logic.Position; 
        }
    }

    public void Instantiate(IGameManager _gameManager, PieceLogic _logic)
    {
        gameManager = _gameManager;
        Logic = _logic;
    }

    public void SyncLogicPosition()
    {
        Position = Logic.Position;
    }

    void OnMouseDown()
    {
        distance = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z)) - transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 distance_to_screen = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen.z));
        transform.position = new Vector3(pos_move.x - distance.x, pos_move.y - distance.y, 0);
    }

    void OnMouseUp()
    {
        // Get destination tile
        Vector2Int position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        gameManager.TryMovePiece(this, position);
    }
}
