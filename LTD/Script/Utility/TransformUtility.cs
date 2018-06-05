using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TransformUtility
{
    public static void SetParent(RectTransform child, Transform parent)
    {
        child.SetParent(parent);
        child.pivot = Vector2.up;
        child.anchorMin = Vector2.up;
        child.anchorMax = Vector2.up;
        child.localScale = Vector3.one;
    }
}
