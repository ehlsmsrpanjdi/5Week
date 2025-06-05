using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    const string LeftMouseButton = "LeftMouseButton";
    PlayerInput playerInput;

    InputAction LeftMouseButtonAction;
    private void Reset()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();

        if (playerInput == null)
        {
            playerInput = gameObject.AddComponent<PlayerInput>();
        }
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        LeftMouseButtonAction = playerInput.actions[LeftMouseButton];
    }

}
