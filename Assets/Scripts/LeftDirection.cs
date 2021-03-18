using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LeftDirection : DirectionBase
{
    public sealed override Vector2 Direction { get; protected set; } = new Vector2(-1, 0);

    public LeftDirection(float projectileSpeed)
    {
        Direction = new Vector2(projectileSpeed * Direction.x, Direction.y);
    }
}
