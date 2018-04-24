using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FinishMap : MonoBehaviour {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    { 

        //Calulate datas
        CommandPanel slotPanel = GameObject.Find("CommandPanelManager").GetComponent<CommandPanel>();
        SceneLoader scLoader = GameObject.Find("LoadSceneGO").GetComponent<SceneLoader>();

        int realCommandsNumber = slotPanel.getRealCommandsNumber();
        int[] MinCmdNumber = new int[2];


        using (StreamReader sr = new StreamReader(CurrentGameDatas.buggSystemFile))
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
        if (realCommandsNumber < MinCmdNumber[0])
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
        else if (realCommandsNumber < MinCmdNumber[1])
        {
            scarabNumber = 2;
        }
        else
        {
            scarabNumber = 1;
        }

        int thisGameScore = CurrentGameDatas.mapNumber * scarabNumber * 10 - realCommandsNumber;

        /*if (CurrentGameDatas.lastMap==CurrentGameDatas.mapNumber)
        {

             CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab = scarabNumber;

             //calculate from file

            CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber-1].mapScore = CurrentGameDatas.mapNumber * CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber-1].scarab *10 - realCommandsNumber; //calculate

            CurrentGameDatas.lastMap++; //just if it's the last
            CurrentGameDatas.mapDatas.Add(new MapDatas()); //do i rly need it?    
        }
        else
        {*/
            if(CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab< scarabNumber)
            {
                CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab = scarabNumber;
            }
            if((CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore) < (CurrentGameDatas.mapNumber * CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab * 10 - realCommandsNumber))
            {
                CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore = CurrentGameDatas.mapNumber * CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab * 10 - realCommandsNumber; //calculate
            }

        //}

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
        scLoader.LoadScene("FinishedMap");
    }

}
