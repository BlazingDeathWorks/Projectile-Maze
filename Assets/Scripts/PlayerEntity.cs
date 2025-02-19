using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class PlayerEntity : Entity
{
    private void Start()
    {
        StateMachine = new PlayerStateMachine(new PlayerIdleState(this));
    }

    protected override void Update()
    {
        if (StateMachine.CurrentState == null) return;
        base.Update();
    }

    protected override void FixedUpdate()
    {
        if (StateMachine.CurrentState == null) return;
        base.FixedUpdate();
    }
}
