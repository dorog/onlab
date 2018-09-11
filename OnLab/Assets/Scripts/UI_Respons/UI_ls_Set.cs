using UnityEngine;
using UnityEngine.UI;

public class UI_ls_Set : MonoBehaviour {

    public GameObject slots;
    public Button mainMenuBtn;

	// Use this for initialization
	void Start () {
        HorizontalLayoutGroup hlg = slots.GetComponent<HorizontalLayoutGroup>();
        hlg.padding.left = hlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        hlg.spacing = hlg.spacing * Screen.width / Configuration.bestScreenWidth;

        RectTransform mainMenuRt = mainMenuBtn.GetComponent<RectTransform>();
        mainMenuRt.sizeDelta =
            new Vector2(mainMenuRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, mainMenuRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        mainMenuRt.anchoredPosition = new Vector3(mainMenuRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, mainMenuRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        mainMenuBtn.transform.GetChild(0).GetComponent<Text>().fontSize = mainMenuBtn.transform.GetChild(0).GetComponent<Text>().fontSize * Screen.width / Configuration.bestScreenWidth;

        for (int i=0; i<slots.transform.childCount; i++)
        {
            RectTransform rt = slots.transform.GetChild(i).GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, rt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
            rt = rt.GetChild(0).GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, rt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
            RectTransform bpanel = rt.GetChild(0).GetComponent<RectTransform>();
            bpanel.offsetMin = new Vector2(0, bpanel.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
            bpanel.offsetMax = new Vector2(0, bpanel.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
