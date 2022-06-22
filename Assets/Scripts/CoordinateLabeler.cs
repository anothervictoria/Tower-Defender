using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColour = Color.gray;
    [SerializeField] Color blockedColour = Color.black;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColourCoordinates();
        ToggleLabels();
    }

    private void ColourCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColour;
        }
        else
        {
            label.color = blockedColour;
        }
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void DisplayCoordinates()
    {
#if UNITY_EDITOR
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
#endif
        label.text = coordinates.x + ", " + coordinates.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
