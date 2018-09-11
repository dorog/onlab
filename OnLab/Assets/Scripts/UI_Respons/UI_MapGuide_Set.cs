using UnityEngine;
using UnityEngine.UI;

public class UI_MapGuide_Set : MonoBehaviour {

    public Image header;
    public Button returnMainMenu;

	// Use this for initialization
	void Start () {
        RectTransform headerRt = header.GetComponent<RectTransform>();
        headerRt.GetComponent<RectTransform>().sizeDelta =
            new Vector2(headerRt.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, headerRt.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        headerRt.anchoredPosition = new Vector3(headerRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, headerRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);

        RectTransform mainMenuRt = returnMainMenu.GetComponent<RectTransform>();
        mainMenuRt.GetComponent<RectTransform>().sizeDelta =
            new Vector2(mainMenuRt.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, mainMenuRt.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        mainMenuRt.anchoredPosition = new Vector3(mainMenuRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, mainMenuRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        returnMainMenu.transform.GetChild(0).GetComponent<Text>().fontSize = returnMainMenu.transform.GetChild(0).GetComponent<Text>().fontSize * Screen.height / Configuration.bestScreenHeight;
    }
}
