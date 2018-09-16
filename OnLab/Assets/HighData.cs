using System.Collections.Generic;
using UnityEngine;

public class HighData : MonoBehaviour {

    public List<GameObject> boxes = new List<GameObject>();
    public int baseHigh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual int HeightCalculate()
    {
        return baseHigh + boxes.Count;
    }
}
