using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMoveState : PlayerMoveState
{
    protected override Vector2 MoveDirection { get => new Vector2(InputDirection * entity.EntitySpeed, 0); }
    
    public PlayerHorizontalMoveState(Entity entity) : base(entity)
    {

    }


    public override void Enter()
    {
        base.Enter();
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
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
    }

    protected override void SetPlayerAnimationEnter()
    {
        entity.Animator.SetBool("PlayerHorizontal", true);
    }

    protected override void InitializeInputDirection()
    {
        InputDirection = Input.GetAxisRaw("Horizontal");
    }
}
