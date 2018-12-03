using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteSlot : Slot {	

    private void Start()
    {
        InitSlot();
    }

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);

        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);

            CommandData cmdData = child.GetComponent<CommandData>();
            if (cmdData == null)
            {
                Debug.LogError("DeleteChilds: No commandData on the child!");
                return;
            }
            int slotNumber = cmdData.Command.PanelSlot;

            cmdpanelmanager.DeleteCommandBySlot(slotNumber);

            Destroy(child.gameObject);
        }
    }
}
