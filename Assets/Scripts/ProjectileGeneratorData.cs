using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGeneratorData : ProjectileGeneratorDataBase
{
    public ProjectileGeneratorData(DirectionBase dir = null, ProjectileBase projectileObject = null)
    {
        Direction = dir;
        ProjectileObject = projectileObject;
    }
}
