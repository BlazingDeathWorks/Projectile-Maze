using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected float entitySpeed = 1f;
    [SerializeField]
    protected LayerMask targetLayer;
    public float EntitySpeed { get => entitySpeed; }
    public Animator Animator { get; private set; } = null;
    public Transform MyTransform { get; private set; } = null;
    public Rigidbody2D rb { get; private set; } = null;
    public LayerMask TargetLayer { get; private set; }
    public StateMachine StateMachine { get; protected set; } = null;

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        MyTransform = transform;
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        StateMachine.currentState.StateUpdate();
        StateMachine.currentState.TransitionCheck();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }
}