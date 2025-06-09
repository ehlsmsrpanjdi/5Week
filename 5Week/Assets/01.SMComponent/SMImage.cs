using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SMImage : Image, IHandlerUI, IPointerUpHandler, IPointerDownHandler
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

    public void OnMouseButtonOff()
    {
        isSelected = false;
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
    }

    public void OnMouseButtonOn()
    {
        isSelected = true;
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
