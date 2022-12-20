using Enemy;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
