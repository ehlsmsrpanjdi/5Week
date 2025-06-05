using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class SMHandlerEvent
{
    public static void TryDispatcherMouseUnClicked(Vector2 _MousePos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = _MousePos
        };

        List<RaycastResult> AllHandlerUI = new List<RaycastResult>();


        EventSystem.current.RaycastAll(pointerData, AllHandlerUI);

        foreach (RaycastResult handler in AllHandlerUI)
        {
            IHandlerUI handlerUI = handler.gameObject.GetComponent<IHandlerUI>();
            if (handlerUI != null)
            {
                handlerUI.OnMouseButtonUp();
                if (handlerUI.Handler == ESMHandler.Handled)
                {
                    return;
                }
            }
        }
    }

    public static void TryDispatcherMouseOnClicked(Vector2 _MousePos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = _MousePos
        };

        List<RaycastResult> AllHandlerUI = new List<RaycastResult>();


        EventSystem.current.RaycastAll(pointerData, AllHandlerUI);

        foreach (RaycastResult handler in AllHandlerUI)
        {
            IHandlerUI handlerUI = handler.gameObject.GetComponent<IHandlerUI>();
            if (handlerUI != null)
            {
                handlerUI.OnMouseButtonOn();
                if (handlerUI.Handler == ESMHandler.Handled)
                {
                    return;
                }
            }
        }
    }
}
