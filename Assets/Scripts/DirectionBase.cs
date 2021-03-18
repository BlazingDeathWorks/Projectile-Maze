using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DirectionBase
{
    public virtual Vector2 Direction { get; protected set; } = new Vector2(0, 0);
}
