using UnityEngine;
using UnityEngine.InputSystem;

public class SMSlotImage : SMImage
{
    bool isSelected = false;
    ItemSlot itemSlot;

    protected override void Awake()
    {
        itemSlot = GetComponent<ItemSlot>();  // 깜빡하고 리셋을 미리 안함 ㄲㅂ
    }
    private void Update()
    {
        if (true == isSelected)
        {
            Vector2 Pos = Mouse.current.position.ReadValue();

            this.transform.position = Pos;
        }
    }


    public override void OnMouseEnter()
    {
        currentcolor = color;
        color = Color.yellow;
    }
    public override void OnMouseExit()
    {
        color = currentcolor;
    }

    private Vector2 currentScale;

    public override void OnMouseButtonOff()
    {
        gameObject.transform.localScale = currentScale;
        isSelected = false;
        raycastTarget = true;
        Slot slot = UIManager.Instance.GetSlot();
        if (true == slot.SlotFunction(itemSlot.ItemKey))
        {
            Destroy(this.gameObject);
        }
        else
        {
            switch (itemSlot.slotType)
            {
                case ESlotType.None:
                    break;
                case ESlotType.Inven:
                    Player.Instance.playerInventory.AddItem(itemSlot.Position.Item1, itemSlot.Position.Item2, itemSlot.ItemKey);
                    break;
                case ESlotType.Status:
                    Player.Instance.playerStatusInventory.AddItem(itemSlot.Position.Item2, itemSlot.ItemKey);
                    break;
                default:
                    break;
            }
            Destroy(this.gameObject);
        }
    }

    public override void OnMouseButtonOn()
    {
        currentScale = gameObject.transform.localScale;
        gameObject.transform.localScale = currentScale * 0.3f;
        isSelected = true;
        raycastTarget = false;

        switch (itemSlot.slotType)
        {
            case ESlotType.None:
                break;
            case ESlotType.Inven:
                Player.Instance.playerInventory.PopItem(itemSlot.Position.Item1, itemSlot.Position.Item2, itemSlot.ItemKey);
                break;
            case ESlotType.Status:
                Player.Instance.playerStatusInventory.PopItem(itemSlot.Position.Item2);
                break;
            default:
                break;
        }
    }
}