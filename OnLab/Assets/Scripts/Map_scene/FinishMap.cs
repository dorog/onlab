using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMap : MonoBehaviour {

    private readonly int missingItemWeight = 500;
    private readonly int missingScarabWeight = 100;
    private readonly int moreCmdWeight = 10;

    [SerializeField]
    private DoorHighData doorHighData;

    private CommandPanel slotPanel;

    void Start () {
        ActualMapData.HawNewItem = false;
        slotPanel = CommandPanel.GetCommandPanel();
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

        int realCommandsNumber = slotPanel.GetRealCommandsNumber();

        int scarabNumber = 0;
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

        int cmdNumber = (ActualMapData.Scarab3PartCmd - realCommandsNumber) >= 0 ? 0 : ActualMapData.Scarab3PartCmd - realCommandsNumber;
        int thisGameScore = GameStructure.maxPoint - (GameStructure.maxScarabNumber - scarabNumber) * missingScarabWeight - cmdNumber * moreCmdWeight - (ActualMapData.HaveItem ? 0 : missingItemWeight);

        if (CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].scarab < scarabNumber)
        {
            CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].scarab = scarabNumber;
        }
        if ((CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].mapScore) < thisGameScore)
        {
            if (thisGameScore < 0)
            {
                thisGameScore = 0;
            }
            else if(thisGameScore > GameStructure.maxPoint)
            {
                thisGameScore = GameStructure.maxPoint;
            }
            CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].mapScore = thisGameScore;
        }

        Save();
        CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].item = (CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].item) || ActualMapData.HaveItem;
        CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].itemType = ActualMapData.solvedMap.itemType;

        ActualMapData.solvedMap = new MapDatas(thisGameScore, scarabNumber, ActualMapData.HaveItem, ActualMapData.solvedMap.itemType);
        ActualMapData.HaveItem = false;

        SceneManager.LoadScene(GameStructure.resultScene);
    }

    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(CurrentGameDatas.slotName, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.mapResults[ActualMapData.mapNumber - 1].Score = CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].mapScore;
        data.mapResults[ActualMapData.mapNumber - 1].ScarabNumber = CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].scarab;
        data.mapResults[ActualMapData.mapNumber - 1].Item = (CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].item) || ActualMapData.HaveItem ? 1 : 0;
        data.mapResults[ActualMapData.mapNumber - 1].ItemType = ActualMapData.solvedMap.itemType;
        data.speed = CurrentGameDatas.speed;
        CurrentGameDatas.savedSpeed = CurrentGameDatas.speed;
        FileStream fileForSave = File.Create(CurrentGameDatas.slotName);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();

        ActualMapData.HawNewItem = !CurrentGameDatas.mapDatas[ActualMapData.mapNumber - 1].item && ActualMapData.HaveItem;
        if (ActualMapData.HawNewItem)
        {
            CurrentGameDatas.ItemCount++;
        }
    }
}
