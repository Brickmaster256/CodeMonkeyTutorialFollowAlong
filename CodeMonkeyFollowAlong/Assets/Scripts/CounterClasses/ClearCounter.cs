using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    
    

    private KitchenObject kitchenObject;

    

    public void Interact(PlayerController player)
    {
        if (kitchenObject == null)
        {
            //Creates the object on the counter
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(this);
        }
        else
        {
            //Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
            
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
           return kitchenObject;
    }

    public  void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitcheObject()
    {
        return kitchenObject != null;
    }
}
