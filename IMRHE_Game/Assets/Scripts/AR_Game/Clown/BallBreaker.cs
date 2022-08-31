using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBreaker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
