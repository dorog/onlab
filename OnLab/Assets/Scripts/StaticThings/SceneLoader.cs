using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadSceneAndSaveSpeed()
    {
        if(CurrentGameDatas.savedSpeed != CurrentGameDatas.speed)
        {
            CurrentGameDatas.SaveSpeed();
        }
        SceneManager.LoadScene(Configuration.GetLevelName());
    }

	public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAndTimeScaleUsedGame(string sceneName)
    {
        Time.timeScale = CurrentGameDatas.speed;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMapTimeScaleUsed(int mapNumber)
    {
        CurrentGameDatas.mapNumber = mapNumber;
        LoadSceneAndTimeScaleUsedGame(Configuration.mapName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetIsLoad(bool isLoad)
    {
        Configuration.isLoad = isLoad;
    }

    public void LoadActualMap()
    {
        LoadScene(Configuration.GetLevelName());
    }
}
