using UnityEngine;
using UnityEngine.UI;

public class UI_MapGuide_Set : MonoBehaviour {

    public Image header;
    public Button returnMainMenu;
    public Text CastList;

	// Use this for initialization
	void Start () {
        RectTransform headerRt = header.GetComponent<RectTransform>();
        headerRt.GetComponent<RectTransform>().sizeDelta =
            new Vector2(headerRt.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, headerRt.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);
        headerRt.anchoredPosition = new Vector3(headerRt.anchoredPosition.x * Screen.width / SharedData.bestScreenWidth, headerRt.anchoredPosition.y * Screen.height / SharedData.bestScreenHeight, 0);

        RectTransform mainMenuRt = returnMainMenu.GetComponent<RectTransform>();
        mainMenuRt.GetComponent<RectTransform>().sizeDelta =
            new Vector2(mainMenuRt.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, mainMenuRt.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);
        mainMenuRt.anchoredPosition = new Vector3(mainMenuRt.anchoredPosition.x * Screen.width / SharedData.bestScreenWidth, mainMenuRt.anchoredPosition.y * Screen.height / SharedData.bestScreenHeight, 0);
        returnMainMenu.transform.GetChild(0).GetComponent<Text>().fontSize = returnMainMenu.transform.GetChild(0).GetComponent<Text>().fontSize * Screen.height / SharedData.bestScreenHeight;

        CastList.fontSize = CastList.fontSize * Screen.height / SharedData.bestScreenHeight;
        RectTransform castListRt = CastList.GetComponent<RectTransform>();
        castListRt.sizeDelta = new Vector2(castListRt.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, castListRt.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);
        castListRt.anchoredPosition = new Vector3(0, -Screen.height/2-castListRt.sizeDelta[1]/2, 0);
    }
}
