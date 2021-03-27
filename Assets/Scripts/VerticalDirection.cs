using UnityEngine;

public class VerticalDirection : DirectionBase
{
    public VerticalDirection(CoreData coreData) : base(coreData)
    {
        VectorScale = new Vector3(ScaleValueWidth, ScaleValueLength);
    }
}
