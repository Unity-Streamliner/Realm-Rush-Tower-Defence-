using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        var closestDistance = Mathf.Infinity;
        var position = transform.position;
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies) 
        {
            Vector3 offset = enemy.transform.position - transform.position;
            float enemyDistance = offset.sqrMagnitude;
            if (enemyDistance < closestDistance)
            {
                closestDistance = enemyDistance;
                target = enemy.transform;
            }
        }

    }

    void AimWeapon()
    {
        weapon.LookAt(target);
        float targetDistance = Vector3.Distance(transform.position, target.position);
        print($"dbg targetDistance = {targetDistance}");
        Attack(targetDistance <= range);
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
