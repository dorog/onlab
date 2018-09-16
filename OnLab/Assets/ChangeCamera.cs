using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    public List<Camera> cameras = new List<Camera>();
    private int activeCamera = 0;

    private void Start()
    {
        if (cameras.Count == 0)
        {
            return;
        }
        for(int i=1; i<cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(cameras.Count == 1)
            {
                return;
            }
            cameras[activeCamera].gameObject.SetActive(false);
            if(activeCamera == cameras.Count - 1)
            {
                activeCamera = 0;
            }
            else
            {
                activeCamera++;
            }
            cameras[activeCamera].gameObject.SetActive(true);
        }
	}
}
