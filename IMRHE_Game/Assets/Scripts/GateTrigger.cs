using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private Animator myGateLeft = null;
    [SerializeField] private Animator myGateRight = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                myGateLeft.Play("OpenGateLeft", 0, 0.0f);
                myGateRight.Play("OpenGateRight", 0, 0.0f);
                gameObject.SetActive(false);
            }
            Debug.Log("HIT");
        }
            
        
    }
}
