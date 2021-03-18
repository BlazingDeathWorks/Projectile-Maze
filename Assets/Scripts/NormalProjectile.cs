using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NormalProjectile : ProjectileBase
{
    //Check for IDamagable Object to make them take damage.
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
