using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class PlayerEntity : Entity
{
    public Animator Animator { get; private set; } = null;
    public Transform MyTransform { get; private set; } = null;

    protected override void Awake()
    {
        base.Awake();
        Animator = GetComponent<Animator>();
        MyTransform = transform;
    }
}
