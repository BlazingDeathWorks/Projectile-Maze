using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected PlayerEntity entity = null;

    public PlayerState(PlayerEntity entity)
    {
        this.entity = entity;
    }

    
}
