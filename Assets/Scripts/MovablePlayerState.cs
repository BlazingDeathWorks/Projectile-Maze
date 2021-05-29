using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class MovablePlayerState : PlayerState
{
    public MovablePlayerState(Entity entity) : base(entity)
    {

    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
    }

    protected void AddInputManagerEvents()
    {
        if (InputManager.instance == null)
        {
            Debug.LogError("Input Manager Instance Not Working");
            return;
        }
        InputManager.instance.up.OnKeyPress += MoveVertically;
        InputManager.instance.down.OnKeyPress += MoveVertically;
        InputManager.instance.left.OnKeyPress += MoveHorizontally;
        InputManager.instance.right.OnKeyPress += MoveHorizontally;
        //Debugging
        //Debug.Log("Added: " + GetType().Name);
    }

    protected void SubtractInputManagerEvents()
    {
        if (InputManager.instance == null)
        {
            Debug.LogError("Input Manager Instance Not Working");
            return;
        }
        InputManager.instance.up.OnKeyPress -= MoveVertically;
        InputManager.instance.down.OnKeyPress -= MoveVertically;
        InputManager.instance.left.OnKeyPress -= MoveHorizontally;
        InputManager.instance.right.OnKeyPress -= MoveHorizontally;
        //Debugging
        //Debug.Log("Removed: " + GetType().Name);
    }

    private void MoveHorizontally()
    {
        if (entity.Rb == null)
        {
            return;
        }
        entity.StateMachine.ChangeState(new PlayerHorizontalMoveState(entity));
    }

    private void MoveVertically()
    {
        if (entity.Rb == null)
        {
            return;
        }
        entity.StateMachine.ChangeState(new PlayerVerticalMoveState(entity));
    }
}
