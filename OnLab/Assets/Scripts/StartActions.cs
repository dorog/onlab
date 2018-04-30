using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartActions : MonoBehaviour
{
    public int endwait = 1;
    public float TimeBeetweenCommands;
    CommandPanel cmdPanel;
    static int aimnumber = 0;


    public bool start = false;
    private System.DateTime lastTime;
    List<Command> commandsForExecute = new List<Command>();

    List<Command> fv1 = new List<Command>();

    List<Command> fv2 = new List<Command>();

    GameObject character;
    public string charName;
    public float resetTime = 2;
    private bool die = false;
 

    private int executedCommands = 0;


    private Button actionBtn;
    private Vector3 characterPosition;
    private Vector3 characterForward;
    MapGenerator mapGen;

    void Start()
    {
        cmdPanel = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
        character = GameObject.Find(charName);
        characterPosition = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
        characterForward = new Vector3(character.transform.forward.x, character.transform.forward.y, character.transform.forward.z);
        mapGen = GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>();
        actionBtn = GameObject.Find(Configuration.startButton).GetComponent<Button>();
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

        character.GetComponent<JoeCommandControl>().stopped = false;
        aimnumber = 0;
        executedCommands = 0;
        actionBtn.enabled = false;
        //Debug.Log(commandsForExecute.Count);
    }

    private void Update()
    {
        //Debug.Log(fv1_aimnumber);
        if (start)
        {
            if (((System.DateTime.Now - lastTime).Seconds >= TimeBeetweenCommands) && (commandsForExecute.Count > aimnumber))
            {
                /*for (int i = 0; i < commandsForExecute.Count; i++)
                {
                    commandsForExecute[i].Identity(i, aimnumber);
                }
                Debug.Log("ciklus end " + aimnumber);*/
                commandsForExecute[aimnumber].Effect();
                //Debug.Log("aimnumber: " + aimnumber);
                aimnumber++;

                lastTime = System.DateTime.Now;
                executedCommands++;
                //Debug.Log(fv1_aimnumber + " " + System.DateTime.Now);

            }
            else if (commandsForExecute.Count <= aimnumber && (System.DateTime.Now - lastTime).Seconds >= TimeBeetweenCommands * endwait)
            {

                /*for (int i = 0; i < commandsForExecute.Count; i++)
                {
                    
                    commandsForExecute[i].Identity(i);
                }*/

                start = false;
                aimnumber = 0;

                character.transform.position = characterPosition;
                character.transform.forward = characterForward;
                Invoke("NotStaticBack", 0.1f); //Black Magic: joe is still here, so we need time
                actionBtn.enabled = true;
            }

        }
        if (die && ((resetTime - Time.deltaTime) <= 0))
        {
            EndCommands();
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
        actionBtn.enabled = true;
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
            /*for (int i = 0; i < commandsForExecute.Count - aimnumber - fv1.Count; i++)
            {
                commandsForExecute[aimnumber + fv1.Count + i] = commandsForExecute[aimnumber + 1 + i];
            }*/



            for (int i = 0; i < fv1.Count; i++)
            {
                commandsForExecute[aimnumber + i] = fv1[i];
            }
            commandsForExecute[aimnumber].Effect();
        }
        else if (fvNumber == 1 && fv1.Count == 0 && aimnumber == commandsForExecute.Count - 1)
        {
            EndCommands();
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
        }
        else if (fvNumber == 2 && fv2.Count == 0 && aimnumber == commandsForExecute.Count - 1)
        {
            EndCommands();
        }
    }

    private void NotStaticBack()
    {
        mapGen.restartMap(CurrentGameDatas.mapNumber);
    }
}
