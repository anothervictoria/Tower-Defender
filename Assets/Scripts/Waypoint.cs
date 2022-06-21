using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlacable;
    [SerializeField] GameObject towerPrefab;
    private Vector3 prefabTransformPosition;

    private void Start()
    {
        prefabTransformPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }

    private void OnMouseDown()
    {
        if (isPlacable)
        {
            GameObject tower = Instantiate(towerPrefab, prefabTransformPosition, Quaternion.identity);
            tower.transform.Rotate(new Vector3(-90, 0, 0));
            isPlacable = false;
        }
        
    }
}
