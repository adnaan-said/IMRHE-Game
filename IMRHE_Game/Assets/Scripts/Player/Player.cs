using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    // Update is called once per frame
    void Update()
    {

    }



    public double getCash()
    {
        return CashAmount;
    }
    public void addCash(int deposit)
    {
        CashAmount+=deposit;
    }
    public void debitCash(int Debit)
    {
        CashAmount += Debit;
    }
}
