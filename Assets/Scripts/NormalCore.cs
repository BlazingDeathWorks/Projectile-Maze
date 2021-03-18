using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NormalCore : BaseCore
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        CoreData.DoOnTriggerStay(collision);
    }
}
