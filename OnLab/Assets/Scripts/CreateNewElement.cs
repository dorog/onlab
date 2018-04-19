using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewElement : MonoBehaviour {

    public string charName;
    public int id = 2;
    private Command element;
    //public Command element;
    public GameObject cmdpanelcmd;

    CommandPanel cmdpanelmanager;

    void Start()
    {

        cmdpanelmanager = GameObject.Find("CommandPanelManager").GetComponent<CommandPanel>();

        switch (id)
        {
            case 0:
                element = new GoForwardCmd(1, charName);
                break;
            case 1:
                element = new TurnRightCmd(1, charName);
                break;
            case 2:
                element = new TurnLeftCmd(1, charName);
                break;
            case 3:
                element = new FV(1, charName, 1);
                break;
            case 4:
                element = new FV(1, charName, 2);
                break;
            default:
                element = new GoForwardCmd(1, charName);
                break;
        }
    }


	// Update is called once per frame
	void Update () {
        if (this.transform.childCount == 0)
        {
            
            GameObject commandObj = Instantiate(cmdpanelcmd);
            commandObj.transform.SetParent(this.transform);
            commandObj.GetComponent<Image>().sprite = element.sprite;
            commandObj.transform.position = commandObj.transform.parent.position;
            commandObj.GetComponent<CommandData>().command = element;

            //last item must be a delete slot (slots + 1 (delete slot))
            commandObj.GetComponent<CommandData>().slot = cmdpanelmanager.summSlots; // .slotAmount
            
        }
     }
}
