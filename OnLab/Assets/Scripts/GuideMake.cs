using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideMake : MonoBehaviour {

    GameDatas gmdatas;
    GameObject Doors;
    GameObject Gate;
    GameObject Keys;
    public GameObject KeyModel;
    private int scoreBoardPlace = 3;

	// Use this for initialization
	void Start () {
        Doors = GameObject.Find("Doors");
        Gate = GameObject.Find("Gates");
        Keys = GameObject.Find("Keys");
        //read the datas from CurrentGameDatas
        gmdatas = new GameDatas(CurrentGameDatas.maxMap);
        for(int i=0; i<gmdatas.maxMap; i++)
        {
            gmdatas.AddMapData(new MapDatas(CurrentGameDatas.mapDatas[i].mapScore, CurrentGameDatas.mapDatas[i].scarab, CurrentGameDatas.mapDatas[i].key));
        }


        //Do something with last maps "key" (gem)
        for(int i=0; i<gmdatas.maxMap-1; i++)
        {
            if (CurrentGameDatas.mapDatas[i].key)
            {
                Quaternion root = Keys.transform.GetChild(i).rotation;
                //root.y += 180;
                int size = 1;
                if (i >= gmdatas.maxMap / 2)
                {
                    size = -1;
                }
                GameObject key = Instantiate(KeyModel, Keys.transform.GetChild(i).position+new Vector3(25*size, 50, 0), root, Keys.transform.GetChild(i)) as GameObject;
                Gate.GetComponent<OpenGates>().OpenGate(i);
            }
        }

        int DoorsChild = Doors.transform.childCount;
        for(int i=0; i< gmdatas.maxMap && i < DoorsChild; i++) //&& i< mapsGOchildNumber
        {
            //Doors.transform.GetChild(i).transform.GetChild(4).GetChild(0).GetComponent<Text>().text="Score: "+gmdatas.mapDatas[i].mapScore;
            //Debug.Log(gmdatas.mapDatas[i].scarab);
            Material[] mats = Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(0).GetComponent<MeshRenderer>().materials; //Resources.Load<Material>("Map_guide/GSB_part" + gmdatas.mapDatas[i].scarab);
            mats[1] = Resources.Load<Material>("Map_guide/GSB_part"+gmdatas.mapDatas[i].scarab);
            Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(0).GetComponent<MeshRenderer>().materials = mats;
            int[] numbs = { 100, 10, 1 };
            int score = gmdatas.mapDatas[i].mapScore;
            for (int j=1; j < Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).childCount; j++)
            {
                mats = Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(j).GetComponent<MeshRenderer>().materials;
                mats[1] = Resources.Load<Material>("Map_guide/number" + score/numbs[j-1]);
                score -= (score/numbs[j - 1])*numbs[j-1];
                Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(j).GetComponent<MeshRenderer>().materials = mats;
            }


        }



        /*for(int i=gmdatas.maxMap; i<DoorsChild; i++)
        {
            Doors.transform.GetChild(i).transform.GetComponent<Button>().interactable = false;
            Doors.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(false);
        }*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
