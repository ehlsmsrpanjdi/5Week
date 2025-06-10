using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private static Slot SelectedSlot;

    public static Slot GetSlot()
    {
        return SelectedSlot;
    }

    public static void UnSetSlot()
    {
        SelectedSlot = null;
    }

    public static void SetSlot(Slot slot)
    {
        if(slot is ItemSlot)
        {
            return;
        }
        SelectedSlot = slot;
    }

    public virtual bool SlotFunction(int Key)
    {
        return false;
    }
}
