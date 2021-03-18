using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] [RequireComponent(typeof(BoxCollider2D))]
public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField]
    protected int damage = 1;
    protected Rigidbody2D rb = null;
    public ProjectileGeneratorBase ProjectileGeneratorBase { private get; set; } = null;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void MoveProjectile(DirectionBase directionBase)
    {
        rb.velocity = directionBase.Direction;
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
