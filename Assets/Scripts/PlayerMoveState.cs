using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMoveState : PlayerState
{
    private Transform coreHitTransform = null;
    protected float InputDirection { get; set; } = 0;
    protected abstract Vector2 MoveDirection { get; }
    protected abstract PlayerRecoverSizeState RecoverSizeState { get; }

    public PlayerMoveState(Entity entity) : base(entity)
    {
        InitializeInputDirection();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        MovePlayer();
    }

    private void StayAtCore()
    {
        if (coreHitTransform == null) return;

        if(entity.Rb != null) entity.Rb.velocity = Vector2.zero;
        entity.MyTransform.position = coreHitTransform.position;
        ChangeToSizeRecoverState();
        return;
    }

    public override void CollisionEnter(Collider2D collsion)
    {
        base.CollisionEnter(collsion);
        if (collsion.GetComponent<BaseCore>() != null)
        {
            coreHitTransform = collsion.gameObject.GetComponent<Transform>();
            StayAtCore();
        }
    }

    #region MovePlayer
    private void MovePlayer()
    {
        if (entity.Rb == null) return;
        entity.Rb.velocity = MoveDirection;
    }
    #endregion

    #region ChangeToSizeRecoverState
    private void ChangeToSizeRecoverState()
    {
        entity.StateMachine.ChangeState(RecoverSizeState);
    }
    #endregion

    #region InitializeInputDirection Abstract Method
    protected abstract void InitializeInputDirection();
    #endregion
}
