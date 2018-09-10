using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMap(int mapNumber)
    {
        CurrentGameDatas.mapNumber = mapNumber;
        SceneManager.LoadScene(Configuration.mapScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetIsLoad(bool isLoad)
    {
        Configuration.isLoad = isLoad;
    }
}
