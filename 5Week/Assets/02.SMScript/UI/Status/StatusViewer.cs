using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusViewer : MonoBehaviour
{
    [SerializeField] List<SMEquipImage> equipImages;

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
