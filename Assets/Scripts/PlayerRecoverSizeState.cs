using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerRecoverSizeState : MovablePlayerState
{
    protected sealed override string AnimatorBoolName => "PlayerSizeRecover";
    private float timeSinceStateActivated = 0f;
    private float animatorStateTimeLength = 0f;
    private AnimatorStateInfo animatorStateInfo;

    public PlayerRecoverSizeState(Entity entity) : base(entity)
    {

    }

    public override void Enter()
    {
        const int animatorBaseLayer = 0;
        base.Enter();
        animatorStateInfo = entity.Animator.GetCurrentAnimatorStateInfo(animatorBaseLayer);
        animatorStateTimeLength = animatorStateInfo.length;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        timeSinceStateActivated += Time.deltaTime;
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
        CheckTimeInState();
    }

    private void CheckTimeInState()
    {
        if (timeSinceStateActivated >= animatorStateTimeLength)
        {
            entity.StateMachine.ChangeState(new PlayerIdleState(entity));
        }
    }
}
