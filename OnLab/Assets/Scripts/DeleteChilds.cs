using UnityEngine;

public class DeleteChilds : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (this.transform.childCount > 0)
        {
            Transform child = this.transform.GetChild(0);
            int slotNumber = child.GetComponent<CommandData>().slot;
            GameObject commandPanel = GameObject.Find(Configuration.cmdPanelManagerName);
            commandPanel.GetComponent<CommandPanel>().deleteCommandBySlot(slotNumber);

            GameObject.Destroy(child.gameObject);
        }
    }
}
