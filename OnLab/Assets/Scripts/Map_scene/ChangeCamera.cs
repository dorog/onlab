using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    [Header("Cameras in Android")]
    [SerializeField]
    private GameObject androidCameras;
    [Header("Cameras in Windows")]
    [SerializeField]
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
