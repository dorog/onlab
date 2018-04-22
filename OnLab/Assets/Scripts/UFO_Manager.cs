using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Manager : MonoBehaviour {

    public GameObject UFO;
    public GameObject UFO_place;
    public float minWait = 30;
    public float maxWait = 60;

	// Use this for initialization
	void Start () {
        float rand = Random.Range(minWait, maxWait);
        Invoke("Fly_Away", rand);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fly_Away()
    {
        UFO_place.GetComponent<Animation>().Play();
        UFO.GetComponent<UFO_Move>().Start_animation();

        float rand = Random.Range(minWait, maxWait);
        Invoke("Come_Back", rand);
    }

    public void Come_Back()
    {
        UFO.GetComponent<UFO_Move>().Come_back();

        float rand = Random.Range(minWait, maxWait);
        Invoke("Fly_Away", rand);
    }
}
