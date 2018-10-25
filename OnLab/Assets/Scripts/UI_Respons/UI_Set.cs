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
        deviceUIRt.anchoredPosition = new Vector3(deviceUIRt.anchoredPosition.x * Screen.width / SharedData.bestScreenWidth, deviceUIRt.anchoredPosition.y * Screen.height / SharedData.bestScreenHeight, 0);

        GameObject menuGO = deviceUI.transform.GetChild(0).gameObject;
        RectTransform menuRt = menuGO.GetComponent<RectTransform>();
        menuRt.anchoredPosition = new Vector3(menuRt.anchoredPosition.x * Screen.width / SharedData.bestScreenWidth, 0, 0);

        VerticalLayoutGroup vlg = menuGO.GetComponent<VerticalLayoutGroup>();
        vlg.padding.left = vlg.padding.left * Screen.width / SharedData.bestScreenWidth;
        vlg.padding.top = vlg.padding.top * Screen.height / SharedData.bestScreenHeight;
        vlg.spacing = vlg.spacing * Screen.height / SharedData.bestScreenHeight;

        GameObject header = menuGO.transform.GetChild(0).gameObject;
        header.GetComponent<RectTransform>().sizeDelta =
            new Vector2(header.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, header.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);

        for (int i = 1; i < menuGO.transform.childCount; i++)
        {
            GameObject menuButton = menuGO.transform.GetChild(i).gameObject;
            menuButton.GetComponent<RectTransform>().sizeDelta =
                new Vector2(menuButton.GetComponent<RectTransform>().sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, menuButton.GetComponent<RectTransform>().sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);
            menuButton.transform.GetChild(0).GetComponent<Text>().fontSize = menuButton.transform.GetChild(0).GetComponent<Text>().fontSize * Screen.height / SharedData.bestScreenHeight;
        }
    }
}
