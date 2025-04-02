using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(PlayerController player)
    {
        
            //gives the player an object
         Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
         kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        
        
    }

    
}
