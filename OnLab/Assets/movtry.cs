using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movtry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            this.transform.position += this.transform.forward * 50;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.transform.position -= this.transform.forward * 50;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            this.transform.RotateAround(this.transform.position+this.transform.forward*20, this.transform.up, -90);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.transform.RotateAround(this.transform.position + this.transform.forward * 20, this.transform.up, 90);
        }
    }
}
