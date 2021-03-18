using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : ProjectileGeneratorBase
{
    protected override void EnableProjectile()
    {
        if (!InstantiatedProjectile) return;
        InstantiatedProjectile.gameObject.SetActive(true);
        InstantiatedProjectile.MoveProjectile(ProjectileGeneratorData.Direction);
    }

    public override void DestroyProjectile()
    {
        if (!InstantiatedProjectile) return;
        InstantiatedProjectile.gameObject.SetActive(false);
        InstantiatedProjectile.transform.position = transform.position;
        InstantiatedProjectile.gameObject.SetActive(true);
    }
}
