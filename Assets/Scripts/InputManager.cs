using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyButton up, down, left, right;
    public static InputManager instance = null;
    private KeyButton[] keyButtons;

    private void Singleton()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    private void InitializeKeyButtons()
    {
        keyButtons = new KeyButton[] { up, down, left, right };
    }

    private void Awake()
    {
        Singleton();
        InitializeKeyButtons();
    }

    private void Update()
    {
        OnKeyPressedForeach();
    }

    private void OnKeyPressedForeach()
    {
        if (keyButtons == null) return;
        foreach (KeyButton keyButton in keyButtons)
        {
            keyButton.TriggerOnKeyPress();
        }
    }
}
