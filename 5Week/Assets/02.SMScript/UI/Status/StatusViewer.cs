using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusViewer : MonoBehaviour
{
    [SerializeField] List<SMEquipImage> equipImages;
    [SerializeField] TextMeshProUGUI THP;
    [SerializeField] TextMeshProUGUI TMP;

    public Action OnStatusChange;

    private void Reset()
    {
        equipImages = new List<SMEquipImage>();
        SMEquipImage[] images = GetComponentsInChildren<SMEquipImage>();
        for(int index = 0; index < images.Length; index++) {
            SMEquipImage equipImage = images[index];
            StatusSlot slot = equipImage.gameObject.GetComponent<StatusSlot>();
            slot.Init(index);
            equipImages.Add(equipImage);
        }

        THP = transform.Find("Text_HP").GetComponent<TextMeshProUGUI>();
        TMP = transform.Find("Text_MP").GetComponent<TextMeshProUGUI>();
    }

    void Awake()
    {
        OnStatusChange += () =>
                {
                    THP.text = Player.Instance.status.Hp.ToString();
                    TMP.text = Player.Instance.status.Mp.ToString();
                };
    }

    private void Start()
    {
        OnStatusChange.Invoke();
    }

    public void AddItem(int _Index, int _ItemKey)
    {
        ItemDataScript data = ItemDictionary.Instance.GetItemData(_ItemKey);
        GameObject obj = Instantiate(data.UIObject, this.transform);
        obj.transform.position = equipImages[_Index].transform.position;
        ItemSlot itemSlot = obj.GetComponent<ItemSlot>();
        itemSlot.Position = (-1, _Index);
        itemSlot.ItemKey = _ItemKey;
        itemSlot.slotType = ESlotType.Status;
    }

    public int GetStatusInventoryCount()
    {
        return equipImages.Count;
    }
}
