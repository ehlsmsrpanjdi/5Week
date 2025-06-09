using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/ItemData")]
public class ItemDataScript : ScriptableObject
{
    public int id;
    public string name;
    public int Row;
    public int Col;
    public GameObject UIObject;
}