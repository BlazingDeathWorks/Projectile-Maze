using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGeneratorData : ProjectileGeneratorDataBase
{
    public ProjectileGeneratorData(DirectionBase dir, CoreData coreData)
    {
        Direction = dir;
        ProjectileObject = coreData.ProjectileObject;
        ProjectileDamage = coreData.ProjectileDamage;
    }
}
