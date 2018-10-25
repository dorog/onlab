using UnityEngine;
using UnityEngine.UI;

public class GuideMake : MonoBehaviour {

    private GameDatas gmdatas;
    private string GSB_part = "Map_guide/GSB_part";
    private string numberIcon = "Map_guide/number";

    [Header("Map objects")]
    [SerializeField]
    private GameObject ScoreBoards;
    [SerializeField]
    private GameObject Gate;
    [SerializeField]
    private GameObject Keys;
    [Header("Item setting")]
    [SerializeField]
    private GameObject KeyModel;
    [SerializeField]
    private GameObject GemModel;
    [SerializeField]
    private int itemAboveHolder = 50;

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
        gmdatas = new GameDatas(mapsNumber);

        int firstLevelNumber = CurrentGameDatas.GetActualLevelFirstMapNumber();
        int j = 0;
        for(int i= firstLevelNumber; i < firstLevelNumber + mapsNumber; i++)
        {
            gmdatas.AddMapData(new MapDatas(CurrentGameDatas.mapDatas[i].mapScore, CurrentGameDatas.mapDatas[i].scarab, CurrentGameDatas.mapDatas[i].item, CurrentGameDatas.mapDatas[i].itemType));
            if (CurrentGameDatas.mapDatas[i].item)
            {
                if (CurrentGameDatas.mapDatas[i].itemType == SharedData.KeyType)
                {
                    KeySpam(j);
                }
                else if (CurrentGameDatas.mapDatas[i].itemType == SharedData.GemType)
                {
                    GemSpam(j);
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
        int ScoreBoardChilds = ScoreBoards.transform.childCount;
        for (int i = 0; i < gmdatas.maxMap && i < ScoreBoardChilds; i++)
        {
            Transform ScoreBoardChild = ScoreBoards.transform.GetChild(i);
            Transform scarabChild = ScoreBoardChild.transform.GetChild(0);

            MeshRenderer mr = scarabChild.GetComponent<MeshRenderer>();

            Material[] mats = mr.materials;
            mats[mathNumber] = Resources.Load<Material>(GSB_part + gmdatas.mapDatas[i].scarab);

            mr.materials = mats;

            int[] numbs = { 100, 10, 1 };
            int score = gmdatas.mapDatas[i].mapScore;
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
