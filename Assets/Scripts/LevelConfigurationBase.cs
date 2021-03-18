using UnityEngine;

public abstract class LevelConfigurationBase : ScriptableObject
{
    [SerializeField]
    Texture2D texture = null;
    [SerializeField]
    private ColorToObjectBase[] colorToObjects;
    [SerializeField] [Tooltip("Should have as many items in this array as the number of cores going to be in the scene")]
    private CoreData[] coreData = null;
    [SerializeField]
    CustomGridData customGridData = null;

    public Texture2D Texture { get => texture; }
    public ColorToObjectBase[] ColorToObjects { get => colorToObjects; }
    public CoreData[] CoreData { get => coreData; }
    public CustomGridData CustomGridData { get => customGridData; }
    public Color currentPixelColor { get; protected set; }

    public abstract void GetColorForPixel(int x, int y);
}