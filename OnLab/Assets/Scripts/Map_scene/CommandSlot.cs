using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CommandSlot : Slot, IPointerClickHandler
{
    [SerializeField]
    private GameObject cmdpanelcmd;

    [SerializeField]
    [Tooltip ("Scale value of the child (command)")]
    private float commandScaleValue = 0.8f;

    void Start()
    {
        InitSlot();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.childCount > 0 && CommandFactory.chosenCommand != CommandType.Null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        Command element;

        switch (CommandFactory.chosenCommand)
        {
            case CommandType.GoForward:
                element = new GoForwardCmd(Id);
                break;
            case CommandType.TurnRight:
                element = new TurnRightCmd(Id);
                break;
            case CommandType.TurnLeft:
                element = new TurnLeftCmd(Id);
                break;
            case CommandType.Activate:
                element = new ActivateCmd(Id);
                break;
            case CommandType.FV1:
                element = new FV(Id, 1);
                break;
            case CommandType.FV2:
                element = new FV(Id, 2);
                break;
            default:
                return;
        }

        GameObject commandObj = Instantiate(cmdpanelcmd);
        commandObj.transform.SetParent(transform);
        commandObj.GetComponent<Image>().sprite = element.Img;
        commandObj.transform.position = commandObj.transform.parent.position;
        CommandData cmd = commandObj.GetComponent<CommandData>();
        cmd.Command = element;

        cmdpanelmanager.AddCommand(Id, element);

        RectTransform rt = commandObj.GetComponent<RectTransform>();
        RectTransform slotRt = GetComponent<RectTransform>();
        rt.sizeDelta = slotRt.sizeDelta * commandScaleValue;
        rt.localScale = new Vector3(1, 1, 1);
    }

    protected override void InitSlot()
    {
        base.InitSlot();
        if (cmdpanelcmd.GetComponent<Image>() == null)
        {
            Debug.LogError("CreateNewCmdOnSlot: cmdpanelcmd has to have Image component!");
        }
        if (cmdpanelcmd.GetComponent<CommandData>() == null)
        {
            Debug.LogError("CreateNewCmdOnSlot: cmdpanelcmd has to have CommandData scipt!");
        }
    }
}
