using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMap : MonoBehaviour {

    private readonly int missingItemWeight = 500;
    private readonly int missingScarabWeight = 100;
    private readonly int moreCmdWeight = 10;

    [SerializeField]
    private GateHeightData doorHighData;

    private CommandPanel commandPanel;

    public static bool normalGame = true;

    void Start () {
        ActualMapData.HawNewItem = false;
        commandPanel = CommandPanel.GetCommandPanel();
        if (commandPanel == null)
        {
            Debug.Log("FinisMap: CommandPanel is null!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartActions.inStart = false;

        if(other.gameObject.tag != SharedData.playerTag)
        {
            BoxController bc = other.GetComponent<BoxController>();
            if (bc != null)
            {
                doorHighData.RemoveTopBox();
            }
            Destroy(other.gameObject);
            return;
        }

        int realCommandsNumber = commandPanel.GetRealCommandsNumber();

        int scarabNumber = ScarabCalculate(realCommandsNumber);

        int thisGameScore = ScoreCalculate(realCommandsNumber , scarabNumber);

        ActualMapData.solvedMap = new MapResultData(thisGameScore, scarabNumber, ActualMapData.HaveItem ? 1 : 0, ActualMapData.solvedMap.ItemType);

        if (!normalGame)
        {
            SceneManager.LoadScene(GameStructure.resultScene);
            return;
        }

        if (CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Scarab < scarabNumber)
        {
            CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Scarab = scarabNumber;
        }
        if ((CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Score) < thisGameScore)
        {
            CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Score = thisGameScore;
        }

        Save();
        CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Item = (CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Item == SharedData.HaveItemNumber || ActualMapData.HaveItem) ? 1:0;
        CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].ItemType = ActualMapData.solvedMap.ItemType;

        ActualMapData.HaveItem = false;

        SceneManager.LoadScene(GameStructure.resultScene);
    }

    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(CurrentGameDatas.slotName, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.mapResults[ActualMapData.mapNumber - 1].Score = CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Score;
        data.mapResults[ActualMapData.mapNumber - 1].Scarab = CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Scarab;
        data.mapResults[ActualMapData.mapNumber - 1].Item = (CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Item == SharedData.HaveItemNumber) || ActualMapData.HaveItem ? 1 : 0;
        data.mapResults[ActualMapData.mapNumber - 1].ItemType = ActualMapData.solvedMap.ItemType;
        data.speed = CurrentGameDatas.speed;
        CurrentGameDatas.savedSpeed = CurrentGameDatas.speed;
        FileStream fileForSave = File.Create(CurrentGameDatas.slotName);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();

        ActualMapData.HawNewItem = (CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].Item == SharedData.notHaveItemNumber) && ActualMapData.HaveItem;
        if (ActualMapData.HawNewItem)
        {
            CurrentGameDatas.ItemCount++;
        }
    }

    private int ScoreCalculate(int realCommandsNumber, int scarabNumber)
    {
        int cmdNumber = (ActualMapData.Scarab3PartCmd - realCommandsNumber) >= 0 ? 0 : ActualMapData.Scarab3PartCmd - realCommandsNumber;

        int thisGameScore = GameStructure.maxPoint - (GameStructure.maxScarabNumber - scarabNumber) * missingScarabWeight + cmdNumber * moreCmdWeight - (ActualMapData.HaveItem ? 0 : missingItemWeight);
        if (thisGameScore < 0)
        {
            thisGameScore = 0;
        }
        else if (thisGameScore > GameStructure.maxPoint)
        {
            thisGameScore = GameStructure.maxPoint;
        }
        return thisGameScore;
    }

    private int ScarabCalculate(int realCommandsNumber)
    {
        int scarabNumber;
        if (realCommandsNumber <= ActualMapData.Scarab3PartCmd)
        {
            if (ActualMapData.HaveItem)
            {
                scarabNumber = GameStructure.maxScarabNumber;
            }
            else
            {
                scarabNumber = GameStructure.maxScarabNumber - 1;
            }
        }
        else if (realCommandsNumber <= ActualMapData.Scarab2PartCmd)
        {
            scarabNumber = GameStructure.maxScarabNumber - 1;
        }
        else
        {
            scarabNumber = 1;
        }
        return scarabNumber;
    }
}
