using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary // �������� ������ json�� ������
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
        itemdictionary.Add(2, Resources.Load<ItemDataScript>("ItemData/Item_2"));
        itemdictionary.Add(3, Resources.Load<ItemDataScript>("ItemData/Item_3"));
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