using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    Dictionary<(int, int), ItemInfo> itemSlots = new Dictionary<(int, int), ItemInfo>();
    Dictionary<(int, int), bool> existItemSlots = new Dictionary<(int, int), bool>();

    bool isInit = false;

    public void Init()
    {
        if (true == isInit)
        {
            return;
        }
        isInit = true;

        int InventoryCount = UIManager.Instance.GetInventorySlotCount();
        int RowSize = InventoryViewer.InventoryRowSize;

        for (int Row = 0; Row < RowSize; ++Row)
        {
            for (int Col = 0; Col < RowSize; ++Col)
            {
                existItemSlots.Add((Row, Col), false);
            }
        }
    }

    public void AddItem(ItemInfo _item)
    {
        ItemDataScript dataScript = ItemDictionary.Instance.GetItemData(_item.Key);

        foreach (KeyValuePair<(int, int), bool> slot in existItemSlots)
        {
            if (slot.Value == false)
            {
                if(SearchSlot(slot.Key, dataScript) == false)
                {
                    continue;
                }

                existItemSlots[slot.Key] = true;
                itemSlots[slot.Key] = _item;
                UIManager.Instance.AddItemToInventory(slot.Key.Item1, slot.Key.Item2, _item);
                return;
            }
        }
    }


    public void AddItem(int Row, int Col, ItemInfo _item)
    {
        ItemDataScript dataScript = ItemDictionary.Instance.GetItemData(_item.Key);

        if (false == existItemSlots[(Row, Col)])
        {
            if (SearchSlot((Row, Col), dataScript) == false)
            {
                return;
            }

            itemSlots[(Row, Col)] = _item;
            existItemSlots[(Row, Col)] = true;
            UIManager.Instance.AddItemToInventory(Row, Col, _item);
        }
    }


    bool SearchSlot((int,int) _slot, ItemDataScript _dataScript)
    {
        int Row = _dataScript.Row;
        int Col = _dataScript.Col;

        int MaxRow = Row + _slot.Item2;
        int MaxCol = Col + _slot.Item1;

        if (MaxRow > InventoryViewer.InventoryRowSize || MaxCol > InventoryViewer.InventoryRowSize)
        {
            return false;
        }

        for (int row = _slot.Item2; row < Row; ++row)
        {
            for (int col = _slot.Item1; col < Col; ++col)
            {
                if (true == existItemSlots[(row, col)])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
