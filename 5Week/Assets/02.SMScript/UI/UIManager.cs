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

    private void Reset()
    {
        inventoryViewer = FindObjectOfType<InventoryViewer>();
        if (inventoryViewer == null)
        {
            Debug.LogError("InventoryViewer component not found in children of UIManager.");
        }
    }

    public int GetInventorySlotCount()
    {
        return inventoryViewer.GetInventorySlotCount();
    }

    public void AddItemToInventory(int Row, int Col, ItemInfo _info)
    {
        if (inventoryViewer != null)
        {
            inventoryViewer.AddItem(Row, Col, _info.Key);
        }
        else
        {
            Debug.LogError("InventoryViewer is not assigned or found.");
        }
    }

}
