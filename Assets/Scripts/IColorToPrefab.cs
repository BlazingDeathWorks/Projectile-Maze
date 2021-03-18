using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorToPrefab
{
    void ColorToPrefab(CustomGrid<GameObject> gameWorldGrid, Vector2Int pixelPosWorld, LevelConfigurationBase levelConfig);
}
