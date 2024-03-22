using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public static InventorySlot _instance;
    public InteractScript itemSlot;
    public InventoryScriptableObj item;

    public RawImage itemImage;
    public Sprite itemSprite;

    public void Start()
    {
        if( _instance == null)
        {
            _instance = this;
        }
        itemSlot = FindObjectOfType<InteractScript>();
    }

    public void Update()
    {
        KeepValues();
        item = itemSlot.item;
        if (item != null)
        {
            itemImage.gameObject.SetActive(true); 
            itemImage.texture = item.itemSprite.texture;
        }
        else
        {
            itemImage.gameObject.SetActive(false); 
            itemImage.texture = null;
        }
    }
    private void KeepValues()
    {
        if (item != null)
        {
            itemSprite = item.itemSprite;
        }
        else
        {
            itemSprite = null;
        }
    }
}
