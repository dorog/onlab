using System.Collections.Generic;
using UnityEngine;

public class CommandFactory : MonoBehaviour {
    [Header("Commands")]
    [SerializeField]
    [Tooltip ("Commands in game")]
    private CommandType[] commands;

    [SerializeField]
    private GameObject element;

    private List<CmdFactoryElement> cmdFactoryElements = new List<CmdFactoryElement>();

    [SerializeField]
    private string[] keysForElements = { "a", "w", "d", "s", "q", "e" };

	void Start () {
		for(int i=0; i<commands.Length; i++)
        {
            GameObject elem = Instantiate(element, transform);
            elem.GetComponent<CmdFactoryElement>().SetCmdType(commands[i]);
            cmdFactoryElements.Add(elem.GetComponent<CmdFactoryElement>());
        }
	}
	
	void Update () {
        #if UNITY_STANDALONE_WIN
            for (int i=0; i<commands.Length; i++)
            {
                if (Input.GetKeyDown(keysForElements[i]))
                {
                    cmdFactoryElements[i].Clicked();
                }
            }
        #endif
    }
}
