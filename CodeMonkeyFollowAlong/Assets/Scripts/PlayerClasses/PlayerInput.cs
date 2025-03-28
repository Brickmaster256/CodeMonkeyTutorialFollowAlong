using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {     
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetInputVector()
    {
        Vector3 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>();
        

        return inputVector = inputVector.normalized;
    }
}
