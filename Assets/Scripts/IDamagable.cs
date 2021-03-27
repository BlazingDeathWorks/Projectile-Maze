using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    bool Invincible { get; set; }
    void TakeDamage(int damage);
}
