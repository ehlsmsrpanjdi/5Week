using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ESMHandler
{
    Handled = 0,
    UnHandled = 1,
}

public interface IHandlerUI
{
    public ESMHandler Handler { get; }

    //void Initialize();

    void OnMouseEnter();
    void OnMouseExit();
    void OnMouseButtonOff();
    void OnMouseButtonOn();

    //void UpdateState();
    //void ResetState();
}
