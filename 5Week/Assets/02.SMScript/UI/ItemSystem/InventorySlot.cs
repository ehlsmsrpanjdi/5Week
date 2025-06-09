using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public int Row;
    public int Column;

    bool isInit = false;
    public void Init(int _gridWidth)
    {
        if ((true == isInit))
        {
            return;
        }
        isInit = true;
        int index = transform.GetSiblingIndex(); // �θ� �ȿ��� �� ��° �ڽ�����
        Row = index / _gridWidth;
        Column = index % _gridWidth;
    }
}
