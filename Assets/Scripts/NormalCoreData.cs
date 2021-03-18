using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCoreData", menuName = "ScriptableObjects / CoreData / NormalCoreData")]
public class NormalCoreData : CoreData
{
    public override void DoOnTriggerStay(Collider2D collision)
    {
        Debug.Log("Do On Trigger Stay is working!!!");
    }
}
