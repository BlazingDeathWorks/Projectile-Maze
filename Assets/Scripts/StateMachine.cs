using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    public State currentState { get; protected set; } = null;

    public abstract void ChangeState(State newState);
}
