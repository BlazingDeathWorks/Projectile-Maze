using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Control the player movement UI
public sealed class PlayerIdleState : MovablePlayerState
{
    protected override string AnimatorBoolName => "PlayerIdle";
    private const float raycastDistance = 64f;
    private RaycastHit2D raycastHit;
    private Vector2[] cardinalDirections = new Vector2[4];

    public override void Enter()
    {
        base.Enter();
        AddInputManagerEvents();
    }

    public override void Exit()
    {
        base.Exit();
        SubtractInputManagerEvents();
    }

    public PlayerIdleState(Entity entity) : base(entity)
    {
        cardinalDirections[0] = new Vector2(0, raycastDistance);
        cardinalDirections[1] = new Vector2(0, -raycastDistance);
        cardinalDirections[2] = new Vector2(raycastDistance, 0);
        cardinalDirections[3] = new Vector2(-raycastDistance, 0);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        DrawRaycastByDirection();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
    }

    private void DrawRaycastByDirection()
    {
        foreach (Vector2 cardinalDirection in cardinalDirections)
        {
            raycastHit = Physics2D.Raycast(entity.MyTransform.position, cardinalDirection, raycastDistance, entity.TargetLayer);
            Debug.DrawRay(entity.MyTransform.position, cardinalDirection, Color.green);
            CheckRaycastHit();
        }
    }

    private void CheckRaycastHit()
    {
        if (raycastHit)
        {
            return;
        }
    }
}
