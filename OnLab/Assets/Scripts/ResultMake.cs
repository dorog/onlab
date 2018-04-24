using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMake : MonoBehaviour {

    SceneLoader scLoader;

    // Use this for initialization
    void Start () {
        GameObject finishPanel = GameObject.Find("FinishedPanel");
        scLoader = GameObject.Find("LoadSceneGO").GetComponent<SceneLoader>();

        finishPanel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Map_guide/GSB" + CurrentGameDatas.solvedMap.scarab);
        finishPanel.transform.GetChild(1).GetComponent<Text>().text = "Score: "+ CurrentGameDatas.solvedMap.mapScore;
        finishPanel.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(LoadSameScene);
    }

    public void LoadSameScene()
    {
        scLoader.LoadMap(CurrentGameDatas.mapNumber);
    }
}
