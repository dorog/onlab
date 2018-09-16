using System;
using System.IO;
using UnityEngine;

public class FinishMap : MonoBehaviour {

    public int maxPoint = 999;
    public int maxScarabNumber = 3;
    public int missingScarabWeight = 100;
    public int moreCmdWeight = 10;

    // Use this for initialization
    void Start () {
        CurrentGameDatas.HaveNewKey = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.name != Configuration.characterName)
        {
            Destroy(other.gameObject);
            return;
        }
        //Calulate datas
        CommandPanel slotPanel = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
        SceneLoader scLoader = GameObject.Find(Configuration.loadSceneGOName).GetComponent<SceneLoader>();

        int realCommandsNumber = slotPanel.getRealCommandsNumber();
        int[] MinCmdNumber = new int[2];


        using (StreamReader sr = new StreamReader(Configuration.buggSystemFile))
        {
            string line = sr.ReadToEnd();
            string[] datas = line.Split('\n');
            string[] currentDatas = datas[CurrentGameDatas.mapNumber - 1].Split('\t');
            for (int i = 0; i < currentDatas.Length; i++)
            {
                MinCmdNumber[i] = Convert.ToInt32(currentDatas[i]);
            }
        }

        int scarabNumber = 0;
        if (realCommandsNumber <= MinCmdNumber[0])
        {
            if (CurrentGameDatas.HaveKey)
            {
                scarabNumber = 3;
            }
            else
            {
                scarabNumber = 2;
            }
        }
        else if (realCommandsNumber <= MinCmdNumber[1])
        {
            scarabNumber = 2;
        }
        else
        {
            scarabNumber = 1;
        }
 
        int thisGameScore = maxPoint - (maxScarabNumber - scarabNumber) * missingScarabWeight - (MinCmdNumber[0] - realCommandsNumber) * moreCmdWeight; 

        if (CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab < scarabNumber)
        {
            CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab = scarabNumber;
        }
        if ((CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore) < thisGameScore)
        {
            if (thisGameScore < 0)
            {
                thisGameScore = 0;
            }
            else if(thisGameScore > maxPoint)
            {
                thisGameScore = maxPoint;
            }
            CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore = thisGameScore; //calculate
        }

        //save this
        using (StreamWriter sw = new StreamWriter(CurrentGameDatas.slotName))
        {
            sw.WriteLine(1);
            sw.WriteLine(CurrentGameDatas.maxMap);
            for (int i = 0; i < CurrentGameDatas.mapDatas.Count; i++)
            {
                int key = 1;
                if (!CurrentGameDatas.mapDatas[i].key)
                {
                    key = 0;
                }
                if(CurrentGameDatas.mapNumber-1 == i && CurrentGameDatas.HaveKey)
                {
                    key = 1;
                }
                CurrentGameDatas.HaveNewKey = !CurrentGameDatas.mapDatas[i].key && CurrentGameDatas.HaveKey;

                sw.WriteLine(CurrentGameDatas.mapDatas[i].mapScore + "\t" + CurrentGameDatas.mapDatas[i].scarab +"\t" +key);
            }
            
            CurrentGameDatas.HaveNewKey = !CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber-1].key && CurrentGameDatas.HaveKey;
            if (CurrentGameDatas.HaveNewKey)
            {
                CurrentGameDatas.KeyNumber++;
            }
            //Debug.Log(CurrentGameDatas.HaveNewKey);
        }
        
        
        CurrentGameDatas.solvedMap = new MapDatas(thisGameScore, scarabNumber, CurrentGameDatas.HaveKey);
        CurrentGameDatas.HaveKey = false;

        //Todo: different scene for last map
        scLoader.LoadScene(Configuration.resultScene);
    }
}
