using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(gameObject);
    }
}
