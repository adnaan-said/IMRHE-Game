using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool PauseEnabled;
    public GameObject PauseMenu;
    private Locomotion locomotion;

    // Start is called before the first frame update
    void Start()
    {
        locomotion = GetComponent<Locomotion>();
        PauseEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseEnabled = !PauseEnabled;
            StopMotion();
        }
        PauseMenu.SetActive(PauseEnabled);
    }

    public bool checkPause()
    {
        return PauseEnabled;
    }

    public bool notPaused()
    {
        return !PauseEnabled;
    }

    public void StopMotion()
    {
        locomotion.pauseMoving();
    }
}
