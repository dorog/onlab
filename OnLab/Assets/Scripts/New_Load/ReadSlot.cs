using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class ReadSlot : MonoBehaviour
{
    [SerializeField]
    private string fileName;
    [SerializeField]
    private Sprite img;
    [SerializeField]
    private GameObject SlotPanel;
    [SerializeField]
    private GameObject SlotText;
    [SerializeField]
    private GameObject SlotEmptyText;

    private GameDatas gmdata;
    private int summScore = 0;
    private int summBuggPart = 0;
    private int savedSpeed = 1;
    private int perfectMap = 0;
    private int solvedMap = 0;
    private int summKeys = 0;
    private int summGems = 0;

    private int onLevel;

    private string deviceFileLocation;

    private int hasItem = 0;
    private int emptySlot = 0;
    private int notEmptySlot = 1;

    public static bool isLoad = false;

    void Start()
    {
        if(fileName == "" || fileName == null)
        {
            Debug.LogError("ReadSlot: Filename is required!");
        }
        deviceFileLocation = Application.persistentDataPath + "/" + fileName;
        ReadBasedOnPlatform();
    }

    void ChangeSceneLoadBasedOnPlatform()
    {
        CurrentGameDatas.savedSpeed = savedSpeed;
        CurrentGameDatas.speed = savedSpeed;
        CurrentGameDatas.ItemCount = summKeys;
        CurrentGameDatas.CopyTheDatas(gmdata, deviceFileLocation);
        CurrentGameDatas.onLevel = onLevel;
        SceneManager.LoadScene(GameStructure.GetLevelName());
    }

    void ChangeSceneForNewBasedOnPlatform()
    { 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(deviceFileLocation, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.slotType = notEmptySlot;
        data.maxMap = GameStructure.maxMap;
        data.mapResults = new MapResult[GameStructure.maxMap];
        data.onLevel = GameStructure.startLevel;
        data.levelMapsNumber = GameStructure.levelMapsCount;
        for (int i = 0; i < data.mapResults.Length; i++)
        {
            data.mapResults[i] = new MapResult();
        }
        data.speed = SharedData.basicSpeed;
        FileStream fileForSave = File.Create(deviceFileLocation);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();

        gmdata = new GameDatas(GameStructure.maxMap);
        for (int i = 0; i < GameStructure.maxMap; i++)
        {
            gmdata.AddMapData(new MapDatas());
        }
        CurrentGameDatas.savedSpeed = SharedData.basicSpeed;
        CurrentGameDatas.speed = SharedData.basicSpeed;
        CurrentGameDatas.CopyTheDatas(gmdata, deviceFileLocation);
        SceneManager.LoadScene(GameStructure.levelOneName);
    }

    private void ReadBasedOnPlatform()
    {
        int slotState;
        int maxMap;
        PlayerSlotData ps;
        if (File.Exists(deviceFileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceFileLocation, FileMode.Open);
            PlayerSlotData psData = (PlayerSlotData)bf.Deserialize(file);
            file.Close();

            slotState = psData.slotType;
            maxMap = psData.maxMap;
            ps = psData;
            onLevel = psData.onLevel;
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceFileLocation, FileMode.Create);
            PlayerSlotData data = new PlayerSlotData();
            data.slotType = emptySlot;
            data.maxMap = GameStructure.maxMap;
            data.mapResults = new MapResult[GameStructure.maxMap];
            data.onLevel = GameStructure.startLevel;
            data.levelMapsNumber = GameStructure.levelMapsCount;
            for (int i = 0; i < data.mapResults.Length; i++)
            {
                data.mapResults[i] = new MapResult();
            }

            bf.Serialize(file, data);
            file.Close();

            slotState = data.slotType;
            maxMap = data.maxMap;

            ps = data;
        }

        savedSpeed = ps.speed;
        gmdata = new GameDatas(maxMap);

        Button myBtn = transform.GetComponent<Button>();

        if (slotState == emptySlot)
        {
            SlotText.SetActive(false);
            SlotPanel.SetActive(false);
            Image panelImg = GetComponent<Image>();
            Color tempColor = panelImg.color;
            tempColor.a = 0f;
            panelImg.color = tempColor;
            if (isLoad)
            {
                myBtn.interactable = false;
            }
        }
        else
        {
            if (isLoad)
            {
                ColorBlock highLited = myBtn.colors;
                highLited.highlightedColor = Color.yellow;
                myBtn.colors = highLited;
            }

            for (int i = 0; i < maxMap; i++)
            {
                bool item = ps.mapResults[i].Item == hasItem ? false : true;

                gmdata.AddMapData(new MapDatas(ps.mapResults[i].Score, ps.mapResults[i].ScarabNumber, item, ps.mapResults[i].ItemType));

                summScore += ps.mapResults[i].Score;
                summBuggPart += ps.mapResults[i].ScarabNumber;
                if (ps.mapResults[i].Item == SharedData.KeyType)
                {
                    summKeys += ps.mapResults[i].Item;
                }
                else
                {
                    summGems += ps.mapResults[i].Item;
                }

                if (ps.mapResults[i].ScarabNumber == GameStructure.maxScarab)
                {
                    perfectMap++;
                }
                if (ps.mapResults[i].ScarabNumber > GameStructure.scarabNumberForSolved)
                {
                    solvedMap++;
                }
            }

            Image background = GetComponent<Image>();
            background.sprite = img;

            SlotEmptyText.SetActive(false);
            Text textDatas = SlotText.GetComponent<Text>();
            textDatas.text = "Cleared maps: " + (solvedMap) + "\nScore: " + summScore + "\nScarab parts: " + summBuggPart + "\nPerfect Maps: " + perfectMap + "\nKeys: " + summKeys + "\nGems: " + summGems;
        }


        Button thisBtn = GetComponent<Button>();

        if (isLoad)
        {
            thisBtn.onClick.AddListener(ChangeSceneLoadBasedOnPlatform);
        }
        else
        {
            thisBtn.onClick.AddListener(ChangeSceneForNewBasedOnPlatform);
        }
    }
}
