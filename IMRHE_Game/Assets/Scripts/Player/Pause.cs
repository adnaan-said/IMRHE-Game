using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool PauseEnabled;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
        PauseEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PauseEnabled = !PauseEnabled;
        PauseMenu.SetActive(PauseEnabled);
    }
}
