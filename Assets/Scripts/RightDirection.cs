using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RightDirection : DirectionBase
{
    public sealed override Vector2 Direction { get; protected set; } = new Vector2(1, 0);

    public RightDirection(float projectileSpeed)
    {
        Direction = new Vector2(projectileSpeed * Direction.x, Direction.y);
    }
}
