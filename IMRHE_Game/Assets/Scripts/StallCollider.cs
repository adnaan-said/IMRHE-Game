using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallCollider : MonoBehaviour
{
    public GameObject Button;
    public string popUp;

    private void OnTriggerEnter(Collider other)
    {
        Button.SetActive(true);   
    }

    private void OnTriggerExit(Collider other)
    {
        Button.SetActive(false);
    }

    public void OpenPopUp()
    {
        PopUpManager pop = GameObject.FindGameObjectWithTag("PopUpTag").GetComponent<PopUpManager>();
        pop.PopUp(popUp);
    }
}
