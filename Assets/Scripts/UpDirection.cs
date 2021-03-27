using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class UpDirection : VerticalDirection
{
    public override Vector2 Direction { get; protected set; } = new Vector2(0, 1);

    public UpDirection(CoreData coreData, float projectileSpeed) : base(coreData)
    {
        Direction = new Vector2(Direction.x, projectileSpeed * Direction.y);
    }
}
