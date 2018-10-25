using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPanel : MonoBehaviour {

    private static CommandPanel instance = null;

    [Header("GameObjects for slots")]
    [SerializeField]
    private GameObject commandPanel;
    [SerializeField]
    private GameObject cmdSlot;
    [SerializeField]
    private GameObject deleteSlot;
    [SerializeField]
    private GameObject cmdpanelcmd;
    [SerializeField]
    private GameObject factoryElement;

    [Header("Slots' count")]
    [SerializeField]
    [Tooltip("Main function's count")]
    private int mainCount = 48;
    private List<Command> commands = new List<Command>();
    private List<GameObject> slots = new List<GameObject>();
    [SerializeField]
    private int fv1Count = 10;
    [SerializeField]
    private int fv2Count = 10;

    private int summSlots = 0;

    [Header("GameObject for Instantiate")]
    [SerializeField]
    private GameObject deleteGO;
    [SerializeField]
    private GameObject fv1GO;
    [SerializeField]
    private GameObject fv2GO;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        summSlots = fv1Count + fv2Count + mainCount;
        CmdLoad();
    }

    public static CommandPanel GetCommandPanel()
    {
        return instance;
    }

    void Start()
    {
    }

    void CmdLoad()
    {
        for (int i = 0; i < mainCount; i++)
        {
            commands.Add(new Command());
            slots.Add(Instantiate(cmdSlot));
            slots[i].transform.SetParent(commandPanel.transform);
            slots[i].GetComponent<Slot>().Id = i;
        }

        for (int i=mainCount; i<mainCount+fv1Count; i++)
        {
            commands.Add(new Command());
            slots.Add(Instantiate(cmdSlot));
            slots[i].transform.SetParent(fv1GO.transform);
            slots[i].GetComponent<Slot>().Id = i;
            #if UNITY_ANDROID
                slots[i].GetComponent<Image>().enabled = false;
            #endif
        }

        for (int i=mainCount+fv1Count; i<mainCount+fv1Count+fv2Count; i++)
        {
            commands.Add(new Command());
            slots.Add(Instantiate(cmdSlot));
            slots[i].transform.SetParent(fv2GO.transform);
            slots[i].GetComponent<Slot>().Id = i;
            #if UNITY_ANDROID
                slots[i].GetComponent<Image>().enabled = false;
            #endif
        }

        for(int i=0; i<slots.Count; i++)
        {
            slots[i].transform.localScale = new Vector3(1, 1, 1);
        }

        //delete slot
        if(deleteGO.transform.childCount > 0)
        {
            return;
        }
        commands.Add(new Command());

        slots.Add(Instantiate(deleteSlot, deleteGO.transform));
        
        slots[summSlots].GetComponent<Slot>().Id = summSlots;
    }

    public void Clear()
    {
        
        commands.Clear();
        slots.Clear();
        for(int i=0; i< commandPanel.transform.childCount; i++)
        {
            if (commandPanel.transform.GetChild(i).childCount > 0)
            {
                Destroy(commandPanel.transform.GetChild(i).GetChild(0).gameObject);
            }
            Destroy(commandPanel.transform.GetChild(i).gameObject);
        }

        for(int i=0; i< fv1GO.transform.childCount; i++)
        {
            if (fv1GO.transform.GetChild(i).childCount>0)
            {
                Destroy(fv1GO.transform.GetChild(i).GetChild(0).gameObject);
            }
            Destroy(fv1GO.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < fv2GO.transform.childCount; i++)
        {
            if (fv2GO.transform.GetChild(i).childCount > 0)
            {
                Destroy(fv2GO.transform.GetChild(i).GetChild(0).gameObject);
            }
            Destroy(fv2GO.transform.GetChild(i).gameObject);
        }

        CmdLoad();
    }

    public void DeleteCommandBySlot(int slotNumber)
    {
        commands.RemoveAt(slotNumber);
        commands.Add(new Command());
    }

    public List<Command> GetRealCommands(List<Command> fv1, List<Command> fv2)
    {
        List<Command> RealCmds = new List<Command>();
        for(int i=0; i<mainCount; i++)
        {
            if (commands[i].ID != -1)
            {
                RealCmds.Add(commands[i]);
                
            }
        }

        for(int i=mainCount; i<mainCount+fv1Count; i++)
        {
            if (commands[i].ID != -1)
            {
                fv1.Add(commands[i]);
            }
        }

        for (int i = mainCount+fv1Count; i < mainCount + fv1Count+fv2Count; i++)
        {
            if (commands[i].ID != -1)
            {
                fv2.Add(commands[i]);
            }
        }

        return RealCmds;
    }

    public int GetRealCommandsNumber()
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

    public int GetCommandID(int id)
    {
        return commands[id].ID;
    }

    public void ReplaceCommand(int id, Transform droppedCommandTransform)
    {
        CommandData droppedCommandData = droppedCommandTransform.GetComponent<CommandData>();

        commands[droppedCommandData.Command.PanelSlot] = new Command();
        commands[id] = droppedCommandData.Command;
        droppedCommandData.Command.PanelSlot = id;

        droppedCommandTransform.SetParent(slots[droppedCommandData.Command.PanelSlot].transform);
        droppedCommandTransform.position = slots[droppedCommandData.Command.PanelSlot].transform.position;
    }

    public void ExchangeCommands(Transform droppedTransform, Transform wasThereTransform)
    {
        CommandData dropped = droppedTransform.GetComponent<CommandData>();
        CommandData wasThere = wasThereTransform.GetComponent<CommandData>();
        int forChange = wasThere.Command.PanelSlot;

        wasThere.Command.PanelSlot = dropped.Command.PanelSlot;
        wasThereTransform.SetParent(slots[dropped.Command.PanelSlot].transform);
        wasThereTransform.transform.position = slots[dropped.Command.PanelSlot].transform.position;

        dropped.Command.PanelSlot = forChange;

        commands[wasThere.Command.PanelSlot] = wasThere.Command;
        commands[forChange] = dropped.Command;

        droppedTransform.SetParent(slots[dropped.Command.PanelSlot].transform);
        droppedTransform.position = slots[dropped.Command.PanelSlot].transform.position;
    }

    public void LastCommandDataPositioning(Transform trans, int slotNumber)
    {
        trans.SetParent(slots[slotNumber].transform);
        trans.position = slots[slotNumber].transform.position;
    }

    public void AddCommand(int panelSlot, Command element)
    {
        commands[panelSlot] = element;
    }
}
