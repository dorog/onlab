using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMainForAndroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam = this.transform.GetComponent<Camera>();
        cam.enabled = false;
	}
}
