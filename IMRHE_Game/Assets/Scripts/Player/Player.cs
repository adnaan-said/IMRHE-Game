using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    private int CashAmount = 0;
    [SerializeField]
    private bool tutorialEnabled = false;
    private int cashMultiplier=1;
    private int Attempts=10;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Cash"))
        {
            PlayerPrefs.SetInt("Cash", 0);
            LoadCash();
        }
        else
        {
            LoadCash();
        }

        if (!PlayerPrefs.HasKey("Cash_Multiplier"))
        {
            PlayerPrefs.SetInt("Cash_Multiplier", 1);
            LoadCashMult();
        }
        else
        {
            LoadCashMult();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadCash()
    {
        CashAmount = PlayerPrefs.GetInt("Cash");
        Debug.Log(CashAmount);
    }
    public void LoadCashMult()
    {
        cashMultiplier = PlayerPrefs.GetInt("Cash_Multiplier");
    }
    public void LoadAll()
    {
        LoadCash();
        LoadCashMult();
    }

    public double getCash()
    {
        return CashAmount;
    }
    public double getCashMultiplier()
    {
        return CashAmount;
    }

    public void addMultiplier(int increment)
    {
        cashMultiplier += increment;
        PlayerPrefs.SetInt("Cash_Multiplier", cashMultiplier);
    }

    public bool debitCash(int Debit)
    {
        if ((CashAmount - Debit) < 0)
        { CashAmount -= Debit; 
            PlayerPrefs.SetInt("Cash", CashAmount);
            Debug.Log(CashAmount);
        }
        else
            return false;
        return true;
    }

    public void GoBackToLevel()
    {
        SceneManager.LoadScene("Level-1 1");
    }
}
