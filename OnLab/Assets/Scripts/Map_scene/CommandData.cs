using UnityEngine;
using UnityEngine.EventSystems;

public class CommandData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Command command;
    public int slot;

    private CommandPanel cmdpanelmanager;
    private GameObject cmdpanel;

    void Start()
    {
        cmdpanelmanager = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
        cmdpanel = GameObject.Find(Configuration.cmdPanelName);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (command != null)
        {   
            this.transform.SetParent(cmdpanel.transform.parent.transform);
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
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
