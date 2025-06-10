using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SMEquipImage : Image, IHandlerUI, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    ESMHandler handler;

    ESMHandler IHandlerUI.Handler => handler;

    private Color currentcolor;

    public int Index;

    public void OnMouseEnter()
    {
        currentcolor = color;
        color = Color.yellow;
        //UIManager.Instance.SetSlot(this);
        //DebugHelper.Log("SMImage OnMouseEnter", this);
    }
    public void OnMouseExit()
    {
        color = currentcolor;
        //UIManager.Instance.UnSetSlot(this);
        //DebugHelper.Log("SMImage OnMouseExit", this);
    }

    public void OnMouseButtonOff()
    {

    }

    public void OnMouseButtonOn()
    {

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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit();
    }

}
