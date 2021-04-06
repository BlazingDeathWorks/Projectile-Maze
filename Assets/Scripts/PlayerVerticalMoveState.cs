using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerticalMoveState : PlayerMoveState
{
    protected override Vector2 MoveDirection { get => new Vector2(0, InputDirection * entity.EntitySpeed); }
    protected override string AnimatorBoolName { get => "PlayerVertical"; }
    protected override PlayerRecoverSizeState RecoverSizeState { get => new PlayerVerticalRecoverSizeState(entity); }
    protected override Vector2 RaycastPointOffsetted => new Vector2(entity.MyTransform.position.x, (entity.MyTransform.position.y + 0.6f) * InputDirection);

    public PlayerVerticalMoveState(Entity entity) : base(entity)
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
        InputDirection = Input.GetAxisRaw("Vertical");
    }
}
