using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] [RequireComponent(typeof(BoxCollider2D))]
public abstract class ProjectileBase : MonoBehaviour
{
    public ProjectileDataBase ProjectileDataBase { protected get; set; } = null;
    public ProjectileGeneratorBase ProjectileGeneratorBase { protected get; set; } = null;

    public abstract void MoveProjectile(DirectionBase directionBase);

    //For player collision
    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
