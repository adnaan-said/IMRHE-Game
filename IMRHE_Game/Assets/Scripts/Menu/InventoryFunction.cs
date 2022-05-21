using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFunction : MonoBehaviour
{
    public GameObject player=null;
    private Inventory Inv;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(player.tag);
        if (player != null)
            Inv = player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventory()
    {
        Inv.ActivateInventory();
    }
}
