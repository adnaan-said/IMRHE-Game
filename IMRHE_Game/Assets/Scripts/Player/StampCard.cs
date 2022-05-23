using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

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

        markStamp(Stamp.Stall.Clowns, Stamp.Tier.Basic, 90);
        markStamp(Stamp.Stall.Axe, Stamp.Tier.Advanced, 60);
        markStamp(Stamp.Stall.Clowns, Stamp.Tier.Basic, 99);
        markStamp(Stamp.Stall.Clowns, Stamp.Tier.Basic, 70);
        markStamp(Stamp.Stall.Fishing, Stamp.Tier.Hard, 30);


        Debug.LogFormat("Loaded StampCard {0}", JsonUtility.ToJson(savedStampCard));


    }

    private void Update()
    {
        stampCard.SetActive(stampCardOpen);
        
    }

    void UpdateStampCardUI()
    {
        //Debug.Log(10);

        //Debug.Log(savedStampCard);

        List<Stamp> stamps = savedStampCard.stamps;

        Graphic m_Graphic;
        Color m_MyColor;

        savedStampCard.stamps.ForEach(q =>
        {
            //Debug.Log(100);
            StampUIElements.ForEach(p =>
        {
            
            string stallName = Enum.GetName(typeof(Stamp.Stall), q.stall);
            if (p.Name == stallName)
            {
                m_Graphic = p.ColoredStamp.GetComponent<Graphic>();
                p.stall.GetComponent<Text>().text = q.stall.ToString();
                p.Score.GetComponent<Text>().text = q.Score.ToString();
                int TierCount = q.tier.GetHashCode();
                string TierName = "";
                for (int i = 0; i <= TierCount; i++)
                    TierName += "I";

                p.Tier.GetComponent<Text>().text = TierName;

                if (90 < q.Score && q.Score <= 100)
                {
                    m_MyColor = Color.yellow;
                    p.Exclamation.GetComponent<Text>().text = "Excellent!";
                    
                }
                else if (50 < q.Score)
                {
                    m_MyColor = Color.black;
                    p.Exclamation.GetComponent<Text>().text = "Pass!";
                }
                else
                {
                    m_MyColor = Color.red;
                    p.Exclamation.GetComponent<Text>().text = "Fail!";
                }
                p.Exclamation.GetComponent<Text>().color = m_MyColor;
                m_Graphic.color = m_MyColor;
                //Debug.Log(stallName + " " + TierName);
                //Debug.Log(1000);
            }
        }
            );
        }
        );
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
        if (stampCardOpen)
            UpdateStampCardUI();

    }

    public void toggleStampCard(bool toggle)
    {
        this.stampCardOpen = toggle;
        if (stampCardOpen)
            UpdateStampCardUI();

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
        public GameObject Exclamation;
        public Image ColoredStamp;
        //Not Working

    }

}
