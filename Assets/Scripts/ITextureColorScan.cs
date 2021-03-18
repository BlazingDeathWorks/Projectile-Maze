using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITextureColorScan 
{
    public void ScanTexture();
    public void SetLevelConfig(CustomGrid<GameObject> gameWorldGrid, LevelConfigurationBase levelConfig);
}
