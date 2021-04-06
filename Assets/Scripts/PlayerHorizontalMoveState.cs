using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMoveState : PlayerMoveState
{
    protected override Vector2 MoveDirection { get => new Vector2(InputDirection * entity.EntitySpeed, 0); }
    protected override string AnimatorBoolName { get => "PlayerHorizontal"; }
    protected override PlayerRecoverSizeState RecoverSizeState { get => new PlayerHorizontalRecoverSizeState(entity); }
    protected override Vector2 RaycastPointOffsetted => new Vector2((entity.MyTransform.position.x + 0.6f) * InputDirection, entity.MyTransform.position.y);

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

    protected override void InitializeInputDirection()
    {
        InputDirection = Input.GetAxisRaw("Horizontal");
    }
}
