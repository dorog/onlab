﻿using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

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

    private List<MapResultData> gmdata = new List<MapResultData>();
    private int summScore = 0;
    private int summBuggPart = 0;
    private int savedSpeed = 1;
    private int perfectMap = 0;
    private int solvedMap = 0;
    private int summKeys = 0;
    private int summGems = 0;
    private int summRelic = 0;

    private int onLevel;

    private string deviceFileLocation;

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
        Read();
    }

    void ChangeSceneLoad()
    {
        CurrentGameDatas.savedSpeed = savedSpeed;
        CurrentGameDatas.speed = savedSpeed;
        CurrentGameDatas.ItemCount = summKeys + summGems + summRelic;
        CurrentGameDatas.CopyTheDatas(gmdata, deviceFileLocation);
        CurrentGameDatas.onLevel = onLevel;
        SceneLoader.LoadGuideAndSetMode();
    }

    void ChangeSceneForNew()
    { 
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(deviceFileLocation, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.slotType = notEmptySlot;
        data.maxMap = GameStructure.maxMap;
        data.mapResults = new MapResultData[GameStructure.maxMap];
        data.onLevel = GameStructure.startLevel;
        for (int i = 0; i < data.mapResults.Length; i++)
        {
            data.mapResults[i] = new MapResultData();
        }
        data.speed = SharedData.basicSpeed;
        FileStream fileForSave = File.Create(deviceFileLocation);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();

        for (int i = 0; i < GameStructure.maxMap; i++)
        {
            gmdata.Add(new MapResultData());
        }
        CurrentGameDatas.savedSpeed = SharedData.basicSpeed;
        CurrentGameDatas.speed = SharedData.basicSpeed;
        CurrentGameDatas.CopyTheDatas(gmdata, deviceFileLocation);
        SceneLoader.LoadGuideAndSetMode();
    }

    private void Read()
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
            data.mapResults = new MapResultData[GameStructure.maxMap];
            data.onLevel = GameStructure.startLevel;
            for (int i = 0; i < data.mapResults.Length; i++)
            {
                data.mapResults[i] = new MapResultData();
            }

            bf.Serialize(file, data);
            file.Close();

            slotState = data.slotType;
            maxMap = data.maxMap;

            ps = data;
        }

        savedSpeed = ps.speed;

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

                gmdata.Add(new MapResultData(ps.mapResults[i].Score, ps.mapResults[i].Scarab, ps.mapResults[i].Item, ps.mapResults[i].ItemType));

                summScore += ps.mapResults[i].Score;
                summBuggPart += ps.mapResults[i].Scarab;
                if (ps.mapResults[i].ItemType == SharedData.KeyType)
                {
                    summKeys += ps.mapResults[i].Item;
                }
                else if(ps.mapResults[i].ItemType == SharedData.GemType)
                {
                    summGems += ps.mapResults[i].Item;
                }
                else
                {
                    summRelic += ps.mapResults[i].Item;
                }

                if (ps.mapResults[i].Scarab == GameStructure.maxScarab)
                {
                    perfectMap++;
                }
                if (ps.mapResults[i].Scarab > GameStructure.scarabNumberForSolved)
                {
                    solvedMap++;
                }
            }

            Image background = GetComponent<Image>();
            background.sprite = img;

            SlotEmptyText.SetActive(false);
            Text textDatas = SlotText.GetComponent<Text>();
            textDatas.text = "Cleared maps: " + (solvedMap) + "\nScore: " + summScore + "\nScarab parts: " + summBuggPart + "\nPerfect Maps: " + perfectMap + "\nKeys: " + summKeys + "\nRelics: " + summRelic + "\nGems: " + summGems;
        }


        Button thisBtn = GetComponent<Button>();

        if (isLoad)
        {
            thisBtn.onClick.AddListener(ChangeSceneLoad);
        }
        else
        {
            thisBtn.onClick.AddListener(ChangeSceneForNew);
        }
    }
}
