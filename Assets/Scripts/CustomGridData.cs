using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomGridData 
{
    [SerializeField]
    Vector2Int origin = new Vector2Int(0, 0);

    public Vector2Int Origin { get => origin; }

    public CustomGridData(Vector2Int originPos)
    {
        origin = originPos;
    }
}
