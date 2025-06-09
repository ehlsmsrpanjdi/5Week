using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryViewer : MonoBehaviour
{
    Dictionary<(int, int), InventorySlot> itemSlots = new Dictionary<(int, int), InventorySlot>();

    InventorySlot selectedSlot;
    int itemKey;


    [SerializeField] GridLayoutGroup gridLayoutGroup;

    public const int InventoryRowSize = 6;

    private void Reset()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void Awake()
    {
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        foreach (var slot in slots)
        {
            slot.Init(InventoryRowSize);

            itemSlots.Add((slot.Row, slot.Column), slot);
        }
    }

    private void Start()
    {
        gridLayoutGroup.enabled = false;
        Destroy(gridLayoutGroup);
    }

    public InventorySlot GetSlot()
    {
        return selectedSlot;
    }

    public void SetItemKey(int _ItemKey)
    {
        itemKey = _ItemKey;
    }

    public void UnSetItemKey()
    {
        itemKey = -1;
    }

    public void SetSlot(SMImage _Image)
    {
        selectedSlot = _Image.GetComponent<InventorySlot>();
    }

    public void UnSetSlot(SMImage _Image)
    {
        if(selectedSlot == null)
        {
            selectedSlot = _Image.GetComponent<InventorySlot>();
        }
        else if(selectedSlot == _Image.GetComponent<InventorySlot>())
        {
            selectedSlot = null;
        }
    }
    public int GetInventorySlotCount()
    {
        return itemSlots.Count;
    }

    public void AddItem(int Row, int Col, int _ItemKey)
    {
        ItemDataScript data = ItemDictionary.Instance.GetItemData(_ItemKey);
        GameObject obj = Instantiate(data.UIObject, this.transform);
        obj.GetComponent<SMSlotImage>().itemKeyValue = _ItemKey;
        obj.transform.position = itemSlots[(Row, Col)].transform.position;
    }
}
