using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Entity entity = null;

    public State(Entity entity)
    {
        this.entity = entity;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void StateUpdate()
    {

    }

    public virtual void TransitionCheck()
    {

    }


    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {
        
    }
}
