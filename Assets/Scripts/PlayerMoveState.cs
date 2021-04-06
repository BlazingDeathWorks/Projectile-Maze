using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMoveState : PlayerState
{
    private const float raycastDistance = 3f;
    private const float maximumDistanceApart = 1f;
    private RaycastHit2D raycastHit;
    private Transform coreHitTransform = null;
    protected abstract Vector2 MoveDirection { get; }
    protected abstract PlayerRecoverSizeState RecoverSizeState { get; }
    protected float InputDirection { get; set; } = 0;
    private static Transform previousRaycastHitTransform = null;
    private const string ignoredCoreLayerName = "Ignored Core";
    const string coreLayerName = "Core";

    public PlayerMoveState(Entity entity) : base(entity)
    {
        InitializeInputDirection();
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
        if (coreHitTransform == null) return;
        if (Vector2.Distance(entity.MyTransform.position, coreHitTransform.position) <= maximumDistanceApart)
        {
            entity.rb.velocity = Vector2.zero;
            entity.MyTransform.position = coreHitTransform.position;
            if(previousRaycastHitTransform != null)
            {
                previousRaycastHitTransform.gameObject.layer = LayerMask.NameToLayer(coreLayerName);
            }
            coreHitTransform.gameObject.layer = LayerMask.NameToLayer(ignoredCoreLayerName);
            previousRaycastHitTransform = coreHitTransform;
            ChangeToSizeRecoverState();
            return;
        }
    }

    private void DrawRaycastByDirection()
    {
        raycastHit = Physics2D.Raycast(entity.MyTransform.position, MoveDirection, raycastDistance, entity.TargetLayer);
        //Drawing the raycast for visualizing purposes
        Debug.DrawRay(entity.MyTransform.position, MoveDirection, Color.green);
    }

    private void MovePlayer()
    {
        entity.rb.velocity = MoveDirection;
    }

    private void InitializeRaycastHitTransform()
    {
        if (raycastHit && coreHitTransform == null)
        {
            Debug.Log("RaycastHit: " + raycastHit.collider.transform.position);
            coreHitTransform = raycastHit.collider.GetComponent<Transform>();
        }
    }

    private void ChangeToSizeRecoverState()
    {
        entity.StateMachine.ChangeState(RecoverSizeState);
        Debug.Log("Changed State to RecoverState");
    }

    protected abstract void InitializeInputDirection();
}
