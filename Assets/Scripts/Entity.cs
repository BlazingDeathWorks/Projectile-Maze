using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected float entitySpeed = 1f;
    public float EntitySpeed { get => entitySpeed; }
    public Animator Animator { get; protected set; } = null;
    public Transform MyTransform { get; protected set; } = null;
    public Rigidbody2D rb { get; protected set; } = null;
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
