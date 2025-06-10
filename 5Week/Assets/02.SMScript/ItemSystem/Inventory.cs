using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Inventory
{
    Dictionary<(int, int), int> itemSlots = new Dictionary<(int, int), int>();
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

    public void AddItem(int _itemKeyCode)
    {
        ItemDataScript dataScript = ItemDictionary.Instance.GetItemData(_itemKeyCode);

        if (dataScript == null)
        {
            return;
        }

        foreach (KeyValuePair<(int, int), bool> slot in existItemSlots)
        {
            if (slot.Value == false)
            {
                if (SearchSlot(slot.Key, dataScript) == false)
                {
                    continue;
                }

                existItemSlots[slot.Key] = true;
                itemSlots[slot.Key] = _itemKeyCode;
                UIManager.Instance.AddItemToInventory(slot.Key.Item1, slot.Key.Item2, _itemKeyCode);
                return;
            }
        }
    }


    public bool AddItem(int Row, int Col, int _itemKeyCode)
    {
        ItemDataScript dataScript = ItemDictionary.Instance.GetItemData(_itemKeyCode);

        if (dataScript == null)
        {
            return false;
        }

        if (false == existItemSlots[(Row, Col)])
        {
            if (SearchSlot((Row, Col), dataScript) == false)
            {
                return false;
            }

            itemSlots[(Row, Col)] = _itemKeyCode;
            existItemSlots[(Row, Col)] = true;
            UIManager.Instance.AddItemToInventory(Row, Col, _itemKeyCode);
            return true;
        }
        return false;
    }

    public void PopItem(int Row, int Col, int _itemKeyCode)
    {
        ItemDataScript dataScript = ItemDictionary.Instance.GetItemData(_itemKeyCode);

        if (dataScript == null)
        {
            return;
        }
        (int,int) end = (Row + dataScript.Row, Col + dataScript.Col);

        SearchBoolSlot((Row, Col), end, false);
    }


    void SearchBoolSlot((int, int) _start, (int, int) _end, bool _check)
    {
        for (int row = _start.Item1; row < _end.Item1; ++row)
        {
            for (int col = _start.Item2; col < _end.Item2; ++col)
            {
                existItemSlots[(row, col)] = _check;
            }
        }
    }

    bool SearchSlot((int, int) _slot, ItemDataScript _dataScript)
    {
        int Row = _dataScript.Row;
        int Col = _dataScript.Col;

        int MaxRow = Row + _slot.Item1;
        int MaxCol = Col + _slot.Item2;

        if (MaxRow - 1>= InventoryViewer.InventoryRowSize || MaxCol - 1 >= InventoryViewer.InventoryRowSize)
        {
            return false;
        }

        for (int row = _slot.Item1; row < MaxRow; ++row)
        {
            for (int col = _slot.Item2; col < MaxCol; ++col)
            {
                if (true == existItemSlots[(row, col)])
                {
                    return false;
                }
            }
        }

        SearchBoolSlot(_slot, (MaxRow, MaxCol), true);

        return true;
    }
}
