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
    private System.DateTime lastTime;
    List<Command> commandsForExecute = new List<Command>();

    List<Command> fv1 = new List<Command>();

    List<Command> fv2 = new List<Command>();

    GameObject character;
    public string charName;
    public float resetTime = 2;
    private bool die = false;

    public float effectTime = 1;


    private int executedCommands = 0;


    private Button actionBtn;
    private Button stopBtn;
    private Vector3 characterPosition;
    private Vector3 characterForward;
    MapGenerator mapGen;

    void Start()
    {
        fv1GO = GameObject.Find(Configuration.fv1Name);
        fv2GO = GameObject.Find(Configuration.fv2Name);
        commandPanelGO = GameObject.Find(Configuration.cmdPanelName);
        cmdPanel = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
        character = GameObject.Find(charName);
        characterPosition = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
        characterForward = new Vector3(character.transform.forward.x, character.transform.forward.y, character.transform.forward.z);
        mapGen = GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>();
        actionBtn = GameObject.Find(Configuration.startButton).GetComponent<Button>();
        stopBtn = GameObject.Find(Configuration.stopButton).GetComponent<Button>();

        actionBtn.interactable = true;
        stopBtn.interactable = false;
    }

    public void ExecuteCommands()
    {

        /*character.transform.position = characterPosition;
        character.transform.forward = characterForward;*/

        start = true;
        die = false;
        commandsForExecute.Clear();
        fv1.Clear();
        fv2.Clear();
        commandsForExecute = cmdPanel.getRealCommands(fv1, fv2);

        character.GetComponent<JoeCommandControl>().stopped = false;
        aimnumber = 0;
        executedCommands = 0;
        actionBtn.interactable = false;
        stopBtn.interactable = true;
        //Debug.Log(commandsForExecute.Count);
        lastSwitchedOff = null;
        LockUI(false);
        Invoke("ExecuteCmd", 0);
    }

    public void ObjectHit(float rTime)
    {
        //start = false;
        die = true;
        //resetTime = rTime;
        Invoke("EndCommands", rTime);
    }

    public void StopButtonOnClick()
    {
        stopBtn.interactable = false;
        aimnumber = commandsForExecute.Count;
    }

    public void EndCommands()
    {
        //character.GetComponent<Animator>().SetBool("start", true);
        character.GetComponent<JoeCommandControl>().stopped = true;
        character.GetComponent<JoeCommandControl>().gravityOff = false;
        aimnumber = commandsForExecute.Count;
        character.GetComponent<JoeCommandControl>().ResetActions();


        character.transform.position = characterPosition;
        character.transform.forward = characterForward;
        mapGen.restartMap(CurrentGameDatas.mapNumber);
        die = false;
        actionBtn.interactable = true;
        stopBtn.interactable = false;
    }

    public void fvStart(int fvNumber)
    {
       
        if ((fvNumber == 1) && (fv1.Count != 0))
        {
            int afterAim = commandsForExecute.Count - aimnumber - 1;
            int count = commandsForExecute.Count - 1;
            for (int i = 0; i < fv1.Count-1; i++)
            {
                commandsForExecute.Add(new Command());
            }

            int lastPlace = count + fv1.Count - 1;
            for (int i = 0; i < afterAim; i++)
            {
                commandsForExecute[lastPlace - i] = commandsForExecute[aimnumber + afterAim - i];
            }

            for (int i = 0; i < fv1.Count; i++)
            {
                commandsForExecute[aimnumber + i] = fv1[i];
            }
            commandsForExecute[aimnumber].Effect();
            LightUp();
        }
        else if (fvNumber == 1 && fv1.Count == 0 && aimnumber == commandsForExecute.Count - 1)
        {
            //EndCommands();
            Invoke("WaitBeforeEnd", EndWait);
        }
        else if (fvNumber == 2 && fv2.Count != 0)
        {
            int afterAim = commandsForExecute.Count - aimnumber - 1;
            int count = commandsForExecute.Count - 1;
            for (int i = 0; i < fv2.Count - 1; i++)
            {
                commandsForExecute.Add(new Command());
            }

            int lastPlace = count + fv2.Count - 1;
            for (int i = 0; i < afterAim; i++)
            {
                commandsForExecute[lastPlace - i] = commandsForExecute[aimnumber + afterAim - i];
            }

            for (int i = 0; i < fv2.Count; i++)
            {
                commandsForExecute[aimnumber + i] = fv2[i];
            }

            commandsForExecute[aimnumber].Effect();
            LightUp();
        }
        else if (fvNumber == 2 && fv2.Count == 0 && aimnumber == commandsForExecute.Count - 1)
        {
            //EndCommands();
            Invoke("WaitBeforeEnd", EndWait);
        }
    }

    private void NotStaticBack()
    {
        mapGen.restartMap(CurrentGameDatas.mapNumber);
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
            Invoke("ExecuteCmd", Configuration.TimeBetweenCmds + effectTime);
        }
        else
        {
            Invoke("WaitBeforeEnd", EndWait);
        }
    }

    private void WaitBeforeEnd()
    {
        SwitchOffLastLightedUp(null);

        aimnumber = 0;
        character.transform.position = characterPosition;
        character.transform.forward = characterForward;
        Invoke("NotStaticBack", 0.5f); //Black Magic: joe is still here, so we need time
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
        GameObject cmdFactory = GameObject.Find(Configuration.cmdFactoryName);
        if(cmdFactory == null)
        {
            return;
        }
        for(int i=0; i<cmdFactory.transform.childCount; i++)
        {
            GameObject child = cmdFactory.transform.GetChild(i).gameObject;
            Image childImage = child.transform.GetChild(0).GetComponent<Image>();
            childImage.raycastTarget = lockBool;
        }
    }
}
