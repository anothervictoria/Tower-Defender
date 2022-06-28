using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlacable;
    [SerializeField] Tower towerPrefab;

    private Vector3 prefabTransformPosition;

    public bool IsPlaceable { get{return isPlacable;}}

    private void Start()
    {
        prefabTransformPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }

    private void OnMouseDown()
    {
        if (isPlacable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlacable = !isPlaced;
        }

    }
}
