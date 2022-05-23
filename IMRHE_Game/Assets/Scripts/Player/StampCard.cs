using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StampCard : MonoBehaviour
{
    //private IDictionary<string, int> StallScore = new Dictionary<string, int>();

    SaveStampCard savedStampCard;
    public bool stampCardOpen=true;
    public GameObject stampCard;
    Pause pause;
    public List<StampUI> StampUIElements;

    public void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        stampCard.SetActive(true);
        stampCardOpen = false;
        pause = GetComponent<Pause>();

        savedStampCard = new SaveStampCard();
        savedStampCard.Load();

        Debug.LogFormat("Loaded StampCard {0}", JsonUtility.ToJson(savedStampCard));

        var stamp = savedStampCard.stamps.Find(q => q.stall == Stamp.Stall.Clowns);
        if (stamp == null)
            Debug.Log("here");

        markStamp(Stamp.Stall.Clowns,Stamp.Tier.Basic, 90);
        markStamp(Stamp.Stall.Axe, Stamp.Tier.Advanced, 92);
        markStamp(Stamp.Stall.Clowns, Stamp.Tier.Basic, 99);
        markStamp(Stamp.Stall.Clowns, Stamp.Tier.Basic, 70);

        Debug.LogFormat("Loaded StampCard {0}", JsonUtility.ToJson(savedStampCard));

    }

    private void Update()
    {
        stampCard.SetActive(stampCardOpen);

    }

    void UpdateStampCardUI()
    {
        savedStampCard = new SaveStampCard();
        savedStampCard.Load();
    }

    void markStamp(Stamp.Stall stall, Stamp.Tier tier, int Score)
    {
        var stamp = savedStampCard.stamps.Find(q => q.stall == stall&&q.tier==tier);
        if (stamp == null)
            addStamp(stall, tier, Score);
        else
        {
            if (Score<stamp.Score)
            {
                Debug.Log("Score is unbeaten");
            }
            else if (Score > 100)
            {
                Debug.LogError("ERR: Invalid Scoring");
            }
            else if (90 < Score)
            {
                stamp.color = Stamp.Color.Gold;
                stamp.stall = stall;
                stamp.Score = Score;
              
            }
            else if (50 < Score)
            {
                stamp.color = Stamp.Color.Black;
                stamp.stall = stall;
                stamp.Score = Score;
            }
            else
            {
                stamp.color = Stamp.Color.Red;
                stamp.stall = stall;
                stamp.Score = Score;
            }
        }
            
    }

    void addStamp(Stamp.Stall stall,Stamp.Tier tier,int Score)
    {
        Stamp item = new Stamp();
        bool isMarked = false;
        if (Score > 100)
        {
            Debug.LogError("ERR: Invalid Scoring");
        }
        else if (90 < Score)
        {
            item = new Stamp()
            {
                color = Stamp.Color.Gold,
                stall = stall,
                tier = tier,
                Score = Score
            };
            isMarked = true;
        }
        else if (50 < Score)
        {
            item = new Stamp()
            {
                color = Stamp.Color.Black,
                stall = stall,
                tier = tier,
                Score = Score
            };
            isMarked = true;
        }
        else
        {
            item = new Stamp()
            {
                color = Stamp.Color.Red,
                stall = stall,
                tier = tier,
                Score = Score
            };
            isMarked = true;
        }

        if (isMarked)
            savedStampCard.stamps.Add(item);

    }

    public void toggleStampCard()
    {
        this.stampCardOpen = !this.stampCardOpen;
    }

    public void toggleStampCard(bool toggle)
    {
        this.stampCardOpen = toggle;
    }

    [System.Serializable]
    public class Stamp
    {
        public enum Color { Red, Black, Gold };
        public enum Stall { Clowns, Axe, Fishing };

        public enum Tier { Basic, Advanced, Hard };

        //          StallScore.Add("Clown Shooting", 0);
        //          StallScore.Add("Axe Throwing", 0);
        //          StallScore.Add("Fishing", 0);

        public Color color;

        public Stall stall;

        public Tier tier;

        public int Score;
        
    }

    [System.Serializable]
    private class SaveStampCard
    {
        private string savePath { get { return Path.Combine(Application.persistentDataPath, "Json/StampCard.json"); } }
        // items currently in the inventory
        public List<Stamp> stamps;
        public SaveStampCard()
        {
            stamps = new List<Stamp>();
        }

        public void Save()
        {
            File.WriteAllText(savePath,JsonUtility.ToJson(this));
        }
        public void Load()
        {
            if (File.Exists(savePath))
                JsonUtility.FromJsonOverwrite(File.ReadAllText(savePath), this);
        }
    }

    [System.Serializable]
    public class StampUI
    {
        public string Name;
        public GameObject stall;
        public GameObject Score;
        public GameObject Tier;
        //public Sprite ColoredStamp;
        //Not Working

    }

}
