using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class KeyButton
{
    [SerializeField]
    private KeyCode keyCode;
    public KeyCode KeyCode {set => keyCode = value;}
    public delegate void KeyCodeEvent();
    public event KeyCodeEvent OnKeyPress = null;
    [field: NonSerialized]
    public KeyButton[] KeyButtonsDisabled { private get; set; } = null;

    public bool IsPressed()
    {
        return Input.GetKeyDown(keyCode) || Input.GetKey(keyCode);
    }

    private bool IsEnabled()
    {
        if (KeyButtonsDisabled == null) return true;
        foreach (KeyButton keyButton in KeyButtonsDisabled)
        {
            if (keyButton.IsPressed()) return false;
        }
        return true;
    }

    public void TriggerOnKeyPress()
    {
        if (IsPressed() && IsEnabled())
        {
            OnKeyPress?.Invoke();
        }
    }
}
