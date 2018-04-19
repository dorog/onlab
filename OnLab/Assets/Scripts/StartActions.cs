using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActions : MonoBehaviour
{
    public int endwait = 1;
    public float TimeBeetweenCommands;
    CommandPanel cmdPanel;
    static int aimnumber = 0;
    

    public bool start = false;
    private System.DateTime lastTime;
    List<Command> commandsForExecute=new List<Command>();

    List<Command> fv1 = new List<Command>();
    List<int> fv1_aimnumbers = new List<int>();
    List<Command> fv2 = new List<Command>();
    List<int> fv2_aimnumbers = new List<int>();

    private int fv1_aimnumber = 0;
    private bool first_f1 = true;
    private bool effect_f1 = true;
    public int fv2_aimnumber = 0;

    private int panelNumber = 0;

    GameObject character;
    public string charName;
    public float resetTime = 2;
    private bool die = false;
    private bool fv_volt = false;

    private int executedCommands = 0;

    private List<FVcallData> fvCalls = new List<FVcallData>();

    private Vector3 characterPosition;
    private Vector3 characterForward;
    MapGenerator mapGen;

    void Start()
    {
        cmdPanel = GameObject.Find("CommandPanelManager").GetComponent<CommandPanel>();
        character = GameObject.Find(charName);
        characterPosition = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
        characterForward = new Vector3(character.transform.forward.x, character.transform.forward.y, character.transform.forward.z);
        mapGen = GameObject.Find("MapGeneratorGO").GetComponent<MapGenerator>();

    }

    public void ExecuteCommands()
    {

        /*character.transform.position = characterPosition;
        character.transform.forward = characterForward;*/

        start = true;
        commandsForExecute.Clear();
        fv1.Clear();
        fv2.Clear();
        commandsForExecute = cmdPanel.getRealCommands(fv1, fv2);

        //fv1_aimnumbers.Clear();
        //fv2_aimnumbers.Clear();

        fv1_aimnumber = 0;
        fv2_aimnumber = 0;

        panelNumber = 0;
        aimnumber = 0;
        executedCommands = 0;

        //Debug.Log(commandsForExecute.Count);
    }

    private void Update()
    {
        //Debug.Log(fv1_aimnumber);
        if (start)
        {
            if (((System.DateTime.Now - lastTime).Seconds >= TimeBeetweenCommands) && (commandsForExecute.Count>aimnumber))
            {
                
               Debug.Log("if");
               commandsForExecute[aimnumber].Effect();
               //Debug.Log("aimnumber: " + aimnumber);
               aimnumber++;
                
                lastTime = System.DateTime.Now;
                executedCommands++;
                //Debug.Log(fv1_aimnumber + " " + System.DateTime.Now);

            }
            else if(commandsForExecute.Count <= aimnumber && (System.DateTime.Now - lastTime).Seconds >= TimeBeetweenCommands * endwait)
            {

                start = false;
                aimnumber = 0;

                character.transform.position = characterPosition;
                character.transform.forward=characterForward;
                mapGen.restartMap(CurrentGameDatas.mapNumber);
            }
            
        }
        if(die && ((resetTime - Time.deltaTime) <= 0))
        {
            aimnumber = 0;
            character.GetComponent<JoeCommandControl>().ResetActions();


            character.transform.position = characterPosition;
            character.transform.forward = characterForward;
            mapGen.restartMap(CurrentGameDatas.mapNumber);
            die = false;
        }
        else if (die)
        {
            resetTime -= Time.deltaTime;
        }
    }

    public void ObjectHit(float rTime)
    {
        start = false;
        die = true;
        resetTime = rTime;
    }

    public void fvStart(int fvNumber)
    {

        //Version 2
        if (fvNumber == 1 && fv1.Count != 0)
        {
            for (int i = 0; i < fv1.Count - 1; i++)
            {
                commandsForExecute.Add(new Command());
            }

            for (int i = 0; i < commandsForExecute.Count - aimnumber - fv1.Count; i++)
            {
                commandsForExecute[aimnumber + fv1.Count + i] = commandsForExecute[aimnumber + 1 + i];
            }
            for (int i = 0; i < fv1.Count; i++)
            {
                commandsForExecute[aimnumber + i] = fv1[i];
            }

            commandsForExecute[aimnumber].Effect();
        }

        else if (fvNumber == 2 && fv2.Count!=0)
        {
            for (int i = 0; i < fv2.Count - 1; i++)
            {
                commandsForExecute.Add(new Command());
            }

            for (int i = 0; i < commandsForExecute.Count - aimnumber - fv2.Count; i++)
            {
                commandsForExecute[aimnumber + fv2.Count + i] = commandsForExecute[aimnumber + 1 + i];
            }
            for (int i = 0; i < fv2.Count; i++)
            {
                commandsForExecute[aimnumber + i] = fv2[i];
            }

            commandsForExecute[aimnumber].Effect();
        }
        
    }
}
