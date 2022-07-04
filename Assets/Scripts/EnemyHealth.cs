using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    [SerializeField] int difficultyRamp = 1;
    private int currentHitPoints = 0;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;   
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints<= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
