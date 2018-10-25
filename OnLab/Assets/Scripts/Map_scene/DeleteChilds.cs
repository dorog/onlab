using UnityEngine;

public class DeleteChilds : MonoBehaviour {

    private CommandPanel commandPanel;

    private void Start()
    {
        commandPanel = CommandPanel.GetCommandPanel();
    }

    void Update () {
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
            
            commandPanel.DeleteCommandBySlot(slotNumber);

            Destroy(child.gameObject);
        }
    }
}
