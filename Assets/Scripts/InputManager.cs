using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;
    [SerializeField]
    private KeyButton up, down, left, right;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Destroy(gameObject);
    }
}
