using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public StateMachine StateMachine { get; protected set; } = null;

    protected virtual void Awake()
    {
        StateMachine = new PlayerStateMachine();
    }

    protected virtual void Update()
    {
        if (StateMachine.currentState == null) return;
        StateMachine.currentState.StateUpdate();
        StateMachine.currentState.TransitionCheck();
    }

    protected virtual void FixedUpdate()
    {
        if (StateMachine.currentState == null) return;
        StateMachine.currentState.PhysicsUpdate();
    }
}
