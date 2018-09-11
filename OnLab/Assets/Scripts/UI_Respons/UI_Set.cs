using UnityEngine;
using UnityEngine.UI;

public class UI_Set : MonoBehaviour {
    
    public Image header;
    public Button[] menuButtons;

    public GameObject menuGO;

    // Use this for initialization
    void Start () {

        VerticalLayoutGroup vlg = menuGO.GetComponent<VerticalLayoutGroup>();
        vlg.padding.left = vlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        vlg.padding.top = vlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        vlg.spacing = vlg.spacing * Screen.height / Configuration.bestScreenHeight;

        header.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(header.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, header.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        for (int i=0; i<menuButtons.Length; i++)
        {
            menuButtons[i].GetComponent<RectTransform>().sizeDelta = 
                new Vector2(menuButtons[i].GetComponent<RectTransform>().sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, menuButtons[i].GetComponent<RectTransform>().sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
            menuButtons[i].transform.GetChild(0).GetComponent<Text>().fontSize = menuButtons[i].transform.GetChild(0).GetComponent<Text>().fontSize * Screen.height / Configuration.bestScreenHeight;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
