using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenGate(int number)
    {
        //Debug.Log("nyugi, nyitom " + number);
        if (number >= 0 && number <= 5)
        {
            this.transform.GetChild(number).transform.position += new Vector3(300, 0, 0);
        }
        else if(number > 5 && number <= 7)
        {
            this.transform.GetChild(number).transform.position += new Vector3(0, -550, 0);
        }
    }
}
