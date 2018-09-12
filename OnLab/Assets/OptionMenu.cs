using UnityEngine;

public class OptionMenu : MonoBehaviour {

    public GameObject ui;
    public bool change = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ui.SetActive(!ui.activeSelf);
        }
        if (change)
        {
            ui.SetActive(!ui.activeSelf);
            change = false;
        }
	}
}
