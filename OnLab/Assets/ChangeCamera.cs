using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    public GameObject androidCameras;
    public GameObject windowsCameras;
    private Camera[] cameras;
    private int activeCamera = 0;

    private void Start()
    {
        #if UNITY_ANDROID
            cameras = androidCameras.GetComponentsInChildren<Camera>();
            windowsCameras.SetActive(false);
        #else
            cameras = windowsCameras.GetComponentsInChildren<Camera>();
            androidCameras.SetActive(false);
        #endif
        if (cameras.Length == 0)
        {
            return;
        }
        for(int i=1; i<cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCamera();
        }
	}

    public void SwitchCamera()
    {
        if (cameras.Length == 1)
        {
            return;
        }
        cameras[activeCamera].gameObject.SetActive(false);
        if (activeCamera == cameras.Length - 1)
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
