using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1Generator : MonoBehaviour {


    public GameObject finishStoneModel;
    public GameObject brickModel;
    public int mapNumber = 1;

	// Use this for initialization
	void Start () {

        mapNumber = CurrentGameDatas.mapNumber;

        switch (mapNumber)
        {
            case 1:
                baseMap(10, 10);
                break;
            default:
                baseMap(20, 20);
                break;
        }     
    }

    public void baseMap(int x, int z)
    {
        GameObject parent = GameObject.Find("MapGeneratorGO");

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                GameObject brick = Instantiate(brickModel, new Vector3(25 + i * 50, 0, 25 + j * 50), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
            }
        }
        GameObject finishStone = Instantiate(finishStoneModel, new Vector3(25 + x*50, 0, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
    }

}
	
