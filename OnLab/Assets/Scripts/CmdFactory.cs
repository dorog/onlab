using System.Collections.Generic;
using UnityEngine;

public class CmdFactory : MonoBehaviour {

    public int[] factoryElementsIds;
   
    public GameObject factorySlot;
    public GameObject cmdpanelcmd;
    public string charName;
    GameObject factoryPanel;

    public List<Command> commands = new List<Command>();
    public List<GameObject> factorySlots = new List<GameObject>();

    // Use this for initialization
    void Start () {
        factoryPanel = GameObject.Find(Configuration.cmdFactoryName);
        CommandPanel cmdPanel = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();

        for (int i = 0; i < factoryElementsIds.Length; i++)
        {
            commands.Add(new Command());
            factorySlots.Add(Instantiate(factorySlot));
            factorySlots[i].transform.SetParent(factoryPanel.transform);
            factorySlots[i].GetComponent<Slot>().id = cmdPanel.summSlots; // change: .slotamount update: cmdPanel.summSlots
            factorySlots[i].GetComponent<CreateNewElement>().id = factoryElementsIds[i];
            //factorySlots[i].GetComponent<CreateNewElement>().charName = charName;
        }
    }
}
