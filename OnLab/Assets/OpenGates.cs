using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates : MonoBehaviour {

    private bool door_is_Opening = false;
    private int doorNumber = 0;
    private float OpeningSpeed = 50;
    public float OpeningTime = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (door_is_Opening)
        {
            if (doorNumber < CurrentGameDatas.maxMap - 2)
            {
                if (OpeningTime - Time.deltaTime >= 0)
                {
                    this.transform.GetChild(doorNumber).position += new Vector3(1, 0, 0) * Time.deltaTime * OpeningSpeed;
                    OpeningTime -= Time.deltaTime;
                }
                else
                {
                    door_is_Opening = false;
                }
            }
            else
            {
                if (OpeningTime - Time.deltaTime >= 0)
                {
                    this.transform.GetChild(doorNumber).position += new Vector3(0, 1, 0) * Time.deltaTime * OpeningSpeed*2.5f;
                    OpeningTime -= Time.deltaTime;
                }
                else
                {
                    door_is_Opening = false;
                }
            }
        }
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

    public void OpenGateNew(int number)
    {
        door_is_Opening = true;
        doorNumber = number;
        //Debug.Log("New Key");
    }
}
