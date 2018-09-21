using UnityEngine;
using UnityEngine.UI;

public class UI_Map_Scene_Set : MonoBehaviour {

    public GameObject androidUI;
    public GameObject windowsUI;
    private GameObject deviceUI;


	void Start () {

    #if UNITY_STANDALONE_WIN
        deviceUI = windowsUI;
        windowsUI.SetActive(true);
        androidUI.SetActive(false);

    #else
        deviceUI = androidUI;
        windowsUI.SetActive(false);
        androidUI.SetActive(true);
    #endif

        UIMake();
    }

    public void UIMake()
    {
        GameObject CommandPanelGO = deviceUI.transform.GetChild(0).gameObject;
        RectTransform cmdPanelGORt = CommandPanelGO.GetComponent<RectTransform>();
        cmdPanelGORt.anchoredPosition = new Vector3(cmdPanelGORt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);

        GameObject cmdPanelBorder = CommandPanelGO.transform.GetChild(0).gameObject;

        //CmdPanelBorderRt
        RectTransform cmdPanelBorderRt = cmdPanelBorder.GetComponent<RectTransform>();
        cmdPanelBorderRt.anchoredPosition = new Vector3(cmdPanelBorderRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);
        cmdPanelBorderRt.sizeDelta = new Vector2(cmdPanelBorderRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdPanelBorderRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //DeleteRt
        RectTransform deleteRt = cmdPanelBorder.transform.GetChild(0).GetComponent<RectTransform>();
        deleteRt.anchoredPosition = new Vector3(deleteRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);
        deleteRt.sizeDelta = new Vector2(deleteRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, deleteRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //CmdPanelRt
        GameObject cmdPanel = cmdPanelBorder.transform.GetChild(1).gameObject;
        RectTransform cmdPanelRt = cmdPanel.GetComponent<RectTransform>();
        cmdPanelRt.anchoredPosition = new Vector3(cmdPanelRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, cmdPanelRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        cmdPanelRt.sizeDelta = new Vector2(cmdPanelRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdPanelRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup cmdPanelGlg = cmdPanel.GetComponent<GridLayoutGroup>();
        cmdPanelGlg.padding.left = cmdPanelGlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        cmdPanelGlg.padding.top = cmdPanelGlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        cmdPanelGlg.cellSize = new Vector2(cmdPanelGlg.cellSize.x * Screen.width / Configuration.bestScreenWidth, cmdPanelGlg.cellSize.y * Screen.height / Configuration.bestScreenHeight);

        //CmdFactoryGO
        GameObject cmdFactoryGO = cmdPanelBorder.transform.GetChild(2).gameObject;
        RectTransform cmdFactoryGORt = cmdFactoryGO.GetComponent<RectTransform>();
        cmdFactoryGORt.anchoredPosition = new Vector3(cmdFactoryGORt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);
        cmdFactoryGORt.sizeDelta = new Vector2(cmdFactoryGORt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdFactoryGORt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);


        //CmdFactoryBorder
        GameObject cmdFactoryBorder = cmdFactoryGO.transform.GetChild(0).gameObject;
        RectTransform cmdFactoryBorderRt = cmdFactoryBorder.GetComponent<RectTransform>();
        cmdFactoryBorderRt.offsetMin = new Vector2(0, cmdFactoryBorderRt.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
        cmdFactoryBorderRt.offsetMax = new Vector2(0, cmdFactoryBorderRt.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);

        //CmdFactoryBackground
        RectTransform cmdFactoryBackgroundRt = cmdFactoryBorder.transform.GetChild(0).GetComponent<RectTransform>();
        cmdFactoryBackgroundRt.anchoredPosition = new Vector3(cmdFactoryBackgroundRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, cmdFactoryBackgroundRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        cmdFactoryBackgroundRt.sizeDelta = new Vector2(cmdFactoryBackgroundRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdFactoryBackgroundRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //CmdFactory
        GameObject cmdFactory = cmdFactoryBorder.transform.GetChild(1).gameObject;
        RectTransform cmdFactoryRt = cmdFactory.GetComponent<RectTransform>();
        cmdFactoryRt.anchoredPosition = new Vector3(cmdFactoryRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, cmdFactoryRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        cmdFactoryRt.sizeDelta = new Vector2(cmdFactoryRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdFactoryRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup cmdFactoryGlg = cmdFactory.GetComponent<GridLayoutGroup>();
        cmdFactoryGlg.padding.left = cmdFactoryGlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        cmdFactoryGlg.padding.top = cmdFactoryGlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        cmdFactoryGlg.cellSize = new Vector2(cmdFactoryGlg.cellSize.x * Screen.width / Configuration.bestScreenWidth, cmdFactoryGlg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        cmdFactoryGlg.spacing = new Vector2(cmdFactoryGlg.spacing.x * Screen.width / Configuration.bestScreenWidth, 0);

        //ActionMenuGOBackgroundRt
        RectTransform actionMenuGOBackgroundRt = cmdFactoryGO.transform.GetChild(1).GetComponent<RectTransform>();
        actionMenuGOBackgroundRt.sizeDelta = new Vector2(actionMenuGOBackgroundRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, actionMenuGOBackgroundRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        actionMenuGOBackgroundRt.anchoredPosition = new Vector3(0, actionMenuGOBackgroundRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);

        //ActionMenuGO

        GameObject actionMenuGO = cmdFactoryGO.transform.GetChild(2).gameObject;
        RectTransform actionMenuGORt = actionMenuGO.GetComponent<RectTransform>();
        actionMenuGORt.anchoredPosition = new Vector3(actionMenuGORt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, actionMenuGORt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        actionMenuGORt.sizeDelta = new Vector2(actionMenuGORt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, actionMenuGORt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup actionMenuGOGlg = actionMenuGO.GetComponent<GridLayoutGroup>();
        actionMenuGOGlg.padding.left = actionMenuGOGlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        actionMenuGOGlg.padding.top = actionMenuGOGlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        actionMenuGOGlg.cellSize = new Vector2(actionMenuGOGlg.cellSize.x * Screen.width / Configuration.bestScreenWidth, actionMenuGOGlg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        actionMenuGOGlg.spacing = new Vector2(actionMenuGOGlg.spacing.x * Screen.width / Configuration.bestScreenWidth, actionMenuGOGlg.spacing.y * Screen.height / Configuration.bestScreenHeight);

        //Button texts
        for (int i = 0; i < actionMenuGO.transform.childCount; i++)
        {
            actionMenuGO.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = 
                new Vector3(actionMenuGO.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, actionMenuGO.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
            actionMenuGO.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = 
                new Vector2(actionMenuGO.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x * Screen.width / Configuration.bestScreenWidth, actionMenuGO.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y * Screen.height / Configuration.bestScreenHeight);
            actionMenuGO.transform.GetChild(i).GetChild(0).GetComponent<Text>().fontSize = actionMenuGO.transform.GetChild(i).GetChild(0).GetComponent<Text>().fontSize * Screen.height / Configuration.bestScreenHeight;
        }

        //FvPart
        GameObject FvPart = cmdPanelBorder.transform.GetChild(3).gameObject;
        RectTransform fvPartRt = FvPart.GetComponent<RectTransform>();
        fvPartRt.anchoredPosition = new Vector3(fvPartRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, fvPartRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        fvPartRt.sizeDelta = new Vector2(fvPartRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fvPartRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //FvTexts
        Text fv1TextTxt = FvPart.transform.GetChild(0).GetComponent<Text>();
        fv1TextTxt.fontSize = fv1TextTxt.fontSize * Screen.height / Configuration.bestScreenHeight;
        RectTransform fv1TextRt = FvPart.transform.GetChild(0).GetComponent<RectTransform>();
        fv1TextRt.sizeDelta = new Vector2(fv1TextRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv1TextRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        Text fv2TextTxt = FvPart.transform.GetChild(2).GetComponent<Text>();
        fv2TextTxt.fontSize = fv2TextTxt.fontSize * Screen.height / Configuration.bestScreenHeight;
        RectTransform fv2TextRt = FvPart.transform.GetChild(2).GetComponent<RectTransform>();
        fv2TextRt.sizeDelta = new Vector2(fv2TextRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv2TextRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //Fv1GO
        RectTransform fv1Rt = FvPart.transform.GetChild(1).GetComponent<RectTransform>();
        fv1Rt.sizeDelta = new Vector2(fv1Rt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv1Rt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup fv1Glg = FvPart.transform.GetChild(1).GetComponent<GridLayoutGroup>();
        fv1Glg.padding.left = fv1Glg.padding.left * Screen.width / Configuration.bestScreenWidth;
        fv1Glg.padding.top = fv1Glg.padding.top * Screen.height / Configuration.bestScreenHeight;
        fv1Glg.cellSize = new Vector2(fv1Glg.cellSize.x * Screen.width / Configuration.bestScreenWidth, fv1Glg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        fv1Glg.spacing = new Vector2(fv1Glg.spacing.x * Screen.width / Configuration.bestScreenWidth, 0);

        //Fv2GO
        RectTransform fv2Rt = FvPart.transform.GetChild(3).GetComponent<RectTransform>();
        fv2Rt.sizeDelta = new Vector2(fv2Rt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv2Rt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup fv2Glg = FvPart.transform.GetChild(3).GetComponent<GridLayoutGroup>();
        fv2Glg.padding.left = fv2Glg.padding.left * Screen.width / Configuration.bestScreenWidth;
        fv2Glg.padding.top = fv2Glg.padding.top * Screen.height / Configuration.bestScreenHeight;
        fv2Glg.cellSize = new Vector2(fv2Glg.cellSize.x * Screen.width / Configuration.bestScreenWidth, fv2Glg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        fv2Glg.spacing = new Vector2(fv2Glg.spacing.x * Screen.width / Configuration.bestScreenWidth, 0);


    #if UNITY_STANDALONE_WIN
        uniqueUIForWindows();
    #else
        uniqueUIForAndroid();
    #endif
    }

    private void uniqueUIForWindows()
    {
        GameObject mapGuide = deviceUI.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        RectTransform mapGuideRt = mapGuide.GetComponent<RectTransform>();
        mapGuideRt.anchoredPosition = new Vector3(mapGuideRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);
        mapGuideRt.sizeDelta = new Vector2(mapGuideRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, mapGuideRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        Text mapGuideText = mapGuide.transform.GetChild(0).GetComponent<Text>();
        mapGuideText.fontSize = mapGuideText.fontSize * Screen.height / Configuration.bestScreenHeight;
    }

    private void uniqueUIForAndroid()
    {
        GameObject Icons = deviceUI.transform.GetChild(1).gameObject;
        for(int i=0; i<Icons.transform.childCount; i++)
        {
            RectTransform mapGuideRt = Icons.transform.GetChild(i).GetComponent<RectTransform>();
            mapGuideRt.anchoredPosition = new Vector3(mapGuideRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, mapGuideRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
            mapGuideRt.sizeDelta = new Vector2(mapGuideRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, mapGuideRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
            Text mapGuideText = Icons.transform.GetChild(i).GetChild(0).GetComponent<Text>();
            mapGuideText.fontSize = mapGuideText.fontSize * Screen.height / Configuration.bestScreenHeight;
        }
    }
}
