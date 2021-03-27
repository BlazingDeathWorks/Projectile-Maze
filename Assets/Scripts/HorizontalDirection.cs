using UnityEngine;

public class HorizontalDirection : DirectionBase
{
    public HorizontalDirection(CoreData coreData) : base(coreData)
    {
        VectorScale = new Vector3(ScaleValueLength, ScaleValueWidth);
    }
}
