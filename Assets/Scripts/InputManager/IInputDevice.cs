using UnityEngine;
using System;

public interface IInputDevice
{
    event Action<Vector2Int> CursorPosition;
    event Action LBMPressed;

    Vector2Int Position { get; }
}
