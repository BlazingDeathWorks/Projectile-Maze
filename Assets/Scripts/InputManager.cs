using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyButton up, down, left, right;
    public static InputManager instance = null;
    private KeyButton[] keyButtons;

    #region Singleton
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
    #endregion

    #region InitializeKeyButtons
    private void InitializeKeyButtons()
    {
        keyButtons = new KeyButton[] { up, down, left, right };
        up.KeyButtonsDisabled = new KeyButton[] { down, left, right };
        down.KeyButtonsDisabled = new KeyButton[] { up, left, right };
        left.KeyButtonsDisabled = new KeyButton[] { right, up, down };
        right.KeyButtonsDisabled = new KeyButton[] { left, up, down };
    }
    #endregion

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
