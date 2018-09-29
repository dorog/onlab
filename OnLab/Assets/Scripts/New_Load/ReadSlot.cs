using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class ReadSlot : MonoBehaviour
{
    public string fileName;
    public Sprite img;
    public int fontSize = 20;
    public int padding = 160;
    public GameObject SlotPanel;
    public GameObject SlotText;

    private GameDatas gmdata;
    private int summScore = 0;
    private int summBuggPart = 0;
    private int savedSpeed = 1;
    private int perfectMap = 0;
    private int solvedMap = 0;
    private int summKeys = 0;

    void Start()
    {
        ReadBasedOnPlatform();
    }

    void ChangeSceneLoadBasedOnPlatform()
    {
        CurrentGameDatas.savedSpeed = savedSpeed;
        CurrentGameDatas.speed = savedSpeed;
        CurrentGameDatas.ItemCount = summKeys;
        CurrentGameDatas.CopyTheDatas(gmdata, Application.persistentDataPath + "/" + fileName);
        SceneManager.LoadScene(Configuration.mapGuideScene);
    }

    void ChangeSceneForNewBasedOnPlatform()
    {
        string fileName = Application.persistentDataPath + "/" + this.fileName;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(fileName, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.slotType = Configuration.notEmptySlot;
        data.maxMap = Configuration.maxMap;
        data.mapResults = new MapResult[Configuration.maxMap];
        for (int i = 0; i < data.mapResults.Length; i++)
        {
            data.mapResults[i] = new MapResult();
        }
        data.speed = Configuration.basicSpeed;
        FileStream fileForSave = File.Create(fileName);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();

        gmdata = new GameDatas(CurrentGameDatas.maxMap);
        for (int i = 0; i < CurrentGameDatas.maxMap; i++)
        {
            gmdata.AddMapData(new MapDatas());
        }
        CurrentGameDatas.savedSpeed = Configuration.basicSpeed;
        CurrentGameDatas.speed = Configuration.basicSpeed;
        CurrentGameDatas.CopyTheDatas(gmdata, fileName);
        SceneManager.LoadScene(Configuration.mapGuideScene);
    }

    private void ReadBasedOnPlatform()
    {
        string fileName = Application.persistentDataPath + "/" + this.fileName;

        int slotState;
        int maxMap;
        PlayerSlotData ps;
        if (File.Exists(fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileName, FileMode.Open);
            PlayerSlotData psData = (PlayerSlotData)bf.Deserialize(file);
            file.Close();

            slotState = psData.slotType;
            maxMap = psData.maxMap;
            ps = psData;
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileName, FileMode.Create);
            PlayerSlotData data = new PlayerSlotData();
            data.slotType = Configuration.emptySlot;
            data.maxMap = Configuration.maxMap;
            data.mapResults = new MapResult[Configuration.maxMap];
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
        CurrentGameDatas.maxMap = maxMap;
        gmdata = new GameDatas(maxMap);

        Button myBtn = transform.GetComponent<Button>();

        if (slotState == Configuration.emptySlot)
        {
            Text textData = SlotText.GetComponent<Text>();
            textData.fontSize = textData.fontSize * Screen.height / Configuration.bestScreenHeight;
            Image panelImg = GetComponent<Image>();
            Color tempColor = panelImg.color;
            tempColor.a = 0f;
            panelImg.color = tempColor;
            if (Configuration.isLoad)
            {
                myBtn.interactable = false;
            }
        }
        else
        {
            if (Configuration.isLoad)
            {
                ColorBlock highLited = myBtn.colors;
                highLited.highlightedColor = Color.yellow;
                myBtn.colors = highLited;
            }

            for (int i = 0; i < maxMap; i++)
            {
                bool key = ps.mapResults[i].Item == Configuration.hasItem ? false : true;

                gmdata.AddMapData(new MapDatas(ps.mapResults[i].Score, ps.mapResults[i].ScarabNumber, key, ps.mapResults[i].ItemType));

                summScore += ps.mapResults[i].Score;
                summBuggPart += ps.mapResults[i].ScarabNumber;
                summKeys += ps.mapResults[i].Item;
                if (ps.mapResults[i].ScarabNumber == Configuration.maxScarab)
                {
                    perfectMap++;
                }
                if (ps.mapResults[i].ScarabNumber > Configuration.scarabNumberForSolved)
                {
                    solvedMap++;
                }
            }

            //last map, if all map has been solved i wont use this. UI: why not?


            Image background = GetComponent<Image>();
            background.sprite = img;

            RectTransform textRt = SlotText.GetComponent<RectTransform>();
            textRt.offsetMin = new Vector2(0, -padding * Screen.height / Configuration.bestScreenHeight);
            textRt.offsetMax = new Vector2(0, -padding * Screen.height / Configuration.bestScreenHeight);

            Text textDatas = SlotText.GetComponent<Text>();
            textDatas.color = Color.yellow;
            textDatas.text = "Cleared maps: " + (solvedMap) + "\nScore: " + summScore + "\nScarab parts: " + summBuggPart + "\nPerfect Maps: " + perfectMap + "\nKeys: " + summKeys;
            textDatas.fontSize = fontSize * Screen.height / Configuration.bestScreenHeight;
        }


        Button thisBtn = this.GetComponent<Button>();

        if (Configuration.isLoad)
        {
            thisBtn.onClick.AddListener(ChangeSceneLoadBasedOnPlatform);
        }
        else
        {
            thisBtn.onClick.AddListener(ChangeSceneForNewBasedOnPlatform);
        }
    }
}
