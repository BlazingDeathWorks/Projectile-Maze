using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlayerState : PlayerState
{
    public MovablePlayerState(Entity entity) : base(entity)
    {

    }

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

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void TransitionCheck()
    {
        base.TransitionCheck();
    }

    private void AddInputManagerEvents()
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
    }

    private void SubtractInputManagerEvents()
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
    }

    private void MoveHorizontally()
    {
        if (entity.rb == null)
        {
            return;
        }
        entity.StateMachine.ChangeState(new PlayerHorizontalMoveState(entity));
    }

    private void MoveVertically()
    {
        if (entity.rb == null)
        {
            return;
        }
        entity.StateMachine.ChangeState(new PlayerVerticalMoveState(entity));
    }
}
