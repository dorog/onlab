using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPanel : MonoBehaviour {

    //public CharacterPorperties charInventory;
    GameObject commandPanel;
    GameObject slotPanel;
    public GameObject cmdSlot;
    public GameObject deleteSlot;
    public GameObject cmdpanelcmd;
    public GameObject factoryElement;

    public int slotAmount = 48;
    public List<Command> commands = new List<Command>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        commandPanel = GameObject.Find("CommandPanelBorder");
        slotPanel = commandPanel.transform.Find("CommandPanel").gameObject;

        //items load
        cmdLoad();
    }

    public void AddCommand(Command it) 
    {
        Command commandToAdd = it;

        if (commandToAdd.PanelSlot != -1)
        {
            commands[commandToAdd.PanelSlot] = commandToAdd;
            GameObject commandObj = Instantiate(cmdpanelcmd);
            commandObj.transform.SetParent(slots[commandToAdd.PanelSlot].transform);
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
                    GameObject commandObj = Instantiate(cmdpanelcmd);
                    commandObj.transform.SetParent(slots[i].transform);
                    commandObj.GetComponent<Image>().sprite = commandToAdd.sprite;
                    commandObj.transform.position = commandObj.transform.parent.position;
                    commandObj.GetComponent<CommandData>().command = commandToAdd;
                    commandObj.GetComponent<CommandData>().slot = i;
                    break;
                }
            }
        }
    }

    void cmdLoad()
    {

        for (int i = 0; i < slotAmount; i++)
        {
            commands.Add(new Command());
            slots.Add(Instantiate(cmdSlot));
            slots[i].transform.SetParent(slotPanel.transform);
            slots[i].GetComponent<Slot>().id = i;
        }

        //delete slot
        commands.Add(new Command());
        slots.Add(Instantiate(deleteSlot));
        slots[slotAmount].transform.SetParent(slotPanel.transform);
        slots[slotAmount].GetComponent<Slot>().id = slotAmount;
    }

    public void Clear()
    {
        
        commands.Clear();
        slots.Clear();
        for(int i=0; i< slotPanel.transform.childCount; i++)
        {
            if (slotPanel.transform.GetChild(i).childCount > 0)
            {
                GameObject.Destroy(slotPanel.transform.GetChild(i).GetChild(0).gameObject);
            }
            GameObject.Destroy(slotPanel.transform.GetChild(i).gameObject);
        }
        cmdLoad();
    }

    public void deleteCommandBySlot(int slotNumber)
    {
        //it's rly dangereous, be careful with it
        //it works cuz last slot is a delete slot
        commands.RemoveAt(slotAmount);

        commands.Add(new Command());
    }

    public List<Command> getRealCommands()
    {
        List<Command> RealCmds = new List<Command>();
        for(int i=0; i<commands.Count; i++)
        {
            if (commands[i].ID != -1)
            {
                RealCmds.Add(commands[i]);
            }
        }
        return RealCmds;
    }

    public int getRealCommandsNumber()
    {
        int db = 0;
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i].ID != -1)
            {
                db++;
            }
        }
        return db;
    }
}
