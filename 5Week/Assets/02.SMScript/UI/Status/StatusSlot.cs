using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSlot : Slot
{
    [SerializeField] int Index;

    public void Init(int _index)
    {
        Index = _index;
    }

    public override bool SlotFunction(int Key)
    {
        return Player.Instance.playerStatusInventory.AddItem(Index, Key);
        //return Player.Instance.playerInventory.AddItem(Row, Column, Key);
    }
}
