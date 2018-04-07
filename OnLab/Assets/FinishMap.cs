using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FinishMap : MonoBehaviour {

    public string filename="ScarabCmdMin.txt";
    public LayerMask Mask;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, Mask);

        /*Debug.Log(transform.localScale.x+" "+ transform.localScale.y + " "+ transform.localScale.z + " ");

        for (int i = 0; i < colliders.Length; i++)
        {
            /*Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;
            //targetRigidbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);

            //MonsterProperty target = targetRigidbody.GetComponent<MonsterProperty>();

            if (!target)
                continue;

            //calc dmg

            //target.getDmg(dmg);
            Debug.Log("Siker!");
        }*/

        //Debug.Log("Siker!");

        //Calulate datas
        CommandPanel slotPanel = GameObject.Find("CommandPanelManager").GetComponent<CommandPanel>();
        SceneLoader scLoader = GameObject.Find("LoadSceneGO").GetComponent<SceneLoader>();

        int realCommandsNumber = slotPanel.getRealCommandsNumber();
        int[] MinCmdNumber = new int[2];


        using (StreamReader sr = new StreamReader(filename))
        {
            string line = sr.ReadToEnd();
            string[] datas = line.Split('\n');
            string[] currentDatas = datas[CurrentGameDatas.lastMap - 1].Split('\t');
            for (int i = 0; i < currentDatas.Length; i++)
            {
                MinCmdNumber[i] = Convert.ToInt32(currentDatas[i]);
            }
        }

        int scarabNumber = 0;
        if (realCommandsNumber < MinCmdNumber[0])
        {
            scarabNumber = 3;
        }
        else if (realCommandsNumber < MinCmdNumber[1])
        {
            scarabNumber = 2;
        }
        else
        {
            scarabNumber = 1;
        }

        if (CurrentGameDatas.lastMap==CurrentGameDatas.mapNumber)
        {

             CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab = scarabNumber;

             //calculate from file

            CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber-1].mapScore = CurrentGameDatas.mapNumber * CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber-1].scarab *10 - realCommandsNumber; //calculate

            CurrentGameDatas.lastMap++; //just if it's the last
            CurrentGameDatas.mapDatas.Add(new MapDatas()); //do i rly need it?    
        }
        else
        {
            if(CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab< scarabNumber)
            {
                CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab = scarabNumber;
            }
            if((CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore) < (CurrentGameDatas.mapNumber * CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab * 10 - realCommandsNumber))
            {
                CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore = CurrentGameDatas.mapNumber * CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab * 10 - realCommandsNumber; //calculate
            }

        }

        //save this
        using (StreamWriter sw = new StreamWriter(CurrentGameDatas.slotName))
        {
            sw.WriteLine(CurrentGameDatas.lastMap);
            for (int i = 0; i < CurrentGameDatas.mapDatas.Count; i++)
            {
                sw.WriteLine(CurrentGameDatas.mapDatas[i].mapScore + "\t" + CurrentGameDatas.mapDatas[i].scarab);
            }
        }

        // scLoader.LoadScene("FinishedMap");
        scLoader.LoadScene("Map_guide");
    }

}
