using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory playerInventory;
    public StatusInventory playerStatusInventory;
    public Status status;

    static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (playerInventory == null)
        {
            playerInventory = new Inventory();
        }
    }

    private void Start()
    {
        playerInventory.Init();
    }
}
