using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreData : ScriptableObject
{
    [SerializeField]
    private ProjectileGeneratorBase generator = null;
    [SerializeField]
    private ProjectileBase projectileObject = null;
    [SerializeField]
    float projectileSpeed = 1;
    [SerializeField]
    Vector2Int[] generatorPositions = new Vector2Int[CoreTotalGenerators.TotalGenerators];

    public ProjectileGeneratorBase Generator { get => generator; }
    public ProjectileBase ProjectileObject { get => projectileObject; }
    public float ProjectileSpeed { get => projectileSpeed; }
    public Vector2Int[] GeneratorPositions { get => generatorPositions; }

    public abstract void DoOnTriggerStay(Collider2D collision);
}
