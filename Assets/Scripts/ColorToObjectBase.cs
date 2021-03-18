using System;
using UnityEngine;

[Serializable]
public class ColorToObjectBase
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private GameObject gameObject;

    public Color Color { get => color; }
    public GameObject GameObject { get => gameObject; }
}