using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector3 GetInputVector()
    {
        Vector3 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>();
        

        return inputVector = inputVector.normalized;
    }
}
