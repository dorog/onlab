using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class CommandData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject cmdpanel;
    private CanvasGroup canvasGroup;

    public Command Command { get; set; }
    public int CmdPanelSlot { get; set; }

    private readonly string cmdPanelAndroidStr = "CommandPanelAndroid";
    private readonly string cmdPanelWindowsStr = "CommandPanelWindows";

    private CommandPanel cmdPanel;

    void Start()
    {
        cmdPanel = CommandPanel.GetCommandPanel();

        #if UNITY_ANDROID
            GameObject[] cmdpanels = GameObject.FindGameObjectsWithTag(cmdPanelAndroidStr);
        #else
            GameObject[] cmdpanels = GameObject.FindGameObjectsWithTag(cmdPanelWindowsStr);
        #endif

        if (cmdpanels.Length > 1)
        {
        #if UNITY_ANDROID
            Debug.LogWarning("CommandData: There are more than one CommandPanel with " + cmdPanelAndroidStr + " tag, functions may won't work fine!");
        #else
             Debug.LogWarning("CommandData: There are more than one CommandPanel with " + cmdPanelWindowsStr + " tag, functions may won't work fine!");
        #endif
        }
        else if (cmdpanels.Length == 0)
        {
            Debug.LogError("CommandData: There are no CommandPanel");
        }

        if (cmdpanels.Length > 0)
        {
            cmdpanel = cmdpanels[0];
        }

        CmdPanelSlot = Command.PanelSlot;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Command != null)
        {   
            transform.SetParent(cmdpanel.transform.parent.transform);
            transform.position = eventData.position;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Command != null)
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cmdPanel.LastCommandDataPositioning(transform, Command.PanelSlot);
        canvasGroup.blocksRaycasts = true;
    }
}
