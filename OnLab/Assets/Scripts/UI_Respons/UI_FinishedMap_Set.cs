using UnityEngine;
using UnityEngine.UI;

public class UI_FinishedMap_Set : MonoBehaviour {

    public GameObject androidUI;
    public GameObject windowsUI;
    private GameObject deviceUI;

    // Use this for initialization
    void Start()
    {
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
        //BackGround (black border)
        RectTransform backGroundRT = deviceUI.transform.GetChild(0).GetComponent<RectTransform>();
        backGroundRT.offsetMin = new Vector2(backGroundRT.offsetMin[0] * Screen.height / Configuration.bestScreenHeight, backGroundRT.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
        backGroundRT.offsetMax = new Vector2(backGroundRT.offsetMax[0] * Screen.height / Configuration.bestScreenHeight, backGroundRT.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);

        //FinishedPanel
        GameObject finishedPanel = deviceUI.transform.GetChild(1).gameObject;
        RectTransform finishedRt = finishedPanel.GetComponent<RectTransform>();
        finishedRt.offsetMin = new Vector2(finishedRt.offsetMin[0] * Screen.height / Configuration.bestScreenHeight, finishedRt.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
        finishedRt.offsetMax = new Vector2(finishedRt.offsetMax[0] * Screen.height / Configuration.bestScreenHeight, finishedRt.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);

        //ScarabImg
        RectTransform scarabImg = finishedPanel.transform.GetChild(0).GetComponent<RectTransform>();
        scarabImg.anchoredPosition = new Vector3(0, scarabImg.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        scarabImg.sizeDelta =
                new Vector2(scarabImg.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, scarabImg.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //ScoreText
        GameObject scoreText = finishedPanel.transform.GetChild(1).gameObject;
        RectTransform scoreTextRt = scoreText.GetComponent<RectTransform>();
        scoreTextRt.anchoredPosition = new Vector3(0, scoreTextRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        scoreTextRt.sizeDelta =
                new Vector2(scoreTextRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, scoreTextRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        Text scoreTxt = scoreText.GetComponent<Text>();
        scoreTxt.fontSize = scoreTxt.fontSize * Screen.height / Configuration.bestScreenHeight;

        //TryAgain btn
        GameObject tryAgain = finishedPanel.transform.GetChild(2).gameObject;
        RectTransform tryAgainRt = tryAgain.GetComponent<RectTransform>();
        tryAgainRt.sizeDelta = new Vector2(tryAgainRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, tryAgainRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        tryAgainRt.anchoredPosition = new Vector3(0, tryAgainRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        Text tryAgainText = tryAgain.transform.GetChild(0).GetComponent<Text>();
        tryAgainText.fontSize = tryAgainText.fontSize * Screen.height / Configuration.bestScreenHeight;

        //ReturnMapGuide
        GameObject ReturnMapGuide = finishedPanel.transform.GetChild(3).gameObject;
        RectTransform returnMapRt = ReturnMapGuide.GetComponent<RectTransform>();
        returnMapRt.sizeDelta = new Vector2(returnMapRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, returnMapRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        returnMapRt.anchoredPosition = new Vector3(0, returnMapRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        Text returnMapText = ReturnMapGuide.transform.GetChild(0).GetComponent<Text>();
        returnMapText.fontSize = returnMapText.fontSize * Screen.height / Configuration.bestScreenHeight;
        RectTransform returnMapTextRt = ReturnMapGuide.transform.GetChild(0).GetComponent<RectTransform>();
        returnMapTextRt.offsetMin = new Vector2(0, returnMapTextRt.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
        returnMapTextRt.offsetMax = new Vector2(0, returnMapTextRt.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);
    }
}
