using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clown : MonoBehaviour
{
    public bool isActive;
    public int pointValue;
    public Clown_Selector main_selector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Functions
    public int getPoints()
    {
        if (isActive)
        {
            return pointValue;
        }
        else
            return -pointValue/2;
    }

    public void setPoints(int points)
    {
        pointValue = points;
    }

    public void setIsActive(bool state)
    {
        isActive = state; 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (isActive)
            {
                main_selector.disableClown(this.gameObject);
                main_selector.activateClown();
            }
            Destroy(other.gameObject);
            main_selector.AddPoints(getPoints());
        }
    }
}
