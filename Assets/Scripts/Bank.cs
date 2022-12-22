using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public int CurrentBalance { get { return currentBalance; } }
    // Start is called before the first frame update
    public void Deposite(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
