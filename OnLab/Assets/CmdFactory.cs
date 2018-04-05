using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CmdFactory : MonoBehaviour {

    public int[] factoryElementsIds;

    public GameObject factorySlot;
    public GameObject cmdpanelcmd;
    GameObject factoryPanel;

    public List<Command> commands = new List<Command>();
    public List<GameObject> factorySlots = new List<GameObject>();

    // Use this for initialization
    void Start () {
        factoryPanel = GameObject.Find("CommandFactory");

        for(int i=0; i<factoryElementsIds.Length; i++)
        {
        
        
        commands.Add(new Command());
        factorySlots.Add(Instantiate(factorySlot));
        factorySlots[i].transform.SetParent(factoryPanel.transform);
        factorySlots[i].GetComponent<Slot>().id = i;
        factorySlots[i].GetComponent<CreateNewElement>().id = factoryElementsIds[i];
        //AddCommand(new TurnRightCmd(1));
        }
    }

    public void AddCommand(Command it) //  int id
    {
        //PlayerStat.addItem(it);
        Command commandToAdd = it;

        if (commandToAdd.PanelSlot != -1)
        {
            commands[commandToAdd.PanelSlot] = commandToAdd;
            GameObject commandObj = Instantiate(cmdpanelcmd);
            commandObj.transform.SetParent(factorySlots[commandToAdd.PanelSlot].transform);
            commandObj.GetComponent<Image>().sprite = commandToAdd.sprite;
            commandObj.transform.position = commandObj.transform.parent.position;
            commandObj.GetComponent<CommandData>().command = commandToAdd;
            commandObj.GetComponent<CommandData>().slot = commandToAdd.PanelSlot;
        }
        else
        {
            for (int i = 0; i < commands.Count; i++)
            {

                if (commands[i].ID == -1)
                {
                    commands[i] = commandToAdd;
                    commands[i].PanelSlot = i;
                    GameObject itemObj = Instantiate(cmdpanelcmd);
                    itemObj.transform.SetParent(factorySlots[i].transform);
                    itemObj.GetComponent<Image>().sprite = commandToAdd.sprite;
                    itemObj.transform.position = itemObj.transform.parent.position;
                    itemObj.GetComponent<CommandData>().command = commandToAdd;
                    itemObj.GetComponent<CommandData>().slot = i;
                    break;
                }
            }
        }
    }
}
