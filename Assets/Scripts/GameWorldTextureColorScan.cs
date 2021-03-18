using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldTextureColorScan : MonoBehaviour, ITextureColorScan
{
    private LevelConfigurationBase levelConfig = null;
    private IColorToPrefab gameWorldColorToPrefab = null;
    CustomGrid<GameObject> gameWorldGrid = null;

    private void Awake()
    {
        gameWorldColorToPrefab = GetComponent<IColorToPrefab>();
    }

    public void ScanTexture()
    {
        Vector2Int pixelPos = new Vector2Int(0, 0);
        for (int x = 0; x < levelConfig.Texture.width; x++)
        {
            for (int y = 0; y < levelConfig.Texture.height; y++)
            {
                levelConfig.GetColorForPixel(x, y);
                gameWorldColorToPrefab.ColorToPrefab(gameWorldGrid, ChangeXY(pixelPos, x, y), levelConfig);
            }
        }
    }

    public void SetLevelConfig(CustomGrid<GameObject> gameWorldGrid, LevelConfigurationBase levelConfig)
    {
        this.gameWorldGrid = gameWorldGrid;
        this.levelConfig = levelConfig;
    }

    private Vector2Int ChangeXY(Vector2Int pos, int x, int y)
    {
        pos.x = x;
        pos.y = y;
        return pos;
    }
}
