using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SMSlotImage : Image, IHandlerUI, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    ESMHandler handler;

    ESMHandler IHandlerUI.Handler => handler;

    bool isSelected = false;

    private void Update()
    {
        if (true == isSelected)
        {
            Vector2 Pos = Mouse.current.position.ReadValue();

            this.transform.position = Pos;
        }
    }

    private Color currentcolor;

    public void OnMouseEnter()
    {
        currentcolor = color;
        color = Color.yellow;
    }
    public void OnMouseExit()
    {
        color = currentcolor;
    }

    private Vector2 currentScale;
    public int itemKeyValue;
    public int Row;
    public int Col;

    public void OnMouseButtonOff()
    {
        gameObject.transform.localScale = currentScale;
        isSelected = false;
        raycastTarget = true;
        InventorySlot inventorySlot = UIManager.Instance.GetSlot();
        if (null != inventorySlot)
        {
            if(false == Player.Instance.playerInventory.AddItem(inventorySlot.Row, inventorySlot.Column, itemKeyValue))
            {
                Destroy(this.gameObject);
                Player.Instance.playerInventory.AddItem(Row, Col, itemKeyValue);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
            Player.Instance.playerInventory.AddItem(Row, Col, itemKeyValue);
        }
    }

    public void OnMouseButtonOn()
    {
        currentScale = gameObject.transform.localScale;
        gameObject.transform.localScale = currentScale * 0.3f;
        isSelected = true;
        raycastTarget = false;
        Player.Instance.playerInventory.PopItem(Row, Col, itemKeyValue);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnMouseButtonOff();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseOff(eventData.position);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseButtonOn();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseOn(eventData.position);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter();

        //if (handler == ESMHandler.UnHandled)
        //{
        //    SMHandlerEvent.TryDispatcherMouseEnter(eventData.position);
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit();

        //if (handler == ESMHandler.UnHandled)
        //{
        //    SMHandlerEvent.TryDispatcherMouseExit(eventData.position);
        //}
    }

}