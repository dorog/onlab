using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommandData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Command command;
    public int slot;

    private CommandPanel cmdpanelmanager;
    private GameObject cmdpanel;
    //private Tooltip tooltip;

    void Start()
    {
        cmdpanelmanager = GameObject.Find("CommandPanelManager").GetComponent<CommandPanel>();
        cmdpanel = GameObject.Find("CommandPanel");
        //tooltip = inv.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (command != null)
        {
            //this.transform.SetParent(this.transform.parent.parent);


            //commands from factroy havent got slot, i must give them one

            /*if (command.newcmd)
            {

                //Solution 1. 
                //Last item must be a deleteslot
                this.transform.GetComponent<CommandData>().slot = cmdpanelmanager.slotAmount;
                command.ID = cmdpanelmanager.slotAmount;
                command.newcmd = false;
                cmdpanelmanager.commands.Add(command);
                //End 

            }*/
            
            //cmd panel will be a parent
            this.transform.SetParent(cmdpanel.transform);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (command != null)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(cmdpanelmanager.slots[slot].transform);
        this.transform.position = cmdpanelmanager.slots[slot].transform.position;
        command.PanelSlot = slot;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //tooltip.Deactivate();
    }
}
