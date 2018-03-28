using UnityEngine;
using System;

public interface IInputDevice
{
    event Action<Vector2Int> LBMPressed;

    Vector2Int Position { get; }
}
