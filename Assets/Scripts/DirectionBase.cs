using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DirectionBase
{
    public virtual Vector2 Direction { get; protected set; } = new Vector2(0, 0);
    public virtual Vector3 VectorScale { get; protected set; } = new Vector3(0, 0, 0);
    protected float ScaleValueWidth { get; private set; } = 0;
    protected float ScaleValueLength { get; private set; } = 0.85f;

    public DirectionBase(CoreData coreData)
    {
        ScaleValueLength = coreData.ProjectileScaleLength;
        ScaleValueWidth = coreData.ProjectileScaleWidth;
    }
}
