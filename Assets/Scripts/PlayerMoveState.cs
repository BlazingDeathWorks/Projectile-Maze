using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMoveState : PlayerState
{
    private const float raycastDistance = 64f;
    private RaycastHit2D raycastHit;
    protected abstract Vector2 MoveDirection { get; }
    protected float InputDirection { get; set; } = 0;

    public PlayerMoveState(Entity entity) : base(entity)
    {

    }

    public override void Enter()
    {
        base.Enter();
        InitializeInputDirection();
        SetPlayerAnimationEnter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        MovePlayer();
        DetectClosestCore();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
        //Check if distance is good enough to the core
    }

    private void DetectClosestCore()
    {
        raycastHit = Physics2D.Raycast(entity.MyTransform.position, MoveDirection, raycastDistance, entity.TargetLayer);
        //Drawing the raycast; we can delete this once we know we are good
        Debug.DrawLine(entity.MyTransform.position, new Vector2(entity.MyTransform.position.x + raycastDistance, entity.MyTransform.position.y));
        Debug.DrawLine(entity.MyTransform.position, new Vector2(entity.MyTransform.position.x - raycastDistance, entity.MyTransform.position.y));
        Debug.DrawLine(entity.MyTransform.position, new Vector2(entity.MyTransform.position.x, entity.MyTransform.position.y + raycastDistance));
        Debug.DrawLine(entity.MyTransform.position, new Vector2(entity.MyTransform.position.x, entity.MyTransform.position.y - raycastDistance));
        if (raycastHit)
        {
            Debug.Log("We hit a core!!!");
        }
    }

    private void MovePlayer()
    {
        entity.rb.velocity = MoveDirection;
    }

    protected abstract void SetPlayerAnimationEnter();

    protected abstract void InitializeInputDirection();
}
