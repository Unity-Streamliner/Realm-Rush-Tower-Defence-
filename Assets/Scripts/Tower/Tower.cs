using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int buildTowerCost = 50;
    public bool createTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) { return false; }
        if (bank.CurrentBalance >= buildTowerCost) 
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(buildTowerCost);
            return true;
        } 
        return false;
    }

    void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        foreach (Transform child in transform) 
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
        }
        
    }
}
