using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerRecoverSizeState : MovablePlayerState
{
    protected const string AnimatorBoolName = "PlayerSizeRecover";

    public PlayerRecoverSizeState(Entity entity) : base(entity)
    {

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

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
    }

    private void SetPlayerAnimation(bool value)
    {
        entity.Animator.SetBool(AnimatorBoolName, value);
    }
}
