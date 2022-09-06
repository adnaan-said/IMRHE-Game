using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

   public void BackToMenu()
    {
        SceneManager.LoadScene("Start-Screen 1");
     
    }

    public void EnableMenu()
    {
        if (PauseMenu == true)
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
