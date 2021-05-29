using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Damager
{
    public static void DealDamage<T>(Collider2D collision, out T tryGetComponent, Action CollisionAction)
    {
        if (collision.TryGetComponent(out tryGetComponent))
        {
            CollisionAction();
        }
    }
}
