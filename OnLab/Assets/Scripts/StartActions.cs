using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActions : MonoBehaviour
{
    public int endwait = 1;
    public int TimeBeetweenCommands;
    CommandPanel cmdPanel;
    static int aimnumber = 0;
    public bool start = false;
    private System.DateTime lastTime;
    List<Command> commandsForExecute=new List<Command>();
    GameObject character;

    private Vector3 characterPosition;
    private Vector3 characterForward;

    void Start()
    {
        cmdPanel = GameObject.Find("CommandPanelManager").GetComponent<CommandPanel>();
        character = GameObject.Find("box_character");
        characterPosition = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
        characterForward = new Vector3(character.transform.forward.x, character.transform.forward.y, character.transform.forward.z);
    }

    public void ExecuteCommands()
    {

        /*character.transform.position = characterPosition;
        character.transform.forward = characterForward;*/

        start = true;
        commandsForExecute.Clear();
        commandsForExecute = cmdPanel.getRealCommands();
        aimnumber = 0;
   
    }

    private void Update()
    {
        if (start)
        {
            if ((System.DateTime.Now - lastTime).Seconds >= TimeBeetweenCommands && (commandsForExecute.Count>aimnumber))
            {
                lastTime = System.DateTime.Now;
                commandsForExecute[aimnumber].Effect();
                aimnumber++;
            }
            else if(commandsForExecute.Count <= aimnumber && (System.DateTime.Now - lastTime).Seconds >= TimeBeetweenCommands * endwait)
            {

                start = false;
                aimnumber = 0;

                character.transform.position = characterPosition;
                character.transform.forward=characterForward;

            }
            
        }
    }

    public void ObjectHit()
    {
        start = false;
    }
}
