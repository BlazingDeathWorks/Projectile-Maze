using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] [RequireComponent(typeof(Rigidbody2D))]
public abstract class ProjectileGeneratorBase : MonoBehaviour
{
    public ProjectileGeneratorDataBase ProjectileGeneratorData { protected get; set; } = null;
    protected ProjectileBase InstantiatedProjectile { get; set; } = null;

    public abstract void ManualAwake();

    public abstract void EnableProjectile();

    public abstract void DestroyProjectile();
}