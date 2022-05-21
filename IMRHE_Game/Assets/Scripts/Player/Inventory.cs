using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public bool InventoryOpen=true;
    public GameObject inventory;
    private Pause pause;
    void Start()
    {
        inventory.SetActive(true);
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

    public void ActivateInventory()
    {
        InventoryOpen = !InventoryOpen;
    }
}
