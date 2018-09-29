using UnityEngine;

public class Option : MonoBehaviour {

    public GameObject ui;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            ui.SetActive(!ui.activeSelf);
        }
	}
}
