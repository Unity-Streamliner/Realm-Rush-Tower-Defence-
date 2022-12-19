using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other) 
    {
        print("dbg: " + currentHitPoints);
        ProcessHit();
    }

    void ProcessHit() 
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
