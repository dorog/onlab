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
    public GameDatas gmdata;
    public bool forload = true;

    void Start () {
        try
        {   
            using (StreamReader sr = new StreamReader(filename))
            {
                String line = sr.ReadToEnd();
                string[] datas = line.Split('\n');

                int latestMap = Convert.ToInt32(datas[0]);
                if (latestMap == 0)
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
                    gmdata = new GameDatas(latestMap);
                    for (int i=0; i<latestMap-1; i++)
                    {
                        string[] row = datas[i + 1].Split('\t');
                        gmdata.AddMapData(new MapDatas(Convert.ToInt32(row[0]), Convert.ToInt32(row[1])));

                        summScore += Convert.ToInt32(row[0]);
                        summBuggPart += Convert.ToInt32(row[1]);
                        if (Convert.ToInt32(row[1]) == 3)
                        {
                            perfectMap++;
                        }
                    }

                    //last map, if all map has been solved i wont use this.
                    gmdata.AddMapData(new MapDatas());

                    Image background = this.transform.GetComponent<Image>();
                    background.sprite = img;
                    Text textDatas = GameObject.Find(this.name).transform.GetChild(1).GetComponent<Text>();
                    Transform textTransform = GameObject.Find(this.name).transform.GetChild(1).transform;
                    textTransform.position += Vector3.up*-150;
                    textDatas.fontSize = 20;
                    textDatas.color = Color.yellow;
                    textDatas.text = "Cleared maps: "+(latestMap-1)+"\nScore: "+summScore+"\nScarab parts: "+summBuggPart+"\nPerfect Maps: "+perfectMap;

                    
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

        CurrentGameDatas.CopyTheDatas(gmdata, filename);
        SceneManager.LoadScene("Map_guide");
    }

    void ChangeSceneForNew()
    {

        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(1);
            sw.WriteLine(0+"\t"+0);
        }

        gmdata = new GameDatas(1);
        gmdata.AddMapData(new MapDatas());

        CurrentGameDatas.CopyTheDatas(gmdata, filename);
        SceneManager.LoadScene("Map_guide");
    }
}
