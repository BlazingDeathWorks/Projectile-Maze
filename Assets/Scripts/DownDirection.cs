using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DownDirection : VerticalDirection
{
    public override Vector2 Direction { get; protected set; } = new Vector2(0, -1);

    public DownDirection(CoreData coreData, float projectileSpeed) : base (coreData)
    {
        Direction = new Vector2(Direction.x, projectileSpeed * Direction.y);
    }
}
