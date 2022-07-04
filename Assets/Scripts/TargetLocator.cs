using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    //[SerializeField] Transform weapon;
    
    //[SerializeField] float range = 300f;
    //[SerializeField] float targetDistance;
    //Transform target;
    //public float turnSpeed = 20;

    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;


    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;


    }

    private void AimWeapon()
    {
        //targetDistance = Vector3.Distance(weapon.transform.position, target.position);
        //if(target.gameObject != null)
        //{
        //    Vector3 weaponLookAtPos = new Vector3(target.position.x, weapon.position.y, target.position.z);
        //    weapon.LookAt(weaponLookAtPos);
        //}

        

        float targetDistance = Vector3.Distance(weapon.transform.position, target.position);

        Vector3 weaponLookAtPos = new Vector3(target.position.x, weapon.position.y, target.position.z);
        weapon.LookAt(weaponLookAtPos);

        if (targetDistance <= range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;

    }
}
