using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LeftDirection : HorizontalDirection
{
    public override Vector2 Direction { get; protected set; } = new Vector2(-1, 0);

    public LeftDirection(CoreData coreData, float projectileSpeed) : base(coreData)
    {
        Direction = new Vector2(projectileSpeed * Direction.x, Direction.y);
    }
}
