using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartActions : MonoBehaviour
{
    private static StartActions instance = null;
    private string speedTextText = "Speed x";

    public static bool inStart = false;

    [Header("Command holders")]
    [SerializeField]
    private GameObject commandPanelGO;
    [SerializeField]
    private GameObject fv1GO;
    [SerializeField]
    private GameObject fv2GO;

    private List<Command> commandsForExecute = new List<Command>();
    private List<Command> fv1 = new List<Command>();
    private List<Command> fv2 = new List<Command>();

    [Header("Using")]
    [SerializeField]
    private CommandPanel cmdPanel;
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private MapGenerator mapGen;

    private int aimnumber = 0;
    private Transform lastSwitchedOff;

    private bool die = false;

    private readonly float effectTime = SharedData.timeForAnimation;
    private int executedCommands = 0;

    [Header("Settings")]
    [SerializeField]
    private float EndWait = 2;
    [SerializeField]
    private float TimeBetweenCmds = 0.5f;
    [SerializeField]
    public float fallSpeedBoost = 2;

    [Header("Buttons")]
    [SerializeField]
    private Button actionBtn;
    [SerializeField]
    private Button stopBtn;
    [SerializeField]
    private Button clearBtn;
    [Header("Speed Text")]
    [SerializeField]
    private Text speedText;

    private int fvCallInARow = 0;
    private int maxFvCallinARow = 5; 

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    public static StartActions GetStartActions()
    {
        return instance;
    }

    void Start()
    {
        speedText.text = speedTextText + CurrentGameDatas.speed;

        actionBtn.interactable = true;
        stopBtn.interactable = false;
        clearBtn.interactable = true;
    }

    public void ExecuteCommands()
    {
        commandsForExecute.Clear();
        fv1.Clear();
        fv2.Clear();

        commandsForExecute = cmdPanel.GetRealMainCommands();
        fv1 = cmdPanel.GetRealFV1Commands();
        fv2 = cmdPanel.GetRealFV2Commands();

        aimnumber = 0;
        executedCommands = 0;
        SharedData.fallDistance = 0;

        lastSwitchedOff = null;
        LockUI(false);

        character.GetComponent<JoeCommandControl>().stopped = false;
        inStart = true;

        actionBtn.interactable = false;
        stopBtn.interactable = true;

        die = false;
        fvCallInARow = 0;
        Invoke("ExecuteCmd", 0);
    }

    public void KilledBySomething(float rTime)
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
        fvCallInARow++;
        if(fvCallInARow >= maxFvCallinARow)
        {
            return;
        }
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
        mapGen.RestartMap(ActualMapData.mapNumber);
    }

    private void ExecuteCmd()
    {
        if (fvCallInARow >= maxFvCallinARow && stopBtn.interactable)
        {
            Invoke("ExecuteCmd", TimeBetweenCmds + effectTime);
            return;
        }
        if (fvCallInARow >= maxFvCallinARow && !stopBtn.interactable)
        {
            Invoke("WaitBeforeEnd", EndWait);
            return;
        }
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
            float fallTime = Mathf.Pow((SharedData.fallDistance / 2 / -Physics.gravity.y), 0.5f);
            Invoke("ExecuteCmd", TimeBetweenCmds + effectTime + fallTime*fallSpeedBoost);
        }
        else
        {
            Invoke("WaitBeforeEnd", EndWait);
        }
    }

    private void WaitBeforeEnd()
    {
        SwitchOffLastLightedUp(null);

        // reset the animations
        Animator anim = character.GetComponent<Animator>();
        anim.SetBool(JoeCommandControl.trapAnimation, false);
        anim.SetBool(JoeCommandControl.forwardAnimation, false);

        character.GetComponent<JoeCommandControl>().stopped = true;

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
        else if(commandsForExecute[aimnumber].PanelSlot < commandPanelGO.transform.childCount + fv1GO.transform.childCount)
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
        inStart = !lockBool;
        if (!lockBool)
        {
            ActualMapData.chosenCommand = CommandType.Null;
            if (ActualMapData.chosenImage != null)
            {
                ActualMapData.chosenImage.color = Color.white;
            }
        }

        clearBtn.interactable = lockBool;
    }

    public void ChangeSpeed()
    {
        if (CurrentGameDatas.speed == SharedData.maxSpeed)
        {
            Time.timeScale = SharedData.minSpeed;
            CurrentGameDatas.speed = SharedData.minSpeed;
            speedText.text = speedTextText + CurrentGameDatas.speed;
            return;
        }
        Time.timeScale = CurrentGameDatas.speed + 1;
        CurrentGameDatas.speed++;
        speedText.text = speedTextText + CurrentGameDatas.speed;
    }

    public void ResetFvInARow()
    {
        fvCallInARow = 0;
    }
}
