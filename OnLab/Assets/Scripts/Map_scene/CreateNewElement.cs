using UnityEngine;
using UnityEngine.UI;

public class CreateNewElement : MonoBehaviour {

    public Configuration.CommandType id;
    public GameObject cmdpanelcmd;
    private float androidUISize = 2f;

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
                case Configuration.CommandType.GoForward:
                    element = new GoForwardCmd(1);
                    break;
                case Configuration.CommandType.TurnRight:
                    element = new TurnRightCmd(1);
                    break;
                case Configuration.CommandType.TurnLeft:
                    element = new TurnLeftCmd(1);
                    break;
                case Configuration.CommandType.Activate:
                    element = new ActivateCmd(1);
                    break;
                case Configuration.CommandType.FV1:
                    element = new FV(1, 1);
                    break;
                case Configuration.CommandType.FV2:
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
            #if UNITY_STANDALONE_WIN
                rt.sizeDelta = new Vector2(rt.sizeDelta.x * Screen.width / Configuration.bestScreenWidth, rt.sizeDelta.y * Screen.height / Configuration.bestScreenHeight);
            #else
                rt.sizeDelta = new Vector2(rt.sizeDelta.x * Screen.width / Configuration.bestScreenWidth, rt.sizeDelta.y * Screen.height / Configuration.bestScreenHeight * androidUISize);
            #endif

            //last item must be a delete slot (slots + 1 (delete slot))

            commandObj.GetComponent<CommandData>().slot = cmdpanelmanager.summSlots;
            
        }
     }
}
