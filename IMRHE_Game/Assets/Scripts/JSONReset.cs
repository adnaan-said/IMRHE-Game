using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReset : MonoBehaviour
{
    public StampCard stampCard;

    public void RefreshGame()
    {
        stampCard.Initialise();
        PlayerPrefs.DeleteAll();
    }
}
