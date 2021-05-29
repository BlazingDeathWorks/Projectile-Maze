using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected float entitySpeed = 1f;
    [SerializeField]
    private LayerMask targetLayer;
    public float TimeBeforeNextDash { get; set; } = 0f;
    public float EntitySpeed { get => entitySpeed; }
    public Animator Animator { get; private set; } = null;
    public Transform MyTransform { get; private set; } = null;
    public Rigidbody2D Rb { get; private set; } = null;
    public Collider2D Collider { get; private set; } = null;
    public LayerMask TargetLayer { get => targetLayer;}
    public StateMachine StateMachine { get; protected set; } = null;

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        MyTransform = transform;
        Rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.StateUpdate();
        StateMachine.CurrentState.TransitionCheck();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StateMachine.CurrentState.CollisionEnter(collision);
    }
}