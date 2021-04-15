using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    private IDamagable damagable = null;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out damagable))
        {
            damagable.TakeDamage(damagable.MaxHealth);
        }
    }
}
