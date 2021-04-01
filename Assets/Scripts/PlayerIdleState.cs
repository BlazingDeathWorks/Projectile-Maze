using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Control the player movement UI
public sealed class PlayerIdleState : MovablePlayerState
{
    public PlayerIdleState(Entity entity) : base(entity)
    {

    }

    public override void Enter()
    {
        base.Enter();
        const string idleStateBool = "PlayerIdle";
        entity.Animator.SetBool(idleStateBool, true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
    }
}
