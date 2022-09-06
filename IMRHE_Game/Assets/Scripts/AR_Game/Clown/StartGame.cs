using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject ClownSelector;
    public GameObject inGameScreen;
    public GameObject preGameScreen;
    public GameObject postGameScreen;
    public GameObject player;
    public Text pointText;

    public StampCard stampCard;

    public bool isInactive = false;

    private void Start()
    {
        if (isInactive)
        {
           ClownSelector.GetComponent<Clown_Selector>().setGameState(false);
           preGameScreen.SetActive(true);
           inGameScreen.SetActive(false);
           postGameScreen.SetActive(false);
        }
    }

    public void startGame()
    {
        if(isInactive)
        {
            ClownSelector.GetComponent<Clown_Selector>().setGameState(true);
            preGameScreen.SetActive(false);
            inGameScreen.SetActive(true);
            postGameScreen.SetActive(false);
        }
        
    }

    public void endGame()
    {
        int cash = ClownSelector.GetComponent<Clown_Selector>().getCash();
        int point = ClownSelector.GetComponent<Clown_Selector>().getPoints();

        if (isInactive)
        {
            ClownSelector.GetComponent<Clown_Selector>().setGameState(false);
            preGameScreen.SetActive(false);
            inGameScreen.SetActive(false);
            postGameScreen.SetActive(true);
            pointText.text = "Your Final Score was " + point.ToString();

            player.GetComponent<Player>().debitCash(cash);

            if (ClownSelector.GetComponent<Clown_Selector>().GetDifficulty() == 2)
            {
                stampCard.markStamp(StampCard.Stamp.Stall.Clowns, StampCard.Stamp.Tier.Hard, point);
            }
            else if (ClownSelector.GetComponent<Clown_Selector>().GetDifficulty() == 1)
            {
                stampCard.markStamp(StampCard.Stamp.Stall.Clowns, StampCard.Stamp.Tier.Advanced, point);
            }
            else if (ClownSelector.GetComponent<Clown_Selector>().GetDifficulty() == 0)
            {
                Debug.Log(stampCard);
                stampCard.markStamp(StampCard.Stamp.Stall.Clowns, StampCard.Stamp.Tier.Basic, point);
            }
        }

        
    }
}
