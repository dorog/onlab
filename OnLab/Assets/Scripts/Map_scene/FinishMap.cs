using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FinishMap : MonoBehaviour {

    public int maxPoint = 999;
    public int maxScarabNumber = 3;
    public int missingItemWeight = 500;
    public int missingScarabWeight = 100;
    public int moreCmdWeight = 10;

    public DoorHighData doorHighData;

    // Use this for initialization
    void Start () {
        CurrentGameDatas.HawNewItem = false;
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.name != Configuration.characterName)
        {
            BoxController bc = other.GetComponent<BoxController>();
            if (bc != null)
            {
                doorHighData.RemoveTopBox();
            }
            Destroy(other.gameObject);
            return;
        }
        //Calulate datas
        CommandPanel slotPanel = GameObject.Find(Configuration.cmdPanelManagerName).GetComponent<CommandPanel>();
        SceneLoader scLoader = GameObject.Find(Configuration.loadSceneGOName).GetComponent<SceneLoader>();

        int realCommandsNumber = slotPanel.GetRealCommandsNumber();

        int scarabNumber = 0;
        if (realCommandsNumber <= CurrentGameDatas.Scarab3PartCmd)
        {
            if (CurrentGameDatas.HaveItem)
            {
                scarabNumber = maxScarabNumber;
            }
            else
            {
                scarabNumber = maxScarabNumber-1;
            }
        }
        else if (realCommandsNumber <= CurrentGameDatas.Scarab2PartCmd)
        {
            scarabNumber = maxScarabNumber-1;
        }
        else
        {
            scarabNumber = 1;
        }

        int cmdNumber = (CurrentGameDatas.Scarab3PartCmd - realCommandsNumber) >= 0 ? 0 : CurrentGameDatas.Scarab3PartCmd - realCommandsNumber;
        int thisGameScore = maxPoint - (maxScarabNumber - scarabNumber) * missingScarabWeight - cmdNumber * moreCmdWeight - (CurrentGameDatas.HaveItem ? 0 : missingItemWeight);

        if (CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab < scarabNumber)
        {
            CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab = scarabNumber;
        }
        if ((CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore) < thisGameScore)
        {
            if (thisGameScore < 0)
            {
                thisGameScore = 0;
            }
            else if(thisGameScore > maxPoint)
            {
                thisGameScore = maxPoint;
            }
            CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore = thisGameScore; //calculate
        }

        Save();
        CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].item = (CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].item) || CurrentGameDatas.HaveItem;
        CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].itemType = CurrentGameDatas.solvedMap.itemType;

        CurrentGameDatas.solvedMap = new MapDatas(thisGameScore, scarabNumber, CurrentGameDatas.HaveItem, CurrentGameDatas.solvedMap.itemType);
        CurrentGameDatas.HaveItem = false;

        scLoader.LoadScene(Configuration.resultScene);
    }

    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(CurrentGameDatas.slotName, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.mapResults[CurrentGameDatas.mapNumber - 1].Score = CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].mapScore;
        data.mapResults[CurrentGameDatas.mapNumber - 1].ScarabNumber = CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].scarab;
        data.mapResults[CurrentGameDatas.mapNumber - 1].Item = (CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].item) || CurrentGameDatas.HaveItem ? 1 : 0;
        data.mapResults[CurrentGameDatas.mapNumber - 1].ItemType = CurrentGameDatas.solvedMap.itemType;
        data.speed = CurrentGameDatas.speed;
        CurrentGameDatas.savedSpeed = CurrentGameDatas.speed;
        FileStream fileForSave = File.Create(CurrentGameDatas.slotName);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();

        CurrentGameDatas.HawNewItem = !CurrentGameDatas.mapDatas[CurrentGameDatas.mapNumber - 1].item && CurrentGameDatas.HaveItem;
        if (CurrentGameDatas.HawNewItem)
        {
            CurrentGameDatas.ItemCount++;
        }
    }
}
