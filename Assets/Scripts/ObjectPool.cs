using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float timeToWait = 1f;
    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    
    
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
            
        }
    }

    private IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(timeToWait);
        }        
    }
}
