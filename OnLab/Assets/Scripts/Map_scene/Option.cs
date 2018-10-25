using UnityEngine;

public class Option : MonoBehaviour {

    [SerializeField]
    private GameObject ui;

    #if !UNITY_ANDROID
            void Update () {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                ui.SetActive(!ui.activeSelf);
            }
	    }
    #endif

    public void ChangeUI()
    {
        ui.SetActive(!ui.activeSelf);
    }
}
