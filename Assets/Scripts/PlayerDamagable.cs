using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : MonoBehaviour, IDamagable
{
    [SerializeField]
    private GameObject deathParticle = null;
    private static int maxHealth = 10;
    private int health = maxHealth;
    private SpriteRenderer sr = null;
    private Rigidbody2D rb = null;
    public bool Invincible { get; set; } = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        if (Invincible) return;
        health -= damage;
        Mathf.Clamp(health, 0, maxHealth);
        CheckHealthZero();
    }
    
    private void CheckHealthZero()
    {
        if(health <= 0)
        {
            if (deathParticle) Instantiate(deathParticle, transform.position, transform.rotation);
            if (sr != null) Destroy(sr);
            if (rb != null) Destroy(rb);
        }
    }
}
