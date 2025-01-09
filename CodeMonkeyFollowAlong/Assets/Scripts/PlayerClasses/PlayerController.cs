using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; set; }
    

    public event EventHandler OnSelectedCounterChanged;
    public class OnSelectedCounterChangeEventArgs : EventArgs 
    {
        public ClearCounter selectedCounter;
    }


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private PlayerInput input;
    [SerializeField] private LayerMask countersLayerMask;

    private bool isWalking;
    private Vector3 lastInteractDir;
    private ClearCounter selectedCounter;

    private void Start()
    {
        input.OnInteractAction += Input_OnInteractAction;   
    }

    private void Input_OnInteractAction(object sender, System.EventArgs e)
    {
        if ((selectedCounter != null))
        {
            selectedCounter.Interact();
        }
        
    }

    private void Update()
    {
        MovePlayer();
        HandleInteractions();
    }
    private void HandleInteractions()
    {
        Vector3 moveDirection = input.GetInputVector();


        float interactDistance = 2f;

        if (moveDirection != Vector3.zero)
        {
            lastInteractDir = moveDirection;
        }
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                if(clearCounter != selectedCounter)
                {
                    SetSelectedCounter(clearCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }

        

    }
    private void MovePlayer()
    {
        Vector3 moveDirection = input.GetInputVector();

        float moveDistance = moveSpeed * Time.deltaTime;
        float PlayerRadius = .7f;
        float playerHieght = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHieght, PlayerRadius, moveDirection, moveDistance);

        if (!canMove)
        {
            //if player can't move forward
            Vector3 moveDirx = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHieght, PlayerRadius, moveDirx, moveDistance);
            if (canMove)
            {
                moveDirection = moveDirx;
            }
            else
            {

                Vector3 moveDirz = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHieght, PlayerRadius, moveDirz, moveDistance);

                if (canMove)
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
    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangeEventArgs
        {
            selectedCounter = selectedCounter
        });
    }
    public bool IsWalking()
    {
        return isWalking;
    }

}
