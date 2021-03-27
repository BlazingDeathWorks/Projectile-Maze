using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyButton
{
    [SerializeField]
    private KeyCode keyCode;
    public KeyCode KeyCode {set => keyCode = value;}
    public delegate void KeyCodeEvent();
    public event KeyCodeEvent OnKeyPress = null;

    private bool IsPressed
    {
        get
        {
            return IsPressed;
        }
        set
        {
            Input.GetKeyDown(keyCode);
        }
    }

    public void TriggerOnKeyPress()
    {
        if (IsPressed)
        {
            OnKeyPress?.Invoke();
        }
    }
}
