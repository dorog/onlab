using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1Generator : MonoBehaviour {

    public GameObject brickModel;

	// Use this for initialization
	void Start () {

        GameObject parent = GameObject.Find("MapGeneratorGO");

        for(int i=0; i<20; i++)
        {
            for(int j=0; j<20; j++)
            {
                GameObject brick = Instantiate(brickModel, new Vector3(25+i*50, 0, 25+j*50), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
            }
        }
        
    }
	
}
