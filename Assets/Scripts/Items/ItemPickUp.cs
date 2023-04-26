using System;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item Item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + Item.Name);
        bool wasPickedUp = Inventory.Instance.Add(Item);
        if(wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
