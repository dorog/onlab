﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPanel : MonoBehaviour {

    //public CharacterPorperties charInventory;
    GameObject commandPanelBorder;
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

    private int delete_number = 0;
    private int base_number = 2;
    private int fv1_number = 5;
    private int fv2_number = 6;

    void Start()
    {
        commandPanelBorder = GameObject.Find("CommandPanelBorder");
        slotPanel = commandPanelBorder.transform.Find("CommandPanel").gameObject;

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

        /*commands.Add(new Command());
        slots.Add(Instantiate(deleteSlot));
        slots[0].transform.SetParent(commandPanelBorder.transform.GetChild(delete_number));
        slots[0].GetComponent<Slot>().id = 0; // summ -> 0*/

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
            slots[i].transform.SetParent(commandPanelBorder.transform.GetChild(fv1_number));
            slots[i].GetComponent<Slot>().id = i;
        }

        for(int i=slotAmount+fv1_Counts; i<slotAmount+fv1_Counts+fv2_Counts; i++)
        {
            commands.Add(new Command());
            slots.Add(Instantiate(cmdSlot));
            slots[i].transform.SetParent(commandPanelBorder.transform.GetChild(fv2_number));
            slots[i].GetComponent<Slot>().id = i;
        }
        //

        //delete slot
        commands.Add(new Command());
        slots.Add(Instantiate(deleteSlot));
        
        slots[summSlots].transform.SetParent(commandPanelBorder.transform.GetChild(delete_number));
        slots[summSlots].GetComponent<Slot>().id = summSlots;
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

        for(int i=0; i<commandPanelBorder.transform.GetChild(fv1_number).childCount; i++)
        {
            if (commandPanelBorder.transform.GetChild(fv1_number).transform.GetChild(i).childCount>0)
            {
                GameObject.Destroy(commandPanelBorder.transform.GetChild(fv1_number).transform.GetChild(i).GetChild(0).gameObject);
            }
            GameObject.Destroy(commandPanelBorder.transform.GetChild(fv1_number).transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < commandPanelBorder.transform.GetChild(fv2_number).childCount; i++)
        {
            if (commandPanelBorder.transform.GetChild(fv2_number).transform.GetChild(i).childCount > 0)
            {
                GameObject.Destroy(commandPanelBorder.transform.GetChild(fv2_number).transform.GetChild(i).GetChild(0).gameObject);
            }
            GameObject.Destroy(commandPanelBorder.transform.GetChild(fv2_number).transform.GetChild(i).gameObject);
        }

        cmdLoad();
    }

    public void deleteCommandBySlot(int slotNumber)
    {
        //it's rly dangereous, be careful with it
        //it works cuz last slot is a delete slot
        //update: first element
        commands.RemoveAt(slotNumber);
        //commands[0].Effect();
        commands.Add(new Command());
    }

    public List<Command> getRealCommands(List<Command> fv1, List<Command> fv2)
    {
        List<Command> RealCmds = new List<Command>();
        for(int i=0; i<slotAmount; i++)
        {
            if (commands[i].ID != -1)
            {
                RealCmds.Add(commands[i]);
                
            }
        }

        for(int i=slotAmount; i<slotAmount+fv1_Counts; i++)
        {
            if (commands[i].ID != -1)
            {
                fv1.Add(commands[i]);
            }
        }

        for (int i = slotAmount+fv1_Counts; i < slotAmount + fv1_Counts+fv2_Counts; i++)
        {
            if (commands[i].ID != -1)
            {
                fv2.Add(commands[i]);
            }
        }

        return RealCmds;
    }

    // delete it
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
