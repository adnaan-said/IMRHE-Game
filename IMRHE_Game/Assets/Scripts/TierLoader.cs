using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierLoader : MonoBehaviour
{
    public int Stall_Code;
    public StampCard SC;
    private int tier_number=0;
    public List<UI_elements> UIElements;

    private void Awake()
    {
        UIElements.ToArray()[2].Tier_Button.SetActive(false);
        UIElements.ToArray()[1].Tier_Button.SetActive(false);
        UIElements.ToArray()[0].Tier_Button.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Stall_Code == 0)
            tier_number = SC.getTierData(StampCard.Stamp.Stall.Clowns);
        else if (Stall_Code == 1)
            tier_number = SC.getTierData(StampCard.Stamp.Stall.Axe);
        else if (Stall_Code == 2)
            tier_number = SC.getTierData(StampCard.Stamp.Stall.Fishing);
        else
            Debug.Log("You Fudged yourself :/");
        Unlock();
    }

    void Unlock()
    {

        if (tier_number >= 2)
        {
            UnlockSpecific(2);
        }
        if (tier_number >= 1)
        {
            UnlockSpecific(1);
        }
        if (tier_number >= 0)
        {
            UnlockSpecific(0);
        }
    }

    void UnlockSpecific(int tier) {
        UIElements.ToArray()[tier].lock_UI.SetActive(false);
        UIElements.ToArray()[tier].Tier_Button.SetActive(true);
    }

    [System.Serializable]
    public class UI_elements
    {
        public GameObject lock_UI;
        public GameObject Tier_Button;
    }
}
