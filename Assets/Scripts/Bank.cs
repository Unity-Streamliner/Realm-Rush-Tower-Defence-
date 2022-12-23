using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 250;
    [SerializeField] int currentBalance;
    [SerializeField] TMP_Text displayBalance;

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplayBalance();
    }

    void UpdateDisplayBalance()
    {
        displayBalance.text = $"Gold: {currentBalance}";
    }

    public int CurrentBalance { get { return currentBalance; } }
    // Start is called before the first frame update
    public void Deposite(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplayBalance();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplayBalance();

        if (currentBalance < 0)
        {
            // Lose the Game
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
