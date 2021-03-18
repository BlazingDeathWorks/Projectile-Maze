using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldManager : MonoBehaviour
{
    [SerializeField]
    LevelConfigurationBase levelConfiguration = null;
    ITextureColorScan gameWorldTextureColorScan = null;

    private void Awake()
    {
        CustomGrid<GameObject> grid = new CustomGrid<GameObject>(levelConfiguration.CustomGridData);
        gameWorldTextureColorScan = GetComponent<ITextureColorScan>();
        gameWorldTextureColorScan.SetLevelConfig(grid, levelConfiguration);
    }
    private void Start()
    {
        gameWorldTextureColorScan.ScanTexture();
    }
}
