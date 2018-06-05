using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnter : MonoBehaviour {
	void Awake()
    {
        MapEditor.Instance.Init();
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            MapEditor.Instance.Save();
        }

        //if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            MapEditor.Instance.Load();
        }
    }
}
