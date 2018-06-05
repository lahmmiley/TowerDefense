using UnityEngine;
using System.Collections;

public class Firer: MonoBehaviour {
    public GameObject Bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameObject bullet = GameObject.Instantiate(Bullet);
            bullet.AddComponent<Bullet>();
        }
	}
}
