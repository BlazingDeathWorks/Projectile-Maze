using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected abstract string AnimatorBoolName { get; }

    public PlayerState(Entity entity) : base(entity)
    {
        
    }

    private void SetPlayerAnimation(bool value)
    {
        entity.Animator.SetBool(AnimatorBoolName, value);
    }

    public override void Enter()
    {
        base.Enter();
        SetPlayerAnimation(true);
    }

    public override void Exit()
    {
        base.Exit();
        SetPlayerAnimation(false);
    }
}
