using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelConfiguration", menuName = "ScriptableObjects / Level / LevelConfiguration")]
public class LevelConfiguration : LevelConfigurationBase
{
    public override void GetColorForPixel(int x, int y)
    {
        currentPixelColor = Texture.GetPixel(x, y);
    }
}
