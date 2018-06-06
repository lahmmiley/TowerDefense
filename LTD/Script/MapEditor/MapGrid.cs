using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapGrid : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private bool _select = false;
    public bool Select
    {
        get
        {
            return _select;
        }
        set
        {
            _select = value;
            Refresh();
        }
    }

    private Image _image;
    private RectTransform _rect;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Select = true;
        }
        else if(Input.GetKey(KeyCode.Mouse1))
        {
            Select = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Select = true;
        }
        else if(Input.GetKey(KeyCode.Mouse1))
        {
            Select = false;
        }
    }

    void Awake()
    {
        _rect = gameObject.AddComponent<RectTransform>();
        _image = gameObject.AddComponent<Image>();
        _image.color = new Color(1, 0, 0, 0);
        _select = false;
        //_rect.sizeDelta = new Vector2(MapDefine.GRID_WIDTH, MapDefine.GRID_HEIGHT);
    }

    private void Refresh()
    {
        if(_select)
        {
            _image.color = new Color(1, 0, 0, 0.2f);
        }
        else
        {
            _image.color = new Color(1, 0, 0, 0);
        }
    }
}
