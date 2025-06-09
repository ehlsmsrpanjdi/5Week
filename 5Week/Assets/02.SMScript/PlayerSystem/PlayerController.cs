using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] PlayerInput playerInput;

    InputAction interactionInput;

    [SerializeField] Player player;

    const string InteractionActionName = "Interaction";

    private void Reset()
    {
        player = GetComponent<Player>();

        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            playerInput = gameObject.AddComponent<PlayerInput>();
        }

    }
    private void Awake()
    {
        interactionInput = playerInput.actions[InteractionActionName];
    }
}
