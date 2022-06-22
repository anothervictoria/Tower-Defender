using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    public float turnSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        if(target.gameObject != null)
        {
            Vector3 weaponLookAtPos = new Vector3(target.position.x, weapon.position.y, target.position.z);
            weapon.LookAt(weaponLookAtPos);
        }


    }
}
