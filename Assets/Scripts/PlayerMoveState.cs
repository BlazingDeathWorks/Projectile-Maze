using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMoveState : PlayerState
{
    private const float raycastDistance = 64f;
    private const float maximumDistanceApart = 0.1f;
    private RaycastHit2D raycastHit;
    private Transform raycastHitTransform = null;
    protected abstract Vector2 MoveDirection { get; }
    protected abstract Vector2 RaycastPointOffsetted { get; }
    protected abstract PlayerRecoverSizeState RecoverSizeState { get; }
    protected float InputDirection { get; set; } = 0;

    public PlayerMoveState(Entity entity) : base(entity)
    {

    }

    public override void Enter()
    {
        base.Enter();
        InitializeInputDirection();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        MovePlayer();
        DrawRaycastByDirection();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        InitializeRaycastHitTransform();
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
        CheckNearestCoreDistance();
    }

    private void CheckNearestCoreDistance()
    {
        if (raycastHitTransform == null) return;
        if (Vector2.Distance(entity.MyTransform.position, raycastHitTransform.position) <= maximumDistanceApart)
        {
            entity.rb.velocity = Vector2.zero;
            entity.MyTransform.position = raycastHitTransform.position;
            ChangeToSizeRecoverState();
        }
    }

    private void DrawRaycastByDirection()
    {
        raycastHit = Physics2D.Raycast(RaycastPointOffsetted, MoveDirection, raycastDistance, entity.TargetLayer);
        //Drawing the raycast for visualizing purposes
        Debug.DrawRay(RaycastPointOffsetted, MoveDirection);
    }

    private void MovePlayer()
    {
        entity.rb.velocity = MoveDirection;
    }

    private void InitializeRaycastHitTransform()
    {
        if (raycastHit && raycastHitTransform == null)
        {
            Debug.Log("RaycastHitTransform has been initialized");
            raycastHitTransform = raycastHit.collider.GetComponent<Transform>();
        }
    }

    private void ChangeToSizeRecoverState()
    {
        entity.StateMachine.ChangeState(RecoverSizeState);
    }

    protected abstract void InitializeInputDirection();
}
