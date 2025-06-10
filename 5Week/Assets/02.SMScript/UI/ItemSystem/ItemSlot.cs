using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESlotType
{
    None,
    Inven,
    Status,
}

public class ItemSlot : Slot
{
    public (int,int) Position = (-1,-1);
    public int ItemKey = -1;
    public ESlotType slotType = ESlotType.None;
}
