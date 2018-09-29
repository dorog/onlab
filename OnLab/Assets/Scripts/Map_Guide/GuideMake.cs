using UnityEngine;

public class GuideMake : MonoBehaviour {

    GameDatas gmdatas;
    GameObject Doors;
    GameObject Gate;
    GameObject Keys;
    public GameObject KeyModel;
    public GameObject GemModel;
    private int scoreBoardPlace = 3;
    public int itemAboveHolder = 50;

    public GameObject castList;

    // Use this for initialization
    void Start () {
        Time.timeScale = Configuration.basicSpeed;

        Doors = GameObject.Find(Configuration.doorStr);
        Gate = GameObject.Find(Configuration.gatesStr);
        Keys = GameObject.Find(Configuration.keyStr);

        gmdatas = new GameDatas(CurrentGameDatas.maxMap);
        for(int i=0; i<gmdatas.maxMap; i++)
        {
            gmdatas.AddMapData(new MapDatas(CurrentGameDatas.mapDatas[i].mapScore, CurrentGameDatas.mapDatas[i].scarab, CurrentGameDatas.mapDatas[i].item, CurrentGameDatas.mapDatas[i].itemType));
        }

        for(int i=0; i<gmdatas.maxMap; i++)
        {
            if (CurrentGameDatas.mapDatas[i].item)
            {
                if (CurrentGameDatas.mapDatas[i].itemType == Configuration.KeyType)
                {
                    KeySpam(i);
                }
                else if(CurrentGameDatas.mapDatas[i].itemType == Configuration.GemType)
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

        Instantiate(GemModel, Keys.transform.GetChild(i).position+new Vector3(0, itemAboveHolder, 0), root, Keys.transform.GetChild(i));
    }

    void KeySpam(int i)
    {
        Quaternion root = Keys.transform.GetChild(i).rotation;

        GameObject Key = Instantiate(KeyModel, Keys.transform.GetChild(i).position + new Vector3(0, itemAboveHolder, 0), root, Keys.transform.GetChild(i));
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
        if (Gate.transform.childCount-1 < i)
        {
            return;
        }
        if((i == CurrentGameDatas.mapNumber - 1) && (CurrentGameDatas.HawNewItem))
        {
            Gate.transform.GetChild(i).GetComponent<OpenGate>().OpenGateNew();
        }
        else
        {
            Gate.transform.GetChild(i).GetComponent<OpenGate>().OpenGateInstantly();
        }
    }

    void EndCheck()
    {
        if(CurrentGameDatas.HawNewItem && CurrentGameDatas.ItemCount == CurrentGameDatas.maxMap)
        {
            castList.gameObject.SetActive(true);
        }
    }
}
