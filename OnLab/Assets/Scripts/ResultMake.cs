using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMake : MonoBehaviour {

    SceneLoader scLoader;

    // Use this for initialization
    void Start () {
        GameObject finishPanel = GameObject.Find(Configuration.finishedPanelName);
        scLoader = GameObject.Find(Configuration.loadSceneGOName).GetComponent<SceneLoader>();

        finishPanel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(Configuration.GSB_sprite + CurrentGameDatas.solvedMap.scarab);
        finishPanel.transform.GetChild(1).GetComponent<Text>().text = "Score: "+ CurrentGameDatas.solvedMap.mapScore;
        finishPanel.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(LoadSameScene);
    }

    public void LoadSameScene()
    {
        scLoader.LoadMap(CurrentGameDatas.mapNumber);
    }
}
