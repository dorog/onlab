using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateNewCmdOnSlot : MonoBehaviour, IPointerClickHandler
{

    public GameObject cmdpanelcmd;

    CommandPanel cmdpanelmanager;
    public float sizeValue = 0.8f;

    void Start()
    {
        cmdpanelmanager = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(this.transform.childCount > 0 && Configuration.chosenCommand != Configuration.CommandType.Null)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }
        Command element;

        switch (Configuration.chosenCommand)
        {
            case Configuration.CommandType.GoForward:
                element = new GoForwardCmd(1);
                break;
            case Configuration.CommandType.TurnRight:
                element = new TurnRightCmd(1);
                break;
            case Configuration.CommandType.TurnLeft:
                element = new TurnLeftCmd(1);
                break;
            case Configuration.CommandType.Activate:
                element = new ActivateCmd(1);
                break;
            case Configuration.CommandType.FV1:
                element = new FV(1, 1);
                break;
            case Configuration.CommandType.FV2:
                element = new FV(1, 2);
                break;
            default:
                return;
        }

        int id = this.GetComponent<Slot>().id;

        GameObject commandObj = Instantiate(cmdpanelcmd);
        commandObj.transform.SetParent(this.transform);
        commandObj.GetComponent<Image>().sprite = element.sprite;
        commandObj.transform.position = commandObj.transform.parent.position;
        commandObj.GetComponent<CommandData>().command = element;
        commandObj.GetComponent<CommandData>().slot = id;
        commandObj.GetComponent<CommandData>().command.PanelSlot = id;

        cmdpanelmanager.commands[id] = element;

        RectTransform rt = commandObj.GetComponent<RectTransform>();
        RectTransform slotRt = this.GetComponent<RectTransform>();
        rt.sizeDelta = slotRt.sizeDelta*sizeValue; 
    }
}
