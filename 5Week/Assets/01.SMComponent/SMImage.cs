using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SMImage : Image, IHandlerUI, IPointerUpHandler, IPointerClickHandler
{
    ESMHandler handler;

    ESMHandler IHandlerUI.Handler => handler;

    public void OnMouseButtonUp()
    {
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
    }

    public void OnMouseButtonOn()
    {
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnMouseButtonOn();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseOnClicked(eventData.position);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnMouseButtonUp();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseUnClicked(eventData.position);
        }
    }

}
