using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour, IInputDevice
{
    Vector2Int lastPosition = Vector2Int.zero;

    public event Action<Vector2Int> CursorPosition;
    /// <summary>
    /// Left button mouse pressed event
    /// </summary>
    public event Action LBMPressed;

    /// <summary>
    /// Get input position
    /// </summary>
    public Vector2Int Position
    {
        get
        {
            return lastPosition;
        }
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50.0f, LayerMask.GetMask("ChessPlane")))
        {
            CursorPosition?.Invoke(GetPosition(hit));
        }

        if (Input.GetMouseButtonDown(0) && !IsUIObject())
            LBMPressed?.Invoke();
    }

    Vector2Int GetPosition(RaycastHit _hit)
    {
        return new Vector2Int(Mathf.FloorToInt(_hit.point.x + 0.5f), Mathf.FloorToInt(_hit.point.y + 0.5f)); //round
    }

    /// <summary>
    /// If pointer is over UI object
    /// </summary>
    bool IsUIObject()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
