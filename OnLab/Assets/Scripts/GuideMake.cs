using UnityEngine;

public class GuideMake : MonoBehaviour {

    GameDatas gmdatas;
    GameObject Doors;
    GameObject Gate;
    GameObject Keys;
    public GameObject KeyModel;
    public GameObject GemModel;
    public Vector3 KeyVector = new Vector3(25, 50, 0);
    public Vector3 GemVector = new Vector3();
    private int scoreBoardPlace = 3;

    public GameObject castList;

    // Use this for initialization
    void Start () {
        Doors = GameObject.Find(Configuration.doorStr);
        Gate = GameObject.Find(Configuration.gatesStr);
        Keys = GameObject.Find(Configuration.keyStr);
        //read the datas from CurrentGameDatas
        gmdatas = new GameDatas(CurrentGameDatas.maxMap);
        for(int i=0; i<gmdatas.maxMap; i++)
        {
            gmdatas.AddMapData(new MapDatas(CurrentGameDatas.mapDatas[i].mapScore, CurrentGameDatas.mapDatas[i].scarab, CurrentGameDatas.mapDatas[i].item, CurrentGameDatas.mapDatas[i].itemType));
        }


        //Do something with last maps "key" (gem), solved?
        for(int i=0; i<gmdatas.maxMap; i++)
        {
            if (CurrentGameDatas.mapDatas[i].item)
            {
                if (CurrentGameDatas.mapDatas[i].itemType == 1)
                {
                    KeySpam(i);
                }
                else
                {
                    GemSpam(i);
                }
                OpenGate(i);
            }
        }

        ScoreMake();

        EndCheck();
    }

    void GemSpam(int i)
    {
        Quaternion root = Keys.transform.GetChild(i).rotation;

        Instantiate(GemModel, Keys.transform.GetChild(i).position+new Vector3(0, 50, 0), root, Keys.transform.GetChild(i));
    }

    void KeySpam(int i)
    {
        Quaternion root = Keys.transform.GetChild(i).rotation;

        GameObject Key = Instantiate(KeyModel, Keys.transform.GetChild(i).position + new Vector3(0, 50, 0), root, Keys.transform.GetChild(i));
        Key.transform.Rotate(new Vector3(90, 0, 0));
    }

    void ScoreMake()
    {
        int DoorsChild = Doors.transform.childCount;
        for (int i = 0; i < gmdatas.maxMap && i < DoorsChild; i++)
        {
            Material[] mats = Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(0).GetComponent<MeshRenderer>().materials;
            mats[1] = Resources.Load<Material>(Configuration.GSB_part + gmdatas.mapDatas[i].scarab);
            Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(0).GetComponent<MeshRenderer>().materials = mats;
            int[] numbs = { 100, 10, 1 };
            int score = gmdatas.mapDatas[i].mapScore;
            for (int j = 1; j < Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).childCount; j++)
            {
                mats = Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(j).GetComponent<MeshRenderer>().materials;
                mats[1] = Resources.Load<Material>(Configuration.numberIcon + score / numbs[j - 1]);
                score -= (score / numbs[j - 1]) * numbs[j - 1];
                Doors.transform.GetChild(i).transform.GetChild(scoreBoardPlace).GetChild(j).GetComponent<MeshRenderer>().materials = mats;
            }
        }
    }

    void OpenGate(int i)
    {
        if (CurrentGameDatas.HawNewItem)
        {
            Gate.GetComponent<OpenGates>().OpenGateNew(CurrentGameDatas.mapNumber - 1);
        }
        else if (i != CurrentGameDatas.maxMap - 1)
        {
            Gate.GetComponent<OpenGates>().OpenGate(i);
        }
    }

    void EndCheck()
    {
        if(CurrentGameDatas.HawNewItem && CurrentGameDatas.ItemCount == CurrentGameDatas.mapNumber)
        {
            castList.gameObject.SetActive(true);
        }
    }
}
