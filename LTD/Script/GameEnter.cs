using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnter : MonoBehaviour {
	void Awake()
    {
        MapEditorBackup.Instance.Init();
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            MapEditorBackup.Instance.Save();
        }

        //if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            MapEditorBackup.Instance.Load();
        }
    }
}
