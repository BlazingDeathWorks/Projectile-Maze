using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    //Change this if there is a base class for PlayerState
    public PlayerState currentState { get; protected set; } = null;

    public abstract void ChangeState(PlayerState newState);
}
