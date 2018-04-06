using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideMake : MonoBehaviour {

    GameDatas gmdatas;
    GameObject mapsGO;

	// Use this for initialization
	void Start () {
        mapsGO = GameObject.Find("MapsGO");
        //read the datas from CurrentGameDatas
        gmdatas = new GameDatas(CurrentGameDatas.lastMap);
        for(int i=0; i<gmdatas.lastMap; i++)
        {
            gmdatas.AddMapData(new MapDatas(CurrentGameDatas.mapDatas[i].mapScore, CurrentGameDatas.mapDatas[i].scarab));
        }

        int mapsGOchildNumber = mapsGO.transform.childCount;
        for(int i=0; i< gmdatas.lastMap; i++)
        {
            mapsGO.transform.GetChild(i).transform.GetChild(1).GetChild(0).GetComponent<Text>().text="Score: "+gmdatas.mapDatas[i].mapScore;
        }



        for(int i=gmdatas.lastMap; i<mapsGOchildNumber; i++)
        {
            mapsGO.transform.GetChild(i).transform.GetComponent<Button>().interactable = false;
            mapsGO.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
