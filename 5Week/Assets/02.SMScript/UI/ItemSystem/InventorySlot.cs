using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : Slot
{
    public int Row;
    public int Column;

    bool isInit = false;

    public override bool SlotFunction(int Key)
    {
        return Player.Instance.playerInventory.AddItem(Row, Column, Key);
    }

    public void Init(int _gridWidth)
    {
        if ((true == isInit))
        {
            return;
        }
        isInit = true;
        int index = transform.GetSiblingIndex(); // 부모 안에서 몇 번째 자식인지
        Row = index / _gridWidth;
        Column = index % _gridWidth;
    }
}
