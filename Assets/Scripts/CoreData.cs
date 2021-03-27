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
    int projectileDamage = 1;
    [SerializeField] [Range(0.25f, 0.85f)]
    private float projectileScaleLength = 0.85f;
    [SerializeField] [Tooltip("This is the position of the generator in quadrant one if the core is the origin. This is used to make uniform spacing in the generators")]
    private Vector2Int generatorPos;
    Vector2Int[] generatorPositions = new Vector2Int[CoreTotalGenerators.TotalGenerators];
    float projectileScaleWidth = 0.25f;

    public ProjectileGeneratorBase Generator { get => generator; }
    public ProjectileBase ProjectileObject { get => projectileObject; }
    public float ProjectileSpeed { get => projectileSpeed; }
    public int ProjectileDamage { get => projectileDamage; }
    public float ProjectileScaleWidth { get => projectileScaleWidth; }
    public float ProjectileScaleLength { get => projectileScaleLength; }
    public Vector2Int[] GeneratorPositions { get => generatorPositions; }
    public DirectionBase[] QuadrantDirections { get; private set; } = new DirectionBase[CoreTotalGenerators.TotalGenerators];

    public void SetQuadrantDirections()
    {
        QuadrantDirections[0] = new DownDirection(this, ProjectileSpeed);
        QuadrantDirections[1] = new RightDirection(this, ProjectileSpeed);
        QuadrantDirections[2] = new UpDirection(this, ProjectileSpeed);
        QuadrantDirections[3] = new LeftDirection(this, ProjectileSpeed);
    }

    private void OnValidate()
    {
        SetGeneratorPositions0();
        SetGeneratorPositions1();
        SetGeneratorPositions2();
        SetGeneratorPositions3();
    }

    #region SetGeneratorPositions
    private void SetGeneratorPositions0()
    {
        generatorPositions[0].x = generatorPos.x;
        generatorPositions[0].y = generatorPos.y;
    }

    private void SetGeneratorPositions1()
    {
        generatorPositions[1].x = -generatorPos.x;
        generatorPositions[1].y = generatorPos.y;
    }

    private void SetGeneratorPositions2()
    {
        generatorPositions[2].x = -generatorPos.x;
        generatorPositions[2].y = -generatorPos.y;
    }

    private void SetGeneratorPositions3()
    {
        generatorPositions[3].x = generatorPos.x;
        generatorPositions[3].y = -generatorPos.y;
    }
    #endregion

    public virtual void DoOnTriggerStay(Collider2D collision)
    {

    }
}
