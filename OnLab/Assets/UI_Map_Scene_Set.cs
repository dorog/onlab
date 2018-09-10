using UnityEngine;
using UnityEngine.UI;

public class UI_Map_Scene_Set : MonoBehaviour {

    public RectTransform cmdPanelBorderRt;
    public RectTransform deleteRt;
    public GameObject cmdPanel;
    public RectTransform cmdFactoryBorderRt;
    public RectTransform cmdFactoryBackgroundRt;
    public GameObject cmdFactory;
    public RectTransform actionMenuGOBackgroundRt;
    public GameObject actionMenuGO;
    public Text[] buttonTexts;
    public RectTransform fvPartRt;
    public GameObject fv1Text;
    public GameObject fv2Text;
    public GameObject fv1;
    public GameObject fv2;

	void Start () {

        //CmdPanelBorderRt
        cmdPanelBorderRt.anchoredPosition = new Vector3(cmdPanelBorderRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);
        cmdPanelBorderRt.sizeDelta = new Vector2(cmdPanelBorderRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdPanelBorderRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //DeleteRt
        deleteRt.anchoredPosition = new Vector3(deleteRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, 0, 0);
        deleteRt.sizeDelta = new Vector2(deleteRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, deleteRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //CmdPanelRt
        RectTransform cmdPanelRt = cmdPanel.GetComponent<RectTransform>();
        cmdPanelRt.sizeDelta = new Vector2(cmdPanelRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdPanelRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup cmdPanelGlg = cmdPanel.GetComponent<GridLayoutGroup>();
        cmdPanelGlg.padding.left = cmdPanelGlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        cmdPanelGlg.padding.top = cmdPanelGlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        cmdPanelGlg.cellSize = new Vector2(cmdPanelGlg.cellSize.x * Screen.width / Configuration.bestScreenWidth, cmdPanelGlg.cellSize.y * Screen.height / Configuration.bestScreenHeight);

        //CmdFactoryBorder
        cmdFactoryBorderRt.offsetMin = new Vector2(0, cmdFactoryBorderRt.offsetMin[1] * Screen.height / Configuration.bestScreenHeight);
        cmdFactoryBorderRt.offsetMax = new Vector2(0, cmdFactoryBorderRt.offsetMax[1] * Screen.height / Configuration.bestScreenHeight);

        //CmdFactoryBackground
        cmdFactoryBackgroundRt.anchoredPosition = new Vector3(0, cmdFactoryBackgroundRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        cmdFactoryBackgroundRt.sizeDelta = new Vector2(cmdFactoryBackgroundRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdFactoryBackgroundRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //CmdFactory
        RectTransform cmdFactoryRt = cmdFactory.GetComponent<RectTransform>();
        cmdFactoryRt.anchoredPosition = new Vector3(0, cmdFactoryRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        cmdFactoryRt.sizeDelta = new Vector2(cmdFactoryRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, cmdFactoryRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup cmdFactoryGlg = cmdFactory.GetComponent<GridLayoutGroup>();
        cmdFactoryGlg.padding.left = cmdFactoryGlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        cmdFactoryGlg.padding.top = cmdFactoryGlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        cmdFactoryGlg.cellSize = new Vector2(cmdFactoryGlg.cellSize.x * Screen.width / Configuration.bestScreenWidth, cmdFactoryGlg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        cmdFactoryGlg.spacing = new Vector2(cmdFactoryGlg.spacing.x * Screen.width / Configuration.bestScreenWidth, 0);

        //ActionMenuGOBackgroundRt
        actionMenuGOBackgroundRt.sizeDelta = new Vector2(actionMenuGOBackgroundRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, actionMenuGOBackgroundRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        actionMenuGOBackgroundRt.anchoredPosition = new Vector3(0, actionMenuGOBackgroundRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);

        //ActionMenuGO
        RectTransform actionMenuGORt = actionMenuGO.GetComponent<RectTransform>();
        actionMenuGORt.anchoredPosition = new Vector3(0, actionMenuGORt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);
        actionMenuGORt.sizeDelta = new Vector2(actionMenuGORt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, actionMenuGORt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup actionMenuGOGlg = actionMenuGO.GetComponent<GridLayoutGroup>();
        actionMenuGOGlg.padding.left = actionMenuGOGlg.padding.left * Screen.width / Configuration.bestScreenWidth;
        actionMenuGOGlg.padding.top = actionMenuGOGlg.padding.top * Screen.height / Configuration.bestScreenHeight;
        actionMenuGOGlg.cellSize = new Vector2(actionMenuGOGlg.cellSize.x * Screen.width / Configuration.bestScreenWidth, actionMenuGOGlg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        actionMenuGOGlg.spacing = new Vector2(actionMenuGOGlg.spacing.x * Screen.width / Configuration.bestScreenWidth, actionMenuGOGlg.spacing.y * Screen.height / Configuration.bestScreenHeight);

        //Button texts
        for(int i=0; i<buttonTexts.Length; i++)
        {
            buttonTexts[i].fontSize = buttonTexts[i].fontSize * Screen.height / Configuration.bestScreenHeight;
        }

        //FvPart
        fvPartRt.anchoredPosition = new Vector3(fvPartRt.anchoredPosition.x * Screen.width / Configuration.bestScreenWidth, fvPartRt.anchoredPosition.y * Screen.height / Configuration.bestScreenHeight, 0);

        //FvTexts
        Text fv1TextTxt = fv1Text.GetComponent<Text>();
        fv1TextTxt.fontSize = fv1TextTxt.fontSize * Screen.height / Configuration.bestScreenHeight;
        RectTransform fv1TextRt = fv1Text.GetComponent<RectTransform>();
        fv1TextRt.sizeDelta = new Vector2(fv1TextRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv1TextRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        Text fv2TextTxt = fv2Text.GetComponent<Text>();
        fv2TextTxt.fontSize = fv2TextTxt.fontSize * Screen.height / Configuration.bestScreenHeight;
        RectTransform fv2TextRt = fv2Text.GetComponent<RectTransform>();
        fv2TextRt.sizeDelta = new Vector2(fv2TextRt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv2TextRt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);

        //Fv1GO
        RectTransform fv1Rt = fv1.GetComponent<RectTransform>();
        fv1Rt.sizeDelta = new Vector2(fv1Rt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv1Rt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup fv1Glg = fv1.GetComponent<GridLayoutGroup>();
        fv1Glg.padding.left = fv1Glg.padding.left * Screen.width / Configuration.bestScreenWidth;
        fv1Glg.padding.top = fv1Glg.padding.top * Screen.height / Configuration.bestScreenHeight;
        fv1Glg.cellSize = new Vector2(fv1Glg.cellSize.x * Screen.width / Configuration.bestScreenWidth, fv1Glg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        fv1Glg.spacing = new Vector2(fv1Glg.spacing.x * Screen.width / Configuration.bestScreenWidth, 0);

        //Fv2GO
        RectTransform fv2Rt = fv2.GetComponent<RectTransform>();
        fv2Rt.sizeDelta = new Vector2(fv2Rt.sizeDelta[0] * Screen.width / Configuration.bestScreenWidth, fv2Rt.sizeDelta[1] * Screen.height / Configuration.bestScreenHeight);
        GridLayoutGroup fv2Glg = fv2.GetComponent<GridLayoutGroup>();
        fv2Glg.padding.left = fv2Glg.padding.left * Screen.width / Configuration.bestScreenWidth;
        fv2Glg.padding.top = fv2Glg.padding.top * Screen.height / Configuration.bestScreenHeight;
        fv2Glg.cellSize = new Vector2(fv2Glg.cellSize.x * Screen.width / Configuration.bestScreenWidth, fv2Glg.cellSize.y * Screen.height / Configuration.bestScreenHeight);
        fv2Glg.spacing = new Vector2(fv2Glg.spacing.x * Screen.width / Configuration.bestScreenWidth, 0);
    }
}
