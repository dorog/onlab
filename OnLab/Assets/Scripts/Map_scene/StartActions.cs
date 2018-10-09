using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartActions : MonoBehaviour
{
    public float EndWait = 2;
    CommandPanel cmdPanel;
    private GameObject commandPanelGO;
    private GameObject fv1GO;
    private GameObject fv2GO;
    static int aimnumber = 0;
    private Transform lastSwitchedOff;

    public bool start = false;
    List<Command> commandsForExecute = new List<Command>();

    List<Command> fv1 = new List<Command>();

    List<Command> fv2 = new List<Command>();

    GameObject character;
    private bool die = false;

    private float effectTime = Configuration.timeForAnimation;


    private int executedCommands = 0;


    public Button actionBtn;
    public Button stopBtn;
    public Button clearBtn;
    MapGenerator mapGen;

    void Start()
    {
        fv1GO = GameObject.Find(Configuration.fv1Name);
        fv2GO = GameObject.Find(Configuration.fv2Name);
        commandPanelGO = GameObject.Find(Configuration.cmdPanelName);
        cmdPanel = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
        character = GameObject.Find(Configuration.characterName);
        mapGen = GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>();

        actionBtn.interactable = true;
        stopBtn.interactable = false;
        clearBtn.interactable = true;
    }

    public void ExecuteCommands()
    {
        start = true;
        die = false;
        commandsForExecute.Clear();
        fv1.Clear();
        fv2.Clear();
        commandsForExecute = cmdPanel.getRealCommands(fv1, fv2);

        character.GetComponent<JoeCommandControl>().stopped = false;
        aimnumber = 0;
        executedCommands = 0;
        Configuration.fallDistance = 0;
        Configuration.inStart = true;
        actionBtn.interactable = false;
        stopBtn.interactable = true;
        lastSwitchedOff = null;
        LockUI(false);
        Invoke("ExecuteCmd", 0);
    }

    public void KilledByTrap(float rTime)
    {
        die = true;
        Invoke("WaitBeforeEnd", rTime);
    }

    public void StopButtonOnClick()
    {
        stopBtn.interactable = false;
        aimnumber = commandsForExecute.Count;
    }

    public void FvStart(int fvNumber)
    {
        int fv_Count = 0;
        List<Command> fvElements; 
        if(fvNumber == 1)
        {
            fv_Count = fv1.Count;
            fvElements = fv1;
        }
        else
        {
            fv_Count = fv2.Count;
            fvElements = fv2;
        }

        if (fv_Count != 0)
        {
            int afterAim = commandsForExecute.Count - aimnumber - 1;
            int count = commandsForExecute.Count - 1;
            for (int i = 0; i < fv_Count-1; i++)
            {
                commandsForExecute.Add(new Command());
            }

            int lastPlace = count + fv_Count - 1;
            for (int i = 0; i < afterAim; i++)
            {
                commandsForExecute[lastPlace - i] = commandsForExecute[aimnumber + afterAim - i];
            }

            for (int i = 0; i < fv_Count; i++)
            {
                commandsForExecute[aimnumber + i] = fvElements[i];
            }
            commandsForExecute[aimnumber].Effect();
            LightUp();
        }
        else if (fv_Count == 0 && aimnumber == commandsForExecute.Count - 1)
        {
            Invoke("WaitBeforeEnd", EndWait);
        }
    }

    private void NotStaticBack()
    {
        mapGen.RestartMap(CurrentGameDatas.mapNumber);
    }

    private void ExecuteCmd()
    {
        if (die)
        {
            SwitchOffLastLightedUp(null);
            LockUI(true);
            return;
        }
        if(commandsForExecute.Count > aimnumber)
        {
            LightUp();
            commandsForExecute[aimnumber].Effect();
            aimnumber++;
            executedCommands++;
            float fallTime = Mathf.Pow((Configuration.fallDistance / 2 / -Physics.gravity.y), 0.5f);
            Invoke("ExecuteCmd", Configuration.TimeBetweenCmds + effectTime + fallTime*Configuration.fallSpeedBoost);
        }
        else
        {
            Invoke("WaitBeforeEnd", EndWait);
        }
    }

    private void WaitBeforeEnd()
    {
        SwitchOffLastLightedUp(null);

        //If trap kill it this code reset the animation
        Animator anim = character.GetComponent<Animator>();
        anim.SetBool(Configuration.trapAnimation, false);
        character.GetComponent<JoeCommandControl>().stopped = true;

        aimnumber = 0;
        NotStaticBack();
        actionBtn.interactable = true;
        stopBtn.interactable = false;
        LockUI(true);
    }

    private void LightUp()
    {
        //Main thread
        if(commandsForExecute[aimnumber].PanelSlot < commandPanelGO.transform.childCount)
        {
            Transform forExecute = commandPanelGO.transform.GetChild(commandsForExecute[aimnumber].PanelSlot).transform.GetChild(0);
            forExecute.GetComponent<Image>().color = Color.red;
            SwitchOffLastLightedUp(forExecute);
        }
        //Fv1
        else if(commandsForExecute[aimnumber].PanelSlot < commandPanelGO.transform.childCount + cmdPanel.fv1_Counts)
        {
            Transform forExecuteF1= fv1GO.transform.GetChild(commandsForExecute[aimnumber].PanelSlot - commandPanelGO.transform.childCount).transform.GetChild(0);
            forExecuteF1.GetComponent<Image>().color = Color.red;
            SwitchOffLastLightedUp(forExecuteF1);
        }
        //Fv2
        else
        {
            Transform forExecuteF2 = fv2GO.transform.GetChild(commandsForExecute[aimnumber].PanelSlot - commandPanelGO.transform.childCount - fv1GO.transform.childCount).transform.GetChild(0);
            forExecuteF2.GetComponent<Image>().color = Color.red;
            SwitchOffLastLightedUp(forExecuteF2);
        }
    }

    private void SwitchOffLastLightedUp(Transform newLastSwitchedOff)
    {
        if (lastSwitchedOff != null)
        {
            lastSwitchedOff.GetComponent<Image>().color = Color.white;
        }
        lastSwitchedOff = newLastSwitchedOff;
    }

    public void EdgeHit()
    {
        aimnumber = commandsForExecute.Count;
    }

    private void LockUI(bool lockBool)
    {
        //Command ui lock
        for(int i = 0; i < commandPanelGO.transform.childCount; i++)
        {
            GameObject child = commandPanelGO.transform.GetChild(i).gameObject;
            if (child.transform.childCount > 0)
            {
                Image childImage = child.transform.GetChild(0).GetComponent<Image>();
                childImage.raycastTarget = lockBool;
            }
        }

        //Factory ui lock
        Configuration.inStart = !lockBool;
        if (!lockBool)
        {
            Configuration.chosenCommand = Configuration.CommandType.Null;
            if (Configuration.chosenImage != null)
            {
                Configuration.chosenImage.color = Color.white;
            }
        }


        /*GameObject cmdFactory = GameObject.Find(Configuration.cmdFactoryName);
        if(cmdFactory == null)
        {
            return;
        }
        for(int i=0; i<cmdFactory.transform.childCount; i++)
        {
            GameObject child = cmdFactory.transform.GetChild(i).gameObject;
            Image childImage = child.transform.GetChild(0).GetComponent<Image>();
            childImage.raycastTarget = lockBool;
        }*/

        clearBtn.interactable = lockBool;
    }
}
