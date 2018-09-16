using UnityEngine;
using UnityEngine.UI;

public class CreateNewElement : MonoBehaviour {

    public int id = 2;
    public GameObject cmdpanelcmd;

    CommandPanel cmdpanelmanager;

    void Start()
    {
        cmdpanelmanager = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
    }


	// Update is called once per frame
	void Update () {
        if (this.transform.childCount == 0)
        {
            Command element;
            switch (id)
            {
                case 0:
                    element = new GoForwardCmd(1);
                    break;
                case 1:
                    element = new TurnRightCmd(1);
                    break;
                case 2:
                    element = new TurnLeftCmd(1);
                    break;
                case 3:
                    element = new ActivateCmd(1);
                    break;
                case 4:
                    element = new FV(1, 1);
                    break;
                case 5:
                    element = new FV(1, 2);
                    break;
                default:
                    element = new GoForwardCmd(1);
                    break;
            }
            GameObject commandObj = Instantiate(cmdpanelcmd);
            commandObj.transform.SetParent(this.transform);
            commandObj.GetComponent<Image>().sprite = element.sprite;
            commandObj.transform.position = commandObj.transform.parent.position;
            commandObj.GetComponent<CommandData>().command = element;
            RectTransform rt = commandObj.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x * Screen.width / Configuration.bestScreenWidth, rt.sizeDelta.y * Screen.height / Configuration.bestScreenHeight);
            //last item must be a delete slot (slots + 1 (delete slot))

            commandObj.GetComponent<CommandData>().slot = cmdpanelmanager.summSlots; // .slotAmount Update: .summSlots -> 0
            
        }
     }
}
