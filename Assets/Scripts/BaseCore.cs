using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCore : MonoBehaviour
{
    private DirectionBase[] quadrantDirections = new DirectionBase[4];
    private CustomGridData generatorGridData = null;
    protected CustomGrid<ProjectileGeneratorBase> generatorGrid = null;
    protected ProjectileGeneratorBase[] generators = new ProjectileGeneratorBase[CoreTotalGenerators.TotalGenerators];
    protected CoreData CoreData { get; set; } = null;

    private void InitializeQuadrantDirections()
    {   
        quadrantDirections[0] = new DownDirection(CoreData.ProjectileSpeed);
        quadrantDirections[1] = new RightDirection(CoreData.ProjectileSpeed);
        quadrantDirections[2] = new UpDirection(CoreData.ProjectileSpeed);
        quadrantDirections[3] = new LeftDirection(CoreData.ProjectileSpeed);
    }

    private void InitializeCompleteCustomGrid()
    {
        InitializeCustomGridData();
        InitializeCustomGrid();
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

    public virtual void CreateGenerators()
    {
        for (int i = 0; i < CoreTotalGenerators.TotalGenerators; i++)
        {
            generators[i] = generatorGrid.InstantiateGridObject(CoreData.GeneratorPositions[i]);
            generators[i].ProjectileGeneratorData = new ProjectileGeneratorData(quadrantDirections[i], CoreData.ProjectileObject);
            generators[i].ManualAwake();
            generators[i].transform.parent = transform;
            generators[i].gameObject.SetActive(false);
        }
    }

    public virtual void ConstructCore(CoreData coreData)
    {
        CoreData = coreData;
        InitializeCompleteCustomGrid();
        InitializeQuadrantDirections();
        generatorGrid.InstantiatingObject = coreData.Generator;
    }

    private void EnableGenerators()
    {
        foreach (ProjectileGeneratorBase generator in generators)
        {
            generator.gameObject.SetActive(true);
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        EnableGenerators();
    }
}
