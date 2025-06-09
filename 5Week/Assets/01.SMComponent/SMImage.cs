using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SMImage : Image, IHandlerUI, IPointerUpHandler, IPointerDownHandler
{
    ESMHandler handler;

    ESMHandler IHandlerUI.Handler => handler;

    public void OnMouseButtonOff()
    {
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
    }

    public void OnMouseButtonOn()
    {
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
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
}
