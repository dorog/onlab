using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private CommandPanel cmdpanelmanager;

    public int Id { get; set; }

    void Start()
    {
        cmdpanelmanager = CommandPanel.GetCommandPanel();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Transform droppedTransform = eventData.pointerDrag.GetComponent<Transform>();

        if(cmdpanelmanager.GetCommandID(Id) == SharedData.emptyCommandID)
        {
            cmdpanelmanager.ReplaceCommand(Id, droppedTransform);
        }
        else
        {
            CommandData droppedCommand = eventData.pointerDrag.GetComponent<CommandData>();
            if (droppedCommand.Command.PanelSlot == Id){
                return;
            }
            Transform commandplace = transform.GetChild(0);

            cmdpanelmanager.ExchangeCommands(droppedTransform, commandplace);
        }
    }
}
