using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private PlayerInput input;

    private bool isWalking;
    private void Update()
    {
        
        Vector3 moveDirection = input.GetInputVector();

        float moveDistance = moveSpeed * Time.deltaTime;
        float PlayerRadius = .7f;
        float playerHieght = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHieght, PlayerRadius, moveDirection, moveDistance);

        if(!canMove)
        {
            //if player can't move forward
            Vector3 moveDirx = new Vector3(moveDirection.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHieght, PlayerRadius, moveDirx, moveDistance);
            if(canMove)
            {
                moveDirection = moveDirx;
            }
            else
            {

                Vector3 moveDirz = new Vector3(0,0,    moveDirection.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHieght, PlayerRadius, moveDirz, moveDistance);

                if(canMove)
                {
                    moveDirection = moveDirz;
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        }
       

        isWalking = moveDirection != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    private void movePlayer()
    {

    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
