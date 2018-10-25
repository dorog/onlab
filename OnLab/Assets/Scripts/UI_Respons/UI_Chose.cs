using UnityEngine;

public class UI_Chose : MonoBehaviour {

    public GameObject androidUI;
    public GameObject windowsUI;

	void Start () {

    #if UNITY_STANDALONE_WIN
        windowsUI.SetActive(true);
        androidUI.SetActive(false);

    #else
        windowsUI.SetActive(false);
        androidUI.SetActive(true);
    #endif
    }
}
