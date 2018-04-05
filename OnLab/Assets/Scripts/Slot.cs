using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private CommandPanel cmdpanelmanager;
    public int id;

    void Start()
    {
        cmdpanelmanager = GameObject.Find("CommandPanelManager").GetComponent<CommandPanel>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        CommandData droppedCommand = eventData.pointerDrag.GetComponent<CommandData>();
        if (cmdpanelmanager.commands[id].ID == -1)
        {
            cmdpanelmanager.commands[droppedCommand.slot] = new Command();
            cmdpanelmanager.commands[id] = droppedCommand.command;
            droppedCommand.slot = id;
        }
        else if (droppedCommand.slot != id)
        {
            Transform commandplace = this.transform.GetChild(0);
            commandplace.GetComponent<CommandData>().slot = droppedCommand.slot;
            commandplace.SetParent(cmdpanelmanager.slots[droppedCommand.slot].transform);
            commandplace.transform.position = cmdpanelmanager.slots[droppedCommand.slot].transform.position;

            droppedCommand.slot = id;
            droppedCommand.transform.SetParent(this.transform);
            droppedCommand.transform.position = this.transform.position;

            cmdpanelmanager.commands[droppedCommand.slot] = commandplace.GetComponent<CommandData>().command;
            cmdpanelmanager.commands[id] = droppedCommand.command;
        }
    }
}
