using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileGeneratorDataBase
{
    public DirectionBase Direction { get; protected set; } = null;
    public ProjectileBase ProjectileObject { get; protected set; } = null;
}
