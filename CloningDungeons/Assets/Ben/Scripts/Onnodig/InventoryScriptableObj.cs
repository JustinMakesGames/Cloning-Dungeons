using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items")]
public class InventoryScriptableObj : ScriptableObject
{
    public string itemName;
    public int id;

    public GameObject itemPrefab;
    public Sprite itemSprite;
    public LayerMask layerMask;
}
