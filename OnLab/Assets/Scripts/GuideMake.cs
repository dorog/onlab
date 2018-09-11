using UnityEngine;

public class GuideMake : MonoBehaviour {

    GameDatas gmdatas;
    GameObject Doors;
    GameObject Gate;
    GameObject Keys;
    public GameObject KeyModel;
    private int scoreBoardPlace = 3;

    // Use this for initialization
    void Start () {
        Doors = GameObject.Find(Configuration.doorStr);
        Gate = GameObject.Find(Configuration.gatesStr);
        Keys = GameObject.Find(Configuration.keyStr);
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
                if (i%2==1 )
                {
                    size = -1;
                }
                Instantiate(KeyModel, Keys.transform.GetChild(i).position+new Vector3(25*size, 50, 0), root, Keys.transform.GetChild(i));
                //Debug.Log(CurrentGameDatas.mapNumber);
                
                 Gate.GetComponent<OpenGates>().OpenGate(i);
            }
        }

        if (CurrentGameDatas.HaveNewKey)
        {
            int size = 1;
            if ((CurrentGameDatas.mapNumber - 1) % 2 == 1)
            {
                size = -1;
            }
            Quaternion root = Keys.transform.GetChild(CurrentGameDatas.mapNumber - 1).rotation;
            Instantiate(KeyModel, Keys.transform.GetChild(CurrentGameDatas.mapNumber - 1).position + new Vector3(25 * size, 50, 0), root, Keys.transform.GetChild(CurrentGameDatas.mapNumber - 1));
            CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].key = true;
            Gate.GetComponent<OpenGates>().OpenGateNew(CurrentGameDatas.mapNumber-1);
        }

        int DoorsChild = Doors.transform.childCount;
        for(int i=0; i< gmdatas.maxMap && i < DoorsChild; i++) //&& i< mapsGOchildNumber
        {
            Material[] mats = Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(0).GetComponent<MeshRenderer>().materials; //Resources.Load<Material>("Map_guide/GSB_part" + gmdatas.mapDatas[i].scarab);
            mats[1] = Resources.Load<Material>(Configuration.GSB_part+gmdatas.mapDatas[i].scarab);
            Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(0).GetComponent<MeshRenderer>().materials = mats;
            int[] numbs = { 100, 10, 1 };
            int score = gmdatas.mapDatas[i].mapScore;
            for (int j=1; j < Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).childCount; j++)
            {
                mats = Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(j).GetComponent<MeshRenderer>().materials;
                mats[1] = Resources.Load<Material>(Configuration.numberIcon + score/numbs[j-1]);
                score -= (score/numbs[j - 1])*numbs[j-1];
                Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(j).GetComponent<MeshRenderer>().materials = mats;
            }


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
