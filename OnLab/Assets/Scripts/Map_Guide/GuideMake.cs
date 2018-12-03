using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideMake : MonoBehaviour {

    private List<MapResultData> gmdatas = new List<MapResultData>();
    private string GSB_part = "Map_guide/GSB_part";
    private string numberIcon = "Map_guide/number";

    [Header("Map objects")]
    [SerializeField]
    private GameObject ScoreBoards;
    [SerializeField]
    private GameObject Gate;
    [SerializeField]
    private GameObject Keys;
    [Header("Key setting")]
    [SerializeField]
    private GameObject KeyModel;
    [SerializeField]
    private Vector3 KeyModelRotation = new Vector3(90, 0, 0);
    [SerializeField]
    private int KeyAbove = 50;
    [Header("Gem setting")]
    [SerializeField]
    private GameObject GemModel;
    [SerializeField]
    private Vector3 GemModelRotation = new Vector3(0, 0, 0);
    [SerializeField]
    private int GemAbove = 50;
    [Header("Relic setting")]
    [SerializeField]
    private GameObject RelicModel;
    [SerializeField]
    private Vector3 RelicModelRotation = new Vector3(90, -90, -90);
    [SerializeField]
    private int RelicAbove = 30;

    [Header("Level up button")]
    [SerializeField]
    private Button levelUpButton;

    [Header("CastList GameObject")]
    [SerializeField]
    private GameObject castList;

    private readonly int mathNumber = 1;

    void Start () {
        Time.timeScale = SharedData.basicSpeed;

        if (levelUpButton!=null && CurrentGameDatas.GetActualLevelLastMapNumber() <= CurrentGameDatas.ItemCount && CurrentGameDatas.onLevel != GameStructure.maxLevel) {
            levelUpButton.interactable = true;
        }

        int mapsNumber = CurrentGameDatas.GetActualLevelMapCount();

        int firstLevelNumber = CurrentGameDatas.GetActualLevelFirstMapNumber();
        int j = 0;
        for(int i= firstLevelNumber; i < firstLevelNumber + mapsNumber; i++)
        {
            gmdatas.Add(new MapResultData(CurrentGameDatas.mapDatas[i].Score, CurrentGameDatas.mapDatas[i].Scarab, CurrentGameDatas.mapDatas[i].Item, CurrentGameDatas.mapDatas[i].ItemType));
            if (CurrentGameDatas.mapDatas[i].Item == SharedData.HaveItemNumber)
            {
                if (CurrentGameDatas.mapDatas[i].ItemType == SharedData.KeyType)
                {
                    KeySpam(j);
                }
                else if (CurrentGameDatas.mapDatas[i].ItemType == SharedData.GemType)
                {
                    GemSpam(j);
                }
                else
                {
                    RelicSpam(j);
                }
                OpenGate(j);
            }
            j++;
        }

        ScoreMake();

        EndCheck();
    }

    void GemSpam(int i)
    {
        Quaternion root = Keys.transform.GetChild(i).rotation;

        GameObject Gem = Instantiate(GemModel, Keys.transform.GetChild(i).position+new Vector3(0, GemAbove, 0), root, Keys.transform.GetChild(i));
        Gem.transform.Rotate(GemModelRotation);
    }

    void KeySpam(int i)
    {
        Quaternion root = Keys.transform.GetChild(i).rotation;

        GameObject Key = Instantiate(KeyModel, Keys.transform.GetChild(i).position + new Vector3(0, KeyAbove, 0), root, Keys.transform.GetChild(i));
        Key.transform.Rotate(KeyModelRotation);
    }

    void RelicSpam(int i)
    {
        Quaternion root = Keys.transform.GetChild(i).rotation;

        GameObject Relic = Instantiate(RelicModel, Keys.transform.GetChild(i).position + new Vector3(0, RelicAbove, 0), root, Keys.transform.GetChild(i));
        Relic.transform.Rotate(RelicModelRotation);
    }

    void ScoreMake()
    {
        int ScoreBoardChilds = ScoreBoards.transform.childCount;
        for (int i = 0; i < gmdatas.Count && i < ScoreBoardChilds; i++)
        {
            Transform ScoreBoardChild = ScoreBoards.transform.GetChild(i);
            Transform scarabChild = ScoreBoardChild.transform.GetChild(0);

            MeshRenderer mr = scarabChild.GetComponent<MeshRenderer>();

            Material[] mats = mr.materials;
            mats[mathNumber] = Resources.Load<Material>(GSB_part + gmdatas[i].Scarab);

            mr.materials = mats;

            int[] numbs = { 100, 10, 1 };
            int score = gmdatas[i].Score;
            for (int j = 1; j < ScoreBoardChild.childCount; j++)
            {
                Transform scoreChild = ScoreBoardChild.GetChild(j);
                MeshRenderer mrScore = scoreChild.GetComponent<MeshRenderer>();

                mats = mrScore.materials;
                mats[mathNumber] = Resources.Load<Material>(numberIcon + score / numbs[j - 1]);

                mrScore.materials = mats;
                score -= (score / numbs[j - 1]) * numbs[j - 1];
            }
        }
    }

    void OpenGate(int i)
    {
        if (Gate.transform.childCount-1 < i)
        {
            return;
        }
        if((i+CurrentGameDatas.GetActualLevelFirstMapNumber() == ActualMapData.mapNumber - 1) && (ActualMapData.HawNewItem))
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
        if(ActualMapData.HawNewItem && CurrentGameDatas.ItemCount == GameStructure.maxMap)
        {
            castList.gameObject.SetActive(true);
        }
    }
}
