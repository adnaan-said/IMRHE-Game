using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCardFunction : MonoBehaviour
{
    public GameObject player = null;
    private StampCard stampCard;
    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
            stampCard = player.GetComponent<StampCard>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleStampCard()
    {
        stampCard.toggleStampCard();
    }
}
