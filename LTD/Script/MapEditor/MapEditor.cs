using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapDrawer))]
public class MapEditor : Editor
{
    public GameObject Go;

    private MapDrawer _mapDrawer;
    private Dictionary<Vector2, MapGrid> _mapGridDict = new Dictionary<Vector2, MapGrid>();

    private void Awake()
    {
        _mapDrawer = this.target as MapDrawer;
    }

    

    public void OnSceneGUI()
    {
        if(!_mapDrawer)
        {
            return;
        }

        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        if(_mapDrawer.ValidClick(mouseWorldPosition))
        {
            Event currentEvent = Event.current;
            Debug.LogError(currentEvent.type);
            if (currentEvent.type == EventType.MouseDown
                || currentEvent.type == EventType.MouseDrag)
            {

                Debug.LogError(currentEvent.button);
                if (currentEvent.button == 0)
                {
                    CreateMapGrid(mouseWorldPosition);
                    currentEvent.Use();
                }

                if (currentEvent.button == 1)
                {
                    currentEvent.Use();
                }
            }
        }
        else
        {
        }
        
    }

    private void CreateMapGrid(Vector3 mouseWorldPosition)
    {
        Vector2 point = GetPoint(mouseWorldPosition);
        GameObject go = GameObject.Instantiate(Go);
        go.transform.position = Point2Position(point);
    }


    private Vector3 GetMouseWorldPosition()
    {
        Plane plane = new Plane(transform.TransformDirection(Vector3.forward), transform.position);
        Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        Vector3 hitPosition = new Vector3();
        float distance;
        if (plane.Raycast(worldRay, out distance))
        {
            hitPosition = worldRay.GetPoint(distance);
        }
        return hitPosition;
    }
}