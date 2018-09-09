using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadSlot : MonoBehaviour {

    public string filename;
    public Sprite img;
    private int summScore = 0;
    private int summBuggPart = 0;
    private int perfectMap = 0;
    private int solvedMap = 0;
    private int summKeys=0;
    public GameDatas gmdata;
    public bool forload = true;
    public int fontSize = 20;
    public int padding = 160;

    void Start () {
        try
        {   
            using (StreamReader sr = new StreamReader(filename))
            {
                String line = sr.ReadToEnd();
                string[] datas = line.Split('\n');

                int slotState = Convert.ToInt32(datas[0]);
                int maxMap = Convert.ToInt32(datas[1]);
                CurrentGameDatas.maxMap = maxMap;
                gmdata = new GameDatas(maxMap);

                if (slotState == 0)
                {
                    Image panelImg = GameObject.Find(this.name).transform.GetChild(0).GetComponent<Image>();
                    Color tempColor = panelImg.color;
                    tempColor.a = 0f;
                    panelImg.color = tempColor;
                    if (forload)
                    {
                        this.transform.GetComponent<Button>().interactable = false;
                    }
                }
                else
                {
                    gmdata = new GameDatas(maxMap);
                    for (int i=0; i<maxMap; i++)
                    {
                        string[] row = datas[i + 2].Split('\t');
                        bool key = true;
                        if (Convert.ToInt32(row[2]) == 0)
                        {
                            key = false;
                        }
                        gmdata.AddMapData(new MapDatas(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), key));

                        summScore += Convert.ToInt32(row[0]);
                        summBuggPart += Convert.ToInt32(row[1]);
                        summKeys += Convert.ToInt32(row[2]);
                        if (Convert.ToInt32(row[1]) == 3)
                        {
                            perfectMap++;
                        }
                        if (Convert.ToInt32(row[1]) > 0){
                            solvedMap++;
                        }
                    }

                    //last map, if all map has been solved i wont use this.
                    

                    Image background = this.transform.GetComponent<Image>();
                    background.sprite = img;
                    Text textDatas = GameObject.Find(this.name).transform.GetChild(1).GetComponent<Text>();
                    Transform textTransform = GameObject.Find(this.name).transform.GetChild(1).transform;
                    textTransform.position += Vector3.up * -padding * Screen.height / Configuration.bestScreenHeight;
                    textDatas.fontSize = fontSize * Screen.height / Configuration.bestScreenHeight;
                    textDatas.color = Color.yellow;
                    textDatas.text = "Cleared maps: "+(solvedMap)+"\nScore: "+summScore+"\nScarab parts: "+summBuggPart+"\nPerfect Maps: "+perfectMap+"\nKeys: "+summKeys;
                }


                Button thisBtn = this.GetComponent<Button>();

                if (forload)
                {
                    thisBtn.onClick.AddListener(ChangeSceneLoad);
                }
                else
                {
                    thisBtn.onClick.AddListener(ChangeSceneForNew);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }

    }

    void ChangeSceneLoad()
    {
        CurrentGameDatas.KeyNumber = summKeys;
        CurrentGameDatas.CopyTheDatas(gmdata, filename);
        SceneManager.LoadScene(Configuration.mapGuideScene);
    }

    void ChangeSceneForNew()
    {

        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(1);
            sw.WriteLine(CurrentGameDatas.maxMap);
            for(int i=0; i<CurrentGameDatas.maxMap; i++)
            {
                sw.WriteLine(0 + "\t" + 0 +"\t" + 0);
            }
        }

        gmdata = new GameDatas(CurrentGameDatas.maxMap);
        for(int i=0; i<CurrentGameDatas.maxMap; i++)
        {
            gmdata.AddMapData(new MapDatas());
        }
        
        CurrentGameDatas.CopyTheDatas(gmdata, filename);
        SceneManager.LoadScene(Configuration.mapGuideScene);
    }
}
