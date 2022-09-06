using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clown_Selector : MonoBehaviour
{
    private int difficulty_level = 0;
    private bool game_Active = true;
    private int points=0;
    public int PointCoeff = 10;


    private float game_timer = 0;
    private float interval_time = 0;
    public float interval_time_Coefficient = 0;
    public float Total_gameTime = 100;
    private float game_countdown=0;

    public float step=5.0f;
    private int currentPosition;
    private int NextPosition;
    public List<ClownHandler> ClownList;

    public Text pointText;
    public Text timerText;
    public StampCard stampCard;
    public StartGame gameManager;

    public ProjectileShooter shooter;
    public int bulletCost = 0;
    public int pointValue = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        SetDifficulty(0);
        game_Active = false;
        currentPosition = 0;
        game_countdown = Total_gameTime;
        points = 0;
        NextPosition = Random.Range(0, 6);
        activateClown();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(game_timer);
        if (game_Active)
        {
            //Debug.Log(game_timer);
            game_timer += Time.deltaTime;
            game_countdown -= Time.deltaTime;
            timerText.text = game_countdown.ToString();
            if (game_countdown < 0)
            {
                game_Active = false;

                if (difficulty_level == 0) {
                    stampCard.markStamp(StampCard.Stamp.Stall.Clowns, StampCard.Stamp.Tier.Basic,points);
                }
                else if (difficulty_level == 1)
                {
                    stampCard.markStamp(StampCard.Stamp.Stall.Clowns, StampCard.Stamp.Tier.Advanced, points);
                }
                else
                {
                    stampCard.markStamp(StampCard.Stamp.Stall.Clowns, StampCard.Stamp.Tier.Hard, points);
                }
                gameManager.endGame();
            }

            if (game_timer > interval_time)
            {
                //Debug.Log("now");
                game_timer -= interval_time;
                disableClown(ClownList[currentPosition].Clown);
                activateClown();

            }
            
        }
        pointText.text = points.ToString();
    }


    public void SetDifficulty(int Difficulty)
    {
        difficulty_level = Difficulty;
        interval_time = ( 5 + interval_time_Coefficient) / (difficulty_level + 1);
        SetPoints(12 + (PointCoeff * Difficulty));
        
    }

    public int GetDifficulty()
    {
        return difficulty_level;
    }

    public void SetPoints(int Points)
    {
        for (int i = 0; i < ClownList.Count; i++)
        {
            ClownList[i].Clown.GetComponent<Clown>().setPoints(Points);
        }
    }
    public void setGameState(bool gameState)
    {
        game_Active = gameState;
    }

    public void AddPoints(int pointAdder)
    {
        points += pointAdder;
      if (points < 0)
       {
           points = 0;
        }
    }

    public void disableClown(GameObject ClownCheck)
    {

        for(int i =0; i<ClownList.Count;i++)
        {
            if (ClownCheck == ClownList[i].Clown)
            {
                ClownList[i].Selector.SetActive(false);
                //ClownList[i].Clown.SetActive(false);
                ClownList[i].Clown.GetComponent<Clown>().setIsActive(false);
            }
        }
    }

    public void activateClown()
    {
        
        ClownList[NextPosition].Selector.SetActive(true);
        //ClownList[NextPosition].Clown.SetActive(true);
        ClownList[NextPosition].Clown.GetComponent<Clown>().setIsActive(true);
        currentPosition = NextPosition;
        NextPosition = Random.Range(0, 6);
    }

    public int getCash()
    {
        Debug.Log("Money Calcualted");
        return (points * 2) - (shooter.getBulletUsed() * bulletCost) ;
        
    }

    public int getPoints()
    {
        return points;

    }

    [System.Serializable]
    public class ClownHandler{
        public string Name;
        public GameObject Clown;
        public GameObject Selector;
    }

    

}
