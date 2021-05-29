using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ProjectileGenerator : ProjectileGeneratorBase
{
    public override void ManualAwake()
    {
        InstantiatedProjectile = Instantiate(ProjectileGeneratorData.ProjectileObject, transform.position, Quaternion.identity);
        InstantiatedProjectile.ProjectileGeneratorBase = this;
        InstantiatedProjectile.transform.localScale = ProjectileGeneratorData.Direction.VectorScale;
        InstantiatedProjectile.ProjectileDataBase = new ProjectileData(ProjectileGeneratorData);
        InstantiatedProjectile.transform.parent = transform;
        InstantiatedProjectile?.gameObject.SetActive(false);
    }

    public override void EnableProjectile()
    {
        //Checks if Instantiated Projectile
        if (!InstantiatedProjectile) return;
        InstantiatedProjectile.gameObject.SetActive(true);
        InstantiatedProjectile.MoveProjectile(ProjectileGeneratorData.Direction);
    }

    public override void DestroyProjectile()
    {
        if (!InstantiatedProjectile) return;
        InstantiatedProjectile.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = null;
        Damager.DealDamage(collision, out damagable, () => damagable.TakeDamage(damagable.MaxHealth));
    }
}
