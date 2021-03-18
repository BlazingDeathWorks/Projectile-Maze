using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public abstract class ProjectileGeneratorBase : MonoBehaviour
{
    public ProjectileGeneratorDataBase ProjectileGeneratorData { protected get; set; } = new ProjectileGeneratorData();
    protected ProjectileBase InstantiatedProjectile { get; private set; } = null;

    public void ManualAwake()
    {
        InstantiatedProjectile = Instantiate(ProjectileGeneratorData.ProjectileObject, transform.position, Quaternion.identity);
        InstantiatedProjectile.ProjectileGeneratorBase = this;
        InstantiatedProjectile.transform.parent = transform;
        InstantiatedProjectile?.gameObject.SetActive(false);
    }

    protected abstract void EnableProjectile();

    public abstract void DestroyProjectile();
}