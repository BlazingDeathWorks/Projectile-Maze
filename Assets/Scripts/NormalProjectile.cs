using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NormalProjectile : ProjectileBase
{
    IDamagable damagableCollisionObject = null;
    ProjectileGeneratorBase generatorCollisionObject = null;

    public override void MoveProjectile(DirectionBase directionBase)
    {
        transform.Translate(directionBase.Direction * Time.deltaTime);
    }

    //Check for IDamagable Object to make them take damage.
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Damager.DealDamage(collision, out damagableCollisionObject, () => damagableCollisionObject.TakeDamage(ProjectileDataBase.ProjectileDamage));

        if (collision.TryGetComponent(out generatorCollisionObject))
        {
            if (generatorCollisionObject == ProjectileGeneratorBase) return;
            ProjectileGeneratorBase.DestroyProjectile();
        }
    }
}
