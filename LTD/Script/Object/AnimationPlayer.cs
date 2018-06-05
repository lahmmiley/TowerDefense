using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    Animation _anim;
    // Use this for initialization  
    void Start()
    {
        _anim = GetComponent<Animation>();

        if (_anim != null)
        {
            _anim.Play("move1");
        }
    }

}
