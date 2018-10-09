using System.Collections.Generic;
using UnityEngine;

public class CommandFactory : MonoBehaviour {

    public Configuration.CommandType[] commands;
    public GameObject element;
    public List<CmdFactoryElement> cmdFactoryElements = new List<CmdFactoryElement>();
    public string[] keysForElements = { "a", "w", "d", "s", "q", "e" };

	// Use this for initialization
	void Start () {
		for(int i=0; i<commands.Length; i++)
        {
            GameObject elem = Instantiate(element, this.transform);
            elem.GetComponent<CmdFactoryElement>().SetCmdType(commands[i]);
            cmdFactoryElements.Add(elem.GetComponent<CmdFactoryElement>());
        }
	}
	
	// Update is called once per frame
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
