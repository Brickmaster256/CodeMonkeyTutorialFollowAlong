using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private void Update()
    {
        Vector3 inputVector = new Vector3(0, 0, 0);
        if(Input.GetKey(KeyCode.W))
        {
             inputVector.z = +1;
        }
        if(Input.GetKey(KeyCode.S))
        {
             inputVector.z = -1; 
        }
        if (Input.GetKey(KeyCode.D)) 
        {
             inputVector.x = +1;
        }
        if( Input.GetKey(KeyCode.A))
        {
              inputVector.x = -1;
        }

        inputVector = inputVector.normalized;
        Vector3 moveDirection = inputVector;
        transform.position += moveDirection * Time.deltaTime * moveSpeed;
    }
}
