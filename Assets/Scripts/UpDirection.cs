using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class UpDirection : DirectionBase
{
    public sealed override Vector2 Direction { get; protected set; } = new Vector2(0, 1);

    public UpDirection(float projectileSpeed)
    {
        Direction = new Vector2(Direction.x, projectileSpeed * Direction.y);
    }
}
