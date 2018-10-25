using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slot))]
[RequireComponent(typeof(RectTransform))]
public class CreateNewCmdOnSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject cmdpanelcmd;

    [SerializeField]
    [Tooltip ("Scale value of the child (command)")]
    private float commandScaleValue = 0.8f;

    private CommandPanel cmdpanelmanager;

    void Start()
    {
        cmdpanelmanager = CommandPanel.GetCommandPanel();
        if (cmdpanelcmd.GetComponent<RectTransform>() == null)
        {
            Debug.LogError("CreateNewCmdOnSlot: cmdpanelcmd has to have RectTransform!");
        }
        if (cmdpanelcmd.GetComponent<Image>() == null)
        {
            Debug.LogError("CreateNewCmdOnSlot: cmdpanelcmd has to have Image component!");
        }
        if (cmdpanelcmd.GetComponent<CommandData>() == null)
        {
            Debug.LogError("CreateNewCmdOnSlot: cmdpanelcmd has to have CommandData scipt!");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(transform.childCount > 0 && ActualMapData.chosenCommand != CommandType.Null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        Command element;

        int panelSlot = GetComponent<Slot>().Id;

        switch (ActualMapData.chosenCommand)
        {
            case CommandType.GoForward:
                element = new GoForwardCmd(panelSlot);
                break;
            case CommandType.TurnRight:
                element = new TurnRightCmd(panelSlot);
                break;
            case CommandType.TurnLeft:
                element = new TurnLeftCmd(panelSlot);
                break;
            case CommandType.Activate:
                element = new ActivateCmd(panelSlot);
                break;
            case CommandType.FV1:
                element = new FV(panelSlot, 1);
                break;
            case CommandType.FV2:
                element = new FV(panelSlot, 2);
                break;
            default:
                return;
        }

        GameObject commandObj = Instantiate(cmdpanelcmd);
        commandObj.transform.SetParent(transform);
        commandObj.GetComponent<Image>().sprite = element.Sprite;
        commandObj.transform.position = commandObj.transform.parent.position;
        CommandData cmd = commandObj.GetComponent<CommandData>();
        cmd.Command = element;

        cmdpanelmanager.AddCommand(panelSlot, element);

        RectTransform rt = commandObj.GetComponent<RectTransform>();
        RectTransform slotRt = GetComponent<RectTransform>();
        rt.sizeDelta = slotRt.sizeDelta*commandScaleValue;
        rt.localScale = new Vector3(1, 1, 1);
    }
}
