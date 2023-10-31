
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput inputActions;
    public event Action<InputActionMap> actionMapChange;

    private void Awake()
    {
        inputActions = new PlayerInput();
    }

    void Start()
    {
        ToggleActionMap(inputActions.Wheel);
    }

    public void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
        {
            return;
        }

        inputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
}
