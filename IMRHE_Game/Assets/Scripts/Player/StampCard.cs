using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCard : MonoBehaviour
{
    private IDictionary<string, int> StallScore = new Dictionary<string, int>();
    public bool stampCardOpen;
    Pause pause;
    // Start is called before the first frame update
    void Start()
    {
        stampCardOpen = false;
        pause = GetComponent<Pause>();

        StallScore.Add("Clown Shooting", 0);
        StallScore.Add("Axe Throwing", 0);
        StallScore.Add("Fishing", 0);
    }

    private void Update()
    {
        if(pause.PauseMenu.activeSelf)
            if (Input.GetKeyDown(KeyCode.S))
                stampCardOpen = !stampCardOpen;
    }

    bool logNewScore(string Game,int score)
    {
        if (StallScore.ContainsKey(Game))
        {
            StallScore[Game] = score;
            return true;
        }
        return false;                   //Wrong Key
    }

    int checkScore(string Game)
    {
        if (StallScore.ContainsKey(Game))
        {
            return StallScore[Game];
        }
        else
            return -1;                  //Wrong Key
    }
}
