using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighData : MonoBehaviour {

    public List<GameObject> boxes = new List<GameObject>();
    public int baseHigh;
    public bool isTrap = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int HighCalculate()
    {
        if (!isTrap)
        {
            return baseHigh + boxes.Count;
        }
        else
        {
            if (boxes.Count < 3)
            {
                return baseHigh;
            }
            else
            {
                return baseHigh + boxes.Count - 2;
            }
        }
    }
}
