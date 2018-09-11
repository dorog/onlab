using UnityEngine;
using UnityEngine.UI;

public class UI_FinishedMap_Set : MonoBehaviour {

    public RectTransform backGroundRT;
    public RectTransform finishedRt;
    public RectTransform scarabImg;
    public Text scoreText;
    public Button tryAgain;
    public Button ReturnMapGuide;

    // Use this for initialization
    void Start()
    {
        //BackGround (black border)
        backGroundRT.offsetMin = new Vector2(backGroundRT.offsetMin[0] * Screen.height / Configuration.bestScreenHeight, backGroundRT.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
        backGroundRT.offsetMax = new Vector2(backGroundRT.offsetMax[0] * Screen.height / Configuration.bestScreenHeight, backGroundRT.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);

        //FinishedPanel
        finishedRt.offsetMin = new Vector2(finishedRt.offsetMin[0] * Screen.height / Configuration.bestScreenHeight, finishedRt.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
        finishedRt.offsetMax = new Vector2(finishedRt.offsetMax[0] * Screen.height / Configuration.bestScreenHeight, finishedRt.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);

        //ScarabImg
        scarabImg.anchoredPosition = new Vector3(0, scarabImg.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        scarabImg.sizeDelta =
                new Vector2(scarabImg.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, scarabImg.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //ScoreText
        RectTransform scoreTextRt = scoreText.GetComponent<RectTransform>();
        scoreTextRt.anchoredPosition = new Vector3(0, scoreTextRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        scoreTextRt.sizeDelta =
                new Vector2(scoreTextRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, scoreTextRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        Text scoreTxt = scoreText.GetComponent<Text>();
        scoreTxt.fontSize = scoreTxt.fontSize * Screen.height / Configuration.bestScreenHeight;

        //TryAgain btn
        RectTransform tryAgainRt = tryAgain.GetComponent<RectTransform>();
        tryAgainRt.sizeDelta = new Vector2(tryAgainRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, tryAgainRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        tryAgainRt.anchoredPosition = new Vector3(0, tryAgainRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        Text tryAgainText = tryAgain.transform.GetChild(0).GetComponent<Text>();
        tryAgainText.fontSize = tryAgainText.fontSize * Screen.height / Configuration.bestScreenHeight;

        //ReturnMapGuide
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
