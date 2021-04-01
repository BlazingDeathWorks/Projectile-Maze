using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerStateMachine(PlayerState defaultState)
    {
        currentState = defaultState;
        currentState.Enter();
    }

    public override void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
