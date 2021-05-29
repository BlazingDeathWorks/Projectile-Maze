using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerRecoverSizeState : MovablePlayerState
{
    protected sealed override string AnimatorBoolName => "PlayerSizeRecover";
    private float timeSinceStateActivated = 0f;
    private float animatorStateTimeLength = 0f;
    private AnimatorStateInfo animatorStateInfo;
    private bool dashEnabled = false;

    public PlayerRecoverSizeState(Entity entity) : base(entity)
    {
        
    }

    public override void Enter()
    {
        const int animatorBaseLayer = 0;
        animatorStateInfo = entity.Animator.GetCurrentAnimatorStateInfo(animatorBaseLayer);
        animatorStateTimeLength = animatorStateInfo.length;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        if (!dashEnabled) return;
        SubtractInputManagerEvents();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();

        timeSinceStateActivated += Time.deltaTime;

        CheckDash();
    }

    private void CheckDash()
    {
        if (timeSinceStateActivated >= entity.TimeBeforeNextDash && dashEnabled == false)
        {
            AddInputManagerEvents();
            dashEnabled = true;
        }
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
