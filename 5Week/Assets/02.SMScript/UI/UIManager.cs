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
    [SerializeField] StatusViewer statusViewer;
    private void Reset()
    {
        inventoryViewer = FindObjectOfType<InventoryViewer>();
        statusViewer = FindObjectOfType<StatusViewer>();
    }

    #region Inventory

    public void InventoryOnOff()
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.gameObject.SetActive(!inventoryViewer.gameObject.activeSelf);
        }
    }

    public Slot GetSlot()
    {
        return Slot.GetSlot();
    }

    public void SetSlot(SMImage _Image)
    {
        Slot slot = _Image.GetComponent<Slot>();
        if (slot == null)
        {
            return;
        }
        Slot.SetSlot(slot);
    }

    public void UnSetSlot(SMImage _Image)
    {
        Slot slot = _Image.GetComponent<Slot>();
        if (slot == GetSlot())
        {
            slot = null;
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

    #endregion

    #region StatusInventory

    public int GetStatusInventoryCount()
    {
        return statusViewer.GetStatusInventoryCount();
    }

    public void StatusOnOff()
    {
        if (statusViewer != null)
        {
            statusViewer.gameObject.SetActive(!statusViewer.gameObject.activeSelf);
        }
    }

    public void AddItemToStatusInventory(int _Index, int _ItemKeyCode)
    {
        statusViewer.AddItem(_Index, _ItemKeyCode);
    }

    #endregion
}
