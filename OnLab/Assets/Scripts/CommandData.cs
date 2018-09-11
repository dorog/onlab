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
        cmdpanelmanager = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
        cmdpanel = GameObject.Find(Configuration.cmdPanelName);
        //tooltip = inv.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (command != null)
        {   
            //cmd panel will be a parent
            this.transform.SetParent(cmdpanel.transform.parent.transform); // + .parent.transform
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
