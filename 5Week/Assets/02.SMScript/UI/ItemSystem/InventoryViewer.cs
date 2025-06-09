using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryViewer : MonoBehaviour
{
    Dictionary<(int, int), InventorySlot> itemSlots = new Dictionary<(int, int), InventorySlot>();

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

    public int GetInventorySlotCount()
    {
        return itemSlots.Count;
    }

    public void AddItem(int x, int y, int _ItemKey)
    {
        ItemDataScript data = ItemDictionary.Instance.GetItemData(_ItemKey);
        GameObject obj = Instantiate(data.UIObject, this.transform);

        obj.transform.position = itemSlots[(x, y)].transform.position;
    }
}
