using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//public class Enemy : MonoBehaviour
//{
//    enum Direction
//    {
//        up,
//        right,
//        down,
//        left,
//    }
//    private List<Vector3> _pathList = new List<Vector3>()
//    {
//        new Vector3(1, 1, 0),
//    };

//    private Vector3 _target;
//    private bool _reach;
//    private float _velocity;

//    public Enemy()
//    {
//        _velocity = 0.64f;
//        _reach = false;
//        
//    }

//    public void Update()
//    {
//        if(_reach)
//        {
//            return;
//        }
//        if((_target.x == transform.position.x) && (_target.y == transform.position.y))
//        {
//            if(_pathList.Count > 0)
//            {
//                _target = _pathList[0];
//                _pathList.RemoveAt(0);
//                //Vector2 direction = _target - 
//            }
//        }

//        //float deltaX = Time.deltaTime * 
//        //if(transform.position)
//    }
//}
