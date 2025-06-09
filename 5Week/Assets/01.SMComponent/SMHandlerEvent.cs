using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class SMHandlerEvent
{
    public static void TryDispatcherMouseOff(Vector2 _MousePos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = _MousePos
        };

        List<RaycastResult> AllHandlerUI = new List<RaycastResult>();


        EventSystem.current.RaycastAll(pointerData, AllHandlerUI);
        AllHandlerUI.RemoveAt(0);

        foreach (RaycastResult handler in AllHandlerUI)
        {
            IHandlerUI handlerUI = handler.gameObject.GetComponent<IHandlerUI>();
            if (handlerUI != null)
            {
                handlerUI.OnMouseButtonOff();
                if (handlerUI.Handler == ESMHandler.Handled)
                {
                    return;
                }
            }
        }
    }

    public static void TryDispatcherMouseExit(Vector2 _MousePos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = _MousePos
        };

        List<RaycastResult> AllHandlerUI = new List<RaycastResult>();


        EventSystem.current.RaycastAll(pointerData, AllHandlerUI);
        AllHandlerUI.RemoveAt(0);


        foreach (RaycastResult handler in AllHandlerUI)
        {
            IHandlerUI handlerUI = handler.gameObject.GetComponent<IHandlerUI>();
            if (handlerUI != null)
            {
                handlerUI.OnMouseExit();
                if (handlerUI.Handler == ESMHandler.Handled)
                {
                    return;
                }
            }
        }
    }

    public static void TryDispatcherMouseOn(Vector2 _MousePos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = _MousePos
        };

        List<RaycastResult> AllHandlerUI = new List<RaycastResult>();


        EventSystem.current.RaycastAll(pointerData, AllHandlerUI);
        AllHandlerUI.RemoveAt(0);


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

    public static void TryDispatcherMouseEnter(Vector2 _MousePos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = _MousePos
        };

        List<RaycastResult> AllHandlerUI = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerData, AllHandlerUI);
        AllHandlerUI.RemoveAt(0);

        foreach (RaycastResult handler in AllHandlerUI)
        {
            IHandlerUI handlerUI = handler.gameObject.GetComponent<IHandlerUI>();
            if (handlerUI != null)
            {
                handlerUI.OnMouseEnter();
                if (handlerUI.Handler == ESMHandler.Handled)
                {
                    return;
                }
            }
        }
    }

}
