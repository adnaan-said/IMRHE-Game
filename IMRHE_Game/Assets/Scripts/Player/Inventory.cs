using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    private bool InventoryOpen;
    public GameObject inventory;
    Pause pause;
    void Start()
    {
        pause = GetComponent<Pause>();
        InventoryOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pause.PauseMenu.activeSelf)
            if (Input.GetKeyDown(KeyCode.I))
                InventoryOpen = !InventoryOpen;
        inventory.SetActive(InventoryOpen);
    }
}
