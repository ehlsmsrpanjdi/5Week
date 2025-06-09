using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary // ¿¢¼¿¾²±â ±ÍÂú¾Æ jsonµµ ±ÍÂú¾Æ
{
    static ItemDictionary instance;
    public static ItemDictionary Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ItemDictionary();
                instance.Init();
            }
            return instance;
        }
    }

    Dictionary<int, ItemDataScript> itemdictionary = new Dictionary<int, ItemDataScript>();

    public void Init()
    {
        itemdictionary.Add(1, Resources.Load<ItemDataScript>("ItemData/Item_1"));
    }

    public ItemDataScript GetItemData(int id)
    {
        if (itemdictionary.ContainsKey(id))
        {
            return itemdictionary[id];
        }
        else
        {
            Debug.LogError(id + "is noData");
            return null;
        }
    }
}

[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/ItemData")]
public class ItemDataScript : ScriptableObject
{
    public int id;
    public string name;
    public GameObject UIObject;
}