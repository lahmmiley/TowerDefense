using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapDrawer))]
public class MapEditor : Editor
{
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
    }

    private void CreateMapGrid(Vector3 mouseWorldPosition)
    {
        Vector2 point = _mapDrawer.GetPoint(mouseWorldPosition);
        GameObject go = GameObject.Instantiate(_mapDrawer.Go);
        go.transform.position = _mapDrawer.Point2Position(point);
    }


    private Vector3 GetMouseWorldPosition()
    {
        Plane plane = new Plane(_mapDrawer.transform.TransformDirection(Vector3.forward), _mapDrawer.transform.position);
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