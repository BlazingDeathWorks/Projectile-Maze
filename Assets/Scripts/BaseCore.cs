using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] [RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseCore : MonoBehaviour
{
    protected CustomGridData generatorGridData = null;
    protected CustomGrid<ProjectileGeneratorBase> generatorGrid = null;
    protected ProjectileGeneratorBase[] generators = new ProjectileGeneratorBase[CoreTotalGenerators.TotalGenerators];
    protected CoreData CoreData { get; set; } = null;

    public abstract void CreateGenerators();

    public abstract void ConstructCore(CoreData coreData);

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        CoreData.DoOnTriggerStay(collision);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {

    }
}
