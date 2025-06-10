using System.Collections.Generic;

public class StatusInventory
{
    public List<int> Items { get; private set; } = new List<int>();

    bool isInit = false;

    public void Init()
    {
        if (isInit == true)
        {
            return;
        }
        isInit = true;

        int StatusInventoryCount = UIManager.Instance.GetStatusInventoryCount();
        for (int i = 0; i < StatusInventoryCount; i++)
        {
            Items.Add(-1);
        }
    }

    public bool AddItem(int _Index, int _ItemKey)
    {
        if (Items[_Index] != -1)
        {
            return false; // 이미 아이템이 존재하는 경우
        }
        if (Items.Count > _Index)
        {
            Items[_Index] = _ItemKey;
            UIManager.Instance.AddItemToStatusInventory(_Index, _ItemKey);
            return true;
        }
        return false;
    }

    public void PopItem(int _Index)
    {
        Items[_Index] = -1;
    }

}
