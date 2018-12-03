using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandFactory : MonoBehaviour {
    [Header("Commands")]
    [SerializeField]
    [Tooltip ("Commands in game")]
    private CommandType[] commands;

    [SerializeField]
    private GameObject element;

    private List<CmdFactoryElement> cmdFactoryElements = new List<CmdFactoryElement>();

    public static CommandType chosenCommand = CommandType.Null;
    public static Image chosenImage = null;

#if UNITY_STANDALONE_WIN
    [SerializeField]
    private string[] keysForElements = { "a", "w", "d", "s", "q", "e" };
#endif

    void Start () {
		for(int i=0; i<commands.Length; i++)
        {
            GameObject elem = Instantiate(element, transform);
            elem.GetComponent<CmdFactoryElement>().SetCmdType(commands[i]);
            cmdFactoryElements.Add(elem.GetComponent<CmdFactoryElement>());
        }
	}

#if UNITY_STANDALONE_WIN
    void Update () {
            for (int i=0; i<commands.Length; i++)
            {
                if (Input.GetKeyDown(keysForElements[i]))
                {
                    cmdFactoryElements[i].Click();
                }
            }
    }
#endif
}
