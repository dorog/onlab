using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

    public int Id { get; set; }

    protected CommandPanel cmdpanelmanager = null;

    private void Start()
    {
        InitSlot();
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        Transform droppedTransform = eventData.pointerDrag.GetComponent<Transform>();

        if(transform.childCount == 0)
        {
            cmdpanelmanager.ReplaceCommand(Id, droppedTransform);
        }
        else
        {
            CommandData droppedCommand = eventData.pointerDrag.GetComponent<CommandData>();
            if (droppedCommand.Command.PanelSlot == Id)
            {
                return;
            }
            Transform commandplace = transform.GetChild(0);

            cmdpanelmanager.ExchangeCommands(droppedTransform, commandplace);
        }
    }

    protected virtual void InitSlot()
    {
        cmdpanelmanager = CommandPanel.GetCommandPanel();
        if (cmdpanelmanager == null)
        {
            Debug.LogError("Slot: CommandPanel is null!");
        }
    }
}
