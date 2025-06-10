using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusInventory
{
    public int Item_1;
    public int Item_2;
    public int Item_3;

    public void GetItem(int _Index, int _ItemKey)
    {
        switch (_Index)
        {
            case 0:
                Item_1 = _ItemKey;
                break;
            case 1:
                Item_2 = _ItemKey;
                break;
            case 2:
                Item_3 = _ItemKey;
                break;
        }
    }

}
