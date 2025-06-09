using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    const string LeftMouseButton = "LeftMouseButton";
    [SerializeField] PlayerInput playerInput;

    InputAction LeftMouseButtonAction;
    private void Reset()
    {
        playerInput = GetComponent<PlayerInput>();

        if (playerInput == null)
        {
            playerInput = gameObject.AddComponent<PlayerInput>();
        }
    }

    private void Awake()
    {
        LeftMouseButtonAction = playerInput.actions[LeftMouseButton];
    }


}
