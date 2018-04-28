﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseElement : MonoBehaviour {

    private bool rising = false;
    private float rising_time = 0.5f;

    public int x;
    public int z;

    public List<GameObject> boxes = new List<GameObject>();
    public int boxOnIt = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rising)
        {
            if (rising_time - Time.deltaTime >= 0)
            {
                this.transform.GetComponent<Rigidbody>().MovePosition(this.transform.position+new Vector3(0, Configuration.unit * Time.deltaTime * 2, 0));
                rising_time -= Time.deltaTime;
            }
            else if (rising_time > 0)
            {
                this.transform.GetComponent<Rigidbody>().MovePosition(this.transform.position + new Vector3(0, Configuration.unit * rising_time * 2, 0));
                rising_time = 0;
                rising = false;
            }
            //this.transform.GetComponent<Rigidbody>().MovePosition(this.transform.position+ new Vector3(0, 0.1f, 0));
        }
	}

    public void Rise()
    {
        rising = true;
    }
}
