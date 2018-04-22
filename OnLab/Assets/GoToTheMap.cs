using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTheMap : MonoBehaviour {

    SceneLoader scLoad;
    public int mapNumber;

	// Use this for initialization
	void Start () {
        scLoad = GameObject.Find("LoadSceneGO").GetComponent<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoMyMap()
    {
        //Debug.Log(mapNumber);
        scLoad.LoadMap(mapNumber);
    }

}
