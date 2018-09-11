using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAndTimeScaleUsedGame(string sceneName)
    {
        Time.timeScale = Configuration.speed;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMap(int mapNumber)
    {
        CurrentGameDatas.mapNumber = mapNumber;
        SceneManager.LoadScene(Configuration.mapScene);
    }

    public void LoadMapTimeScaleUsed(int mapNumber)
    {
        CurrentGameDatas.mapNumber = mapNumber;
        LoadSceneAndTimeScaleUsedGame(Configuration.mapScene);
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
