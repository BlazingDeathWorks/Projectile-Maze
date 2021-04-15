using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int MaxHealth { get; }
    bool Invincible { get; set; }
    void TakeDamage(int damage);
}
