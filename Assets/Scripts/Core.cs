using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Core : BaseCore
{
    private Rigidbody2D rb = null;
    private BoxCollider2D boxCollider = null;
    private Vector2 originalBoxColliderSize;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalBoxColliderSize = boxCollider.size;
    }

    #region CustomGridMethods
    private void InitializeCustomGrid()
    {
        if (generatorGridData != null)
        {
            generatorGrid = new CustomGrid<ProjectileGeneratorBase>(generatorGridData);
        }
    }

    private void InitializeCustomGridData()
    {
        generatorGridData = new CustomGridData(new Vector2Int((int)transform.position.x, (int)transform.position.y));
    }
    #endregion

    private void InitializeCompleteCustomGrid()
    {
        InitializeCustomGridData();
        InitializeCustomGrid();
    }

    public override void ConstructCore(CoreData coreData)
    {
        CoreData = coreData;
        InitializeCompleteCustomGrid();
        generatorGrid.InstantiatingObject = coreData.Generator;
    }

    public override void CreateGenerators()
    {
        for (int i = 0; i < CoreTotalGenerators.TotalGenerators; i++)
        {
            generators[i] = generatorGrid.InstantiateGridObject(CoreData.GeneratorPositions[i]);
            generators[i].ProjectileGeneratorData = new ProjectileGeneratorData(CoreData.QuadrantDirections[i], CoreData);
            generators[i].ManualAwake();
            generators[i].transform.parent = transform;
            generators[i].gameObject.SetActive(false);
        }
    }

    #region Trigger & Helper Methods
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        SetColliderToFullSize();
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        rb.WakeUp();
        EnableGenerators();
        CoreData.DoOnTriggerStay(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        DisableEachGenerator();
        SetColliderToOriginalSize();
    }

    private void DisableEachGenerator()
    {
        foreach(ProjectileGeneratorBase generator in generators)
        {
            generator.gameObject.SetActive(false);
        }
    }
    #endregion

    #region SetColliderSize
    private void SetColliderToFullSize()
    {
        const int toFullSizeIncrement = 2;
        Vector2 boxColliderFullSize = new Vector2((CoreData.GeneratorPositions[0].x - CoreData.GeneratorPositions[2].x) + toFullSizeIncrement, (CoreData.GeneratorPositions[0].y - CoreData.GeneratorPositions[2].y) + toFullSizeIncrement);
        boxCollider.size = boxColliderFullSize;
    }

    private void SetColliderToOriginalSize()
    {
        boxCollider.size = originalBoxColliderSize;
    }
    #endregion

    private void EnableGenerators()
    {
        foreach (ProjectileGeneratorBase generator in generators)
        {
            if (generator == null) continue;
            generator.gameObject.SetActive(true);
            generator.EnableProjectile();
        }
    }
}
