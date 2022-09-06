using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier_Select : MonoBehaviour
{
    public GameObject ClownSelector;
    public int points, difficulty;
    public void SetOptions()
    {
        ClownSelector.GetComponent<Clown_Selector>().SetDifficulty(difficulty);
    }
}
