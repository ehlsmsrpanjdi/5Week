using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SMImage : Image, IHandlerUI, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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
        DebugHelper.Log("SMImage OnMouseEnter", this);
    }
    public void OnMouseExit()
    {
        color = currentcolor;
        DebugHelper.Log("SMImage OnMouseExit", this);
    }

    public void OnMouseButtonOff()
    {
        isSelected = false;
        raycastTarget = true;
        DebugHelper.Log("SMImage OnMouseButtonUp", this);
    }

    public void OnMouseButtonOn()
    {
        isSelected = true;
        raycastTarget = false;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseEnter(eventData.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit();

        if (handler == ESMHandler.UnHandled)
        {
            SMHandlerEvent.TryDispatcherMouseExit(eventData.position);
        }
    }

}
