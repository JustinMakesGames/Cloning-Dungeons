using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public static InventorySlot _instance;
    public InventoryScriptableObj item;
    public RawImage itemSprite;

    public void Start()
    {
        if( _instance == null)
        {
            _instance = this;
        }
    }

    public void Update()
    {
        if (item != null)
        {
            itemSprite.gameObject.SetActive(true); 
            itemSprite.texture = item.itemSprite.texture;
        }
        else
        {
            itemSprite.gameObject.SetActive(false); 
            itemSprite.texture = null;
        }
    }   
}
