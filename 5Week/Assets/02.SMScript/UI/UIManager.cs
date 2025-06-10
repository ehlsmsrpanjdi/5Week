using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("UIManager");
                    instance = obj.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    SMImage selectedImage;

    public void SelectImage(SMImage _image)
    {
        selectedImage = _image;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] InventoryViewer inventoryViewer;

    private void Reset()
    {
        inventoryViewer = FindObjectOfType<InventoryViewer>();
    }


    public void InventoryOnOff()
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.gameObject.SetActive(!inventoryViewer.gameObject.activeSelf);
        }
    }

    public InventorySlot GetSlot()
    {
        if (inventoryViewer != null)
        {
            return inventoryViewer.GetSlot();
        }
        return null;
    }

    public void SetItemKey(int _ItemKey)
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.SetItemKey(_ItemKey);
        }
    }

    public void UnSetItemKey()
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.UnSetItemKey();
        }
    }

    public void SetSlot(SMImage _Image)
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.SetSlot(_Image);
        }
    }

    public void UnSetSlot(SMImage _Image)
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.UnSetSlot(_Image);
        }
    }

    public int GetInventorySlotCount()
    {
        return inventoryViewer.GetInventorySlotCount();
    }

    public void AddItemToInventory(int Row, int Col, int _itemKeyCode)
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.AddItem(Row, Col, _itemKeyCode);
        }
    }

}
