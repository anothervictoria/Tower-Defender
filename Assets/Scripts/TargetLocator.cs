using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
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

        //Vector3 toTargetVector = target.position - weapon.transform.position;
        //float zRotation = (Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg);
        //weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));


        Vector3 weaponLookAtPos = new Vector3(target.position.x, weapon.position.y, target.position.z);
        weapon.LookAt(weaponLookAtPos);

    }
}
