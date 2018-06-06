using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 负责地图的DrawGizmos显示
/// 保存地图相关数据
/// </summary>
public class MapDrawer : MonoBehaviour
{
    public const int ROW_MAX = 8;
    public const int COLUMN_MAX = 13;
    public const float PEXILS_PER_UNIT = 100;
    public const float GRID_WIDTH = 64 / PEXILS_PER_UNIT;
    public const float GRID_HEIGHT = 64 / PEXILS_PER_UNIT;
    public const float WIDTH = GRID_WIDTH * COLUMN_MAX;
    public const float HEIGHT = GRID_HEIGHT * ROW_MAX;

    public bool DrawAlways = true;
    public GameObject Go;
    public int count = 0;

    private float _left;
    private float _right;
    private float _top;
    private float _bottom;



    private void Start()
    {
    }

    private void OnDrawGizmos()
    {
        if(!this.DrawAlways)
        {
            return;
        }
        
        InitMapData();
        Draw();
    }

    private void OnDrawGizmosSelected()
    {
        if(this.DrawAlways)
        {
            return;
        }

        //Draw();
    }

    private void Draw()
    {
        DrawGrid();
    }

    private void DrawGrid()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        for(int i = 0; i <= COLUMN_MAX; i++)
        {
            Vector3 from = new Vector3(_left + i * GRID_WIDTH, _top);
            Vector3 to =  new Vector3(_left + i * GRID_WIDTH, _bottom);
            Gizmos.DrawLine(from, to);
        }

        for(int i = 0; i <= ROW_MAX; i++)
        {
            Vector3 from = new Vector3(_left, _top - GRID_HEIGHT * i);
            Vector3 to = new Vector3(_right, _top - GRID_HEIGHT * i);
            Gizmos.DrawLine(from, to);
        }
    }

    public Vector2 GetPoint(Vector3 position)
    {
        int column = Mathf.FloorToInt((position.x - _left) / GRID_WIDTH);
        int row = Mathf.FloorToInt((_top - position.y) / GRID_HEIGHT);
        return new Vector2(row, column);
    }

    public Vector2 Point2Position(Vector2 point)
    {
        float x = _left + (float)((point.y + 0.5) * GRID_WIDTH);
        float y = _top - (float)((point.x + 0.5) * GRID_HEIGHT);
        return new Vector2(x, y);
    }

    private void InitMapData()
    {
        Vector3 selfPosition = transform.position;
        _left = selfPosition.x - WIDTH / 2;
        _right = selfPosition.x + WIDTH / 2;
        _top = selfPosition.y + HEIGHT / 2;
        _bottom = selfPosition.y - HEIGHT / 2;
    }

    public bool ValidClick(Vector3 hitPosition)
    {
        return _left <= hitPosition.x && hitPosition.x < _right &&
            _bottom < hitPosition.y && hitPosition.y <= _top;
    }
}
