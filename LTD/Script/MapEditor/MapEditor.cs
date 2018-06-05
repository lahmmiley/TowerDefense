using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class MapEditor {

    private static MapEditor _instance;
    public static MapEditor Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new MapEditor();
            }
            return _instance;
        }
    }

    private MapEditor() { }

    private GameObject _map;
    private MapGrid[] _mapGridArray;
    private int _row;
    private int _column;

    public void Init()
    {
        _map = GameObject.Find("Canvas/Map");
        RectTransform rect = _map.GetComponent<RectTransform>();
        Vector2 size = rect.sizeDelta;
        _row = (int)Math.Floor(size.y / MapDefine.GRID_HEIGHT);
        _column = (int)Math.Floor(size.x / MapDefine.GRID_WIDTH);
        _mapGridArray = new MapGrid[_row * _column];
        for(int i = 0; i < _row; i++)
        {
            for(int j = 0; j < _column; j++)
            {
                GameObject go = new GameObject("Grid" + GetIndex(i, j, _column).ToString());
                MapGrid mapGrid = go.AddComponent<MapGrid>();
                RectTransform mapRect = go.GetComponent<RectTransform>();
                TransformUtility.SetParent(mapRect, rect);
                mapRect.anchoredPosition3D = new Vector3(j * MapDefine.GRID_WIDTH, -i * MapDefine.GRID_HEIGHT, 0);
                _mapGridArray[GetIndex(i, j, _column)] = mapGrid;
            }
        }
	}

    public int GetIndex(int rowIndex, int columnIndex, int column)
    {
        return rowIndex * column + columnIndex;
    }

    public class MapRecord
    {
        public int[] Data;
        public int Row;
        public int Column;

        public MapRecord() { }

        public MapRecord(int row, int column)
        {
            Row = row;
            Column = column;
            Data = new int[row * column];
        }

        public void SetSelect(int rowIndex, int columnIndex, int value)
        {
            Data[rowIndex * Column + columnIndex] = value;
        }

        public int GetSelect(int rowIndex, int columnIndex)
        {
            return Data[rowIndex * Column + columnIndex];
        }
    }

    public void Save()
    {
        MapRecord record = new MapRecord(_row, _column);
        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _column; j++)
            {
                MapGrid mapGrid = _mapGridArray[GetIndex(i, j, _column)];
                record.SetSelect(i, j, mapGrid.Select ? MapDefine.SELECT : MapDefine.UNSELECT);
            }
        }

        using (StreamWriter sw = new StreamWriter(MapDefine.MAP_DATA_PATH))
        {
            sw.Write(JsonMapper.ToJson(record));
        }
    }

    public void Load()
    {
        string str;
        using (StreamReader sr = new StreamReader(MapDefine.MAP_DATA_PATH))
        {
            str = sr.ReadToEnd();
        }

        MapRecord mapRecord = JsonMapper.ToObject<MapRecord>(str);
        for(int i = 0; i < mapRecord.Row; i++)
        {
            for(int j = 0; j < mapRecord.Column; j++)
            {
                MapGrid mapGrid = _mapGridArray[GetIndex(i, j, mapRecord.Column)];
                mapGrid.Select = mapRecord.GetSelect(i, j) == MapDefine.SELECT;
            }
        }
    }
}
