using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    Dictionary<(int,int), ItemInfo> itemSlots = new Dictionary<(int, int), ItemInfo>();
    Dictionary<(int, int), bool> existItemSlots = new Dictionary<(int, int), bool>();

    bool isInit = false;

    public void Init()
    {
        if(true == isInit)
        {
            return;
        }
        isInit = true;

        int InventoryCount = UIManager.Instance.GetInventorySlotCount();
        int RowSize = InventoryViewer.InventoryRowSize;
        int j = 0;

        for(int Row = 0; Row < RowSize; ++Row)
        {
            for(int Col = 0; Col < RowSize; ++Col)
            {
                existItemSlots.Add((Row, Col), false);
            }
        }
    }

    public void AddItem(ItemInfo _item)
    {
        foreach(KeyValuePair<(int, int), bool> slot in existItemSlots)
        {
            if (slot.Value == false)
            {
                existItemSlots[slot.Key] = true;
                itemSlots[slot.Key] = _item;
                UIManager.Instance.AddItemToInventory(slot.Key.Item1 , slot.Key.Item2, _item);
                return;
            }
        }
    }

    public void AddItem(int x, int y, ItemInfo _item)
    {
        itemSlots[(x, y)] = _item;
        existItemSlots[(x,y)] = true;
        UIManager.Instance.AddItemToInventory(x, y, _item);
    }
}
