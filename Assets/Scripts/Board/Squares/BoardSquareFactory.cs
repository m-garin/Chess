using Board.Squares;
using UnityEngine;

public class BoardSquareFactory : MonoBehaviour, IBoardSquareFactory
{
    [SerializeField]
    GameObject[] squares;

    public GameObject CreateSquare(SideTypes type, int x, int y)
    {
        return Instantiate(squares[(int) type], new Vector3(x, y, 0), Quaternion.identity, transform);
    }
}
