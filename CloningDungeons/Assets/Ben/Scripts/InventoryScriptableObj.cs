using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "InvetoryScriptableObj")]
public class InventoryScriptableObj : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;
    public int id;
    public Sprite itemSprite;

}
