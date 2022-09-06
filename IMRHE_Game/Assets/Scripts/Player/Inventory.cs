using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Inventory : MonoBehaviour
{

    // Start is called before the first frame update
    SaveInventory savedInventory;
    public bool isInactive = false;
    public bool InventoryOpen=false;
    public GameObject inventory;
    public Description DescriptionTextBox;
    public List<InvSlot> slots;
    private Pause pause;

    
    void Start()
    {
        if (!isInactive)
        {
            inventory.SetActive(true);
            pause = GetComponent<Pause>();
            InventoryOpen = false;
        }

        savedInventory = new SaveInventory();
        savedInventory.Load();

        //Initialisation of the DB
        //purchaseItem(Item.Type.Token, 1, "Token used to attempt events at different stalls!");
        //purchaseItem(Item.Type.CashBoost, 10, "A Token that permanently increases the Cash Multiplier by a small amount!");
        //purchaseItem(Item.Type.AttemptUP, 10, "A potion that makes stall owners want to give you extra tries for free!");
        //purchaseItem(Item.Type.SilverKey, 1, "A key that allows you to unlock Advanced difficulty of a stall");
        //purchaseItem(Item.Type.GoldKey, 1, "A key that allows you to unlock Hard difficulty of a stall");
        //savedInventory.Save();

        UpdateInventoryUI();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isInactive)
        {
            if (pause.PauseMenu.activeSelf)
                if (Input.GetKeyDown(KeyCode.I))
                    InventoryOpen = !InventoryOpen;
            inventory.SetActive(InventoryOpen);
        }
    }

    private void OnDestroy()
    {
        savedInventory.Save();
    }

    public void ActivateInventory()
    {
        if (!isInactive)
        {
            InventoryOpen = !InventoryOpen;
            if (InventoryOpen)
            {
                UpdateInventoryUI();
            }
        }
    }

    void UpdateInventoryUI()
    {
        if (!isInactive)
        {
            Debug.Log(10);

            //Debug.Log(savedStampCard);

            List<Item> stamps = savedInventory.items;

            savedInventory.items.ForEach(q =>
            {
            //Debug.Log(100);
            slots.ForEach(p =>
                {

                    string itemName = Enum.GetName(typeof(Item.Type), q.type);
                    if (p.Name == itemName)
                    {
                        if (q.amount > 0)
                        {
                            Debug.Log(100);
                            p.Holder.SetActive(true);
                            p.count.GetComponent<Text>().text = q.amount.ToString();
                            p.ImageSlot.GetComponent<Image>().sprite = p.Sprite;
                            p.ImageSlot.GetComponent<Image>().preserveAspect = true;

                        //p.DescriptionButton.onClick.AddListener(TaskOnClick);
                        p.DescriptionButton.onClick.AddListener(
                                () =>
                                {
                                    DescriptionTextBox.TitleField.text = q.type.ToString();
                                    DescriptionTextBox.DescriptionField.text = q.Description;
                                    Debug.Log("Haawwwyaaaaa");
                                });
                        }
                        else
                        {
                            p.Holder.SetActive(false);
                        }
                    //Debug.Log(stallName + " " + TierName);
                    //Debug.Log(1000);
                }
                }
                );
            }
            );
        }
    }

    void useItem(Item.Type P_type, int P_amount)
    {
        var item = savedInventory.items.Find(q => q.type == P_type);        //Making sure item exists
        if (item != null)
            purchaseItem(P_type, P_amount, "");
    }

    public void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    void purchaseItem(Item.Type P_type, int P_amount, string P_Description)
    {
        var item = savedInventory.items.Find(q => q.type == P_type);
        if (item == null)
            addNewItem(P_type, P_amount, P_Description);
        else
        {
            int totalAmount = item.amount + P_amount;
            if (totalAmount > 999)
            {
                item.amount = 999;
            }
            else if(totalAmount<0)                      //Handle Using as well
            {
                item.amount = 0;
            }
            else
            {
                item.amount = totalAmount;
            }
            
        }
    }

    void addNewItem(Item.Type P_type, int P_amount, string P_Description)
    {
        Item item = new Item();
        bool isMarked = false;

        item = new Item()
        {
            amount = P_amount,
            type = P_type,
            Description = P_Description
        };
        savedInventory.items.Add(item);

    }

    [System.Serializable]
    public class Item
    {
        public enum Type { Token, CashBoost, AttemptUP, SilverKey, GoldKey };

        public int amount;

        public Type type;

        public string Description;

    }

    [System.Serializable]
    private class SaveInventory
    {
        //Path with persistence
        //private string savePath { get { return Path.Combine(Application.persistentDataPath, "Json/Inventory.json"); } }
        //Current Path
        private string savePath = "./Assets/Scripts/JSON/Inventory.json";

        // items currently in the inventory
        public List<Item> items;
        public SaveInventory()
        {
            items = new List<Item>();
        }

        public void Save()
        {
            File.WriteAllText(savePath, JsonUtility.ToJson(this));
        }
        public void Load()
        {
            if (File.Exists(savePath))
                JsonUtility.FromJsonOverwrite(File.ReadAllText(savePath), this);
        }
    }

    [System.Serializable]
    public class InvSlot
    {
        public string Name;
        public GameObject Holder;
        public GameObject count;
        public Button DescriptionButton;
        public GameObject ImageSlot;
        //public GameObject Cooldown;
        //Future
        public Sprite Sprite;
        //Not Working

    }
    [System.Serializable]
    public class Description
    {
        public Text TitleField;
        public Text DescriptionField;

    }
}
