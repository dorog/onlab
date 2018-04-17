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

    public int slotAmount = 48; //49 now
    public List<Command> commands = new List<Command>();
    public List<GameObject> slots = new List<GameObject>();
    public int fv1_Counts = 10;
    public int fv2_Counts = 10;

    public int summSlots = 0;

    void Start()
    {
        commandPanel = GameObject.Find("CommandPanelBorder");
        slotPanel = commandPanel.transform.Find("CommandPanel").gameObject;

        summSlots = fv1_Counts + fv2_Counts + slotAmount;
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

        //New, check it


        for (int i=slotAmount; i<slotAmount+fv1_Counts; i++)
        {
            commands.Add(new Command());
            slots.Add(Instantiate(cmdSlot));
            slots[i].transform.SetParent(commandPanel.transform.GetChild(3));
            slots[i].GetComponent<Slot>().id = i;
        }

        for(int i=slotAmount+fv1_Counts; i<slotAmount+fv1_Counts+fv2_Counts; i++)
        {
            commands.Add(new Command());
            slots.Add(Instantiate(cmdSlot));
            slots[i].transform.SetParent(commandPanel.transform.GetChild(4));
            slots[i].GetComponent<Slot>().id = i;
        }
        //

        //delete slot
        commands.Add(new Command());
        slots.Add(Instantiate(deleteSlot));
        slots[slotAmount+fv1_Counts+fv2_Counts].transform.SetParent(slotPanel.transform);
        slots[slotAmount+fv1_Counts+fv2_Counts].GetComponent<Slot>().id = slotAmount + fv1_Counts + fv2_Counts;
        // change: +fv1 + fv2
        /*for(int i=0; i<commands.Count; i++)
        {
            Debug.Log(commands[i].ID + " " + commands[i].PanelSlot);
        }
        Debug.Log(slots.Count);
        Debug.Log(commands.Count);*/
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

        for(int i=0; i<commandPanel.transform.GetChild(3).childCount; i++)
        {
            if (commandPanel.transform.GetChild(3).transform.GetChild(i).childCount>0)
            {
                GameObject.Destroy(commandPanel.transform.GetChild(3).transform.GetChild(i).GetChild(0).gameObject);
            }
            GameObject.Destroy(commandPanel.transform.GetChild(3).transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < commandPanel.transform.GetChild(4).childCount; i++)
        {
            if (commandPanel.transform.GetChild(4).transform.GetChild(i).childCount > 0)
            {
                GameObject.Destroy(commandPanel.transform.GetChild(4).transform.GetChild(i).GetChild(0).gameObject);
            }
            GameObject.Destroy(commandPanel.transform.GetChild(4).transform.GetChild(i).gameObject);
        }

        cmdLoad();
    }

    public void deleteCommandBySlot(int slotNumber)
    {
        //it's rly dangereous, be careful with it
        //it works cuz last slot is a delete slot
        commands.RemoveAt(slotAmount+fv1_Counts+fv2_Counts);

        commands.Add(new Command());
    }

    public List<Command> getRealCommands()
    {
        List<Command> RealCmds = new List<Command>();
        for(int i=0; i<slotAmount; i++)
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
