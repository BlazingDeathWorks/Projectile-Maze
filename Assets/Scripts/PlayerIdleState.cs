using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Control the player movement UI
public sealed class PlayerIdleState : MovablePlayerState
{
    private const string idleStateBoolName = "PlayerIdle";

    public PlayerIdleState(Entity entity) : base(entity)
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
        entity.Animator.SetBool(idleStateBoolName, value);
    }
}
