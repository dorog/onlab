using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    public GameObject UFO;
    public GameObject UFO_place;
    public bool rise = false;
    public bool returnHome = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (rise)
        {
            rise = false;
            UFO_place.GetComponent<Animation>().Play();
            UFO.GetComponent<UFO_Move>().Start_animation();
        }
        if (returnHome)
        {
            returnHome = false;
            UFO.GetComponent<UFO_Move>().Come_back();
        }
    }
}
