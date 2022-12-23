using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Add amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    
    int currentHitPoints = 0;
    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
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
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}


