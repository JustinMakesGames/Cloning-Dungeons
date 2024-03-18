using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPhysical : MonoBehaviour, iInteractable
{
    public InventoryScriptableObj item;
    public void interactable()
    {
        if (InventorySlot._instance.item == null)
        {
            InventorySlot._instance.item = item;
        } 
    }
}   
