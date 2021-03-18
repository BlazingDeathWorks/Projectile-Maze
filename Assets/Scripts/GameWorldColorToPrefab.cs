using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldColorToPrefab : MonoBehaviour, IColorToPrefab
{
    private int coreDataIndex = 0;
    public void ColorToPrefab(CustomGrid<GameObject> gameWorldGrid, Vector2Int pixelPosWorld, LevelConfigurationBase levelConfig)
    {
        foreach (ColorToObjectBase colorToObject in levelConfig.ColorToObjects)
        {
            if (levelConfig.currentPixelColor.Equals(colorToObject.Color))
            {
                gameWorldGrid.InstantiatingObject = colorToObject.GameObject;
                BaseCore coreInstance = gameWorldGrid.InstantiateGridObject(pixelPosWorld).GetComponent<BaseCore>();
                if (!coreInstance) continue;
                UseCoreInstance(ref coreInstance, levelConfig);
            }
        }
    }
    private void UseCoreInstance(ref BaseCore coreInstance, LevelConfigurationBase levelConfig)
    {
        if (coreDataIndex >= levelConfig.CoreData.Length)
        {
            Debug.LogError("CoreDataIndex is greater than the List of CoreData.... Fix this by going into LevelConfiguration for the corresponding level and add more CoreData\'s");
            return;
        }
        coreInstance.ConstructCore(levelConfig.CoreData[coreDataIndex]);
        coreInstance.CreateGenerators();
        coreDataIndex++;
    }
}
