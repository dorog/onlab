using UnityEngine;
using UnityEngine.UI;

public class UI_Set : MonoBehaviour {

    public GameObject androidUI;
    public GameObject windowsUI;
    private GameObject deviceUI;

    // Use this for initialization
    void Start () {

        #if UNITY_ANDROID
            deviceUI = androidUI;
            androidUI.SetActive(true);
            windowsUI.SetActive(false);
        #else
            deviceUI = windowsUI;
            androidUI.SetActive(false);
            windowsUI.SetActive(true);
        #endif
        MakeUI();
    }
	

    void MakeUI()
    {
        RectTransform deviceUIRt = deviceUI.GetComponent<RectTransform>();
        deviceUIRt.anchoredPosition = new Vector3(deviceUIRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, deviceUIRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);

        GameObject menuGO = deviceUI.transform.GetChild(0).gameObject;
        RectTransform menuRt = menuGO.GetComponent<RectTransform>();
        menuRt.anchoredPosition = new Vector3(menuRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);

        VerticalLayoutGroup vlg = menuGO.GetComponent<VerticalLayoutGroup>();
        vlg.padding.left = vlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        vlg.padding.top = vlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        vlg.spacing = vlg.spacing * Screen.height / Configuration.bestScreenHeight;

        GameObject header = menuGO.transform.GetChild(0).gameObject;
        header.GetComponent<RectTransform>().sizeDelta =
            new Vector2(header.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, header.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        for (int i = 1; i < menuGO.transform.childCount; i++)
        {
            GameObject menuButton = menuGO.transform.GetChild(i).gameObject;
            menuButton.GetComponent<RectTransform>().sizeDelta =
                new Vector2(menuButton.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, menuButton.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
            menuButton.transform.GetChild(0).GetComponent<Text>().fontSize = menuButton.transform.GetChild(0).GetComponent<Text>().fontSize * Screen.height / Configuration.bestScreenHeight;
        }
    }
}
