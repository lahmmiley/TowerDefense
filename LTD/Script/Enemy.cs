using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int hp = 10;
    private void OnTriggerEnter(Collider other)
    {
        hp -= 1;
        if(hp <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
