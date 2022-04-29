using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private double walkingSpeed = 1.0;
    [SerializeField]
    private int CashAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public double getWalkingSpeed()
    {
        return walkingSpeed;
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
