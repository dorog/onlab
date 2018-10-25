using UnityEngine;
using UnityEngine.UI;

public class UI_ls_Set : MonoBehaviour {

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
        GameObject slots = deviceUI.transform.GetChild(1).gameObject;
        HorizontalLayoutGroup hlg = slots.GetComponent<HorizontalLayoutGroup>();
        hlg.padding.left = hlg.padding.left * Screen.width / SharedData.bestScreenWidth;
        hlg.spacing = hlg.spacing * Screen.width / SharedData.bestScreenWidth;

        GameObject mainMenuBtn = deviceUI.transform.GetChild(0).gameObject;
        RectTransform mainMenuRt = mainMenuBtn.GetComponent<RectTransform>();
        mainMenuRt.sizeDelta =
            new Vector2(mainMenuRt.sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, mainMenuRt.sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);
        mainMenuRt.anchoredPosition = new Vector3(mainMenuRt.anchoredPosition.x * Screen.width / SharedData.bestScreenWidth, mainMenuRt.anchoredPosition.y * Screen.height / SharedData.bestScreenHeight, 0);
        mainMenuBtn.transform.GetChild(0).GetComponent<Text>().fontSize = mainMenuBtn.transform.GetChild(0).GetComponent<Text>().fontSize * Screen.width / SharedData.bestScreenWidth;

        for (int i = 0; i < slots.transform.childCount; i++)
        {
            RectTransform rt = slots.transform.GetChild(i).GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, rt.sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);
            rt = rt.GetChild(0).GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta[0] * Screen.width / SharedData.bestScreenWidth, rt.sizeDelta[1] * Screen.height / SharedData.bestScreenHeight);
            RectTransform bpanel = rt.GetChild(0).GetComponent<RectTransform>();
            bpanel.offsetMin = new Vector2(bpanel.offsetMin[0] * Screen.width / SharedData.bestScreenWidth, bpanel.offsetMin[1] * Screen.height / SharedData.bestScreenHeight);
            bpanel.offsetMax = new Vector2(bpanel.offsetMax[0] * Screen.width / SharedData.bestScreenWidth, bpanel.offsetMax[1] * Screen.height / SharedData.bestScreenHeight);
        }
    }
}
