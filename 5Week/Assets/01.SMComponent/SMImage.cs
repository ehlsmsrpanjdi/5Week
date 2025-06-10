using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SMImage : Image, IHandlerUI, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected ESMHandler handler;

    ESMHandler IHandlerUI.Handler => handler;

    protected Color currentcolor;


    public virtual void OnMouseEnter()
    {
        currentcolor = color;
        color = Color.yellow;
        UIManager.Instance.SetSlot(this);
        //DebugHelper.Log("SMImage OnMouseEnter", this);
    }

    public virtual void OnMouseExit()
    {
        color = currentcolor;
        UIManager.Instance.UnSetSlot(this);
        //DebugHelper.Log("SMImage OnMouseExit", this);
    }

    public virtual void OnMouseButtonOff()
    {
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
    }

    public virtual void OnMouseButtonOn()
    {
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        OnMouseButtonOff();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseOff(eventData.position);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnMouseButtonOn();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseOn(eventData.position);
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter();

        //if (handler == ESMHandler.UnHandled)
        //{
        //    SMHandlerEvent.TryDispatcherMouseEnter(eventData.position);
        //}
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit();

        //if (handler == ESMHandler.UnHandled)
        //{
        //    SMHandlerEvent.TryDispatcherMouseExit(eventData.position);
        //}
    }

}
