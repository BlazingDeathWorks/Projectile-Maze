using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Control the player movement UI
public sealed class PlayerIdleState : MovablePlayerState
{
    protected override string AnimatorBoolName => "PlayerIdle";
    private const float raycastDistance = 64f;
    private RaycastHit2D raycastHit;
    private Vector2[] cardinalDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    public PlayerIdleState(Entity entity) : base(entity)
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
        DrawRaycastByDirection();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        CheckRaycastHit();
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
            //Drawing the raycast for visualizing purposes
            Debug.DrawRay(entity.MyTransform.position, cardinalDirection, Color.green);
        }
    }

    private void CheckRaycastHit()
    {
        if (raycastHit)
        {
            //Debug.Log("RaycastHit: " + raycastHit.collider.transform.position);
        }
    }
}
