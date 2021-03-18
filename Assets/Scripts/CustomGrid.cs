using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid<T> where T : Object
{
    public T InstantiatingObject { private get; set; }
    readonly CustomGridData customGridData = null;
    public CustomGrid(CustomGridData customGridData)
    {
        this.customGridData = customGridData;
    }
    public T InstantiateGridObject(Vector2Int gridPos)
    {
        if (InstantiatingObject != null)
        {
            Vector2 newGridPos = FindVectorRelativeToOrigin(gridPos);
            return Object.Instantiate(InstantiatingObject, newGridPos, Quaternion.identity);
        }
        return null;
    }
    private Vector2Int FindVectorRelativeToOrigin(Vector2Int gridPos)
    {
        return new Vector2Int(customGridData.Origin.x + gridPos.x, customGridData.Origin.y + gridPos.y);
    }
}
