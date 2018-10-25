using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadSceneAndSaveSpeed()
    {
        if(CurrentGameDatas.savedSpeed != CurrentGameDatas.speed)
        {
            CurrentGameDatas.SaveSpeed();
        }
        SceneManager.LoadScene(GameStructure.GetLevelName());
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public static void LoadSceneStatic(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadSceneAndTimeScaleUsedGame(string sceneName)
    {
        Time.timeScale = CurrentGameDatas.speed;
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadMapTimeScaleUsed(int mapNumber)
    {
        ActualMapData.mapNumber = mapNumber;
        LoadSceneAndTimeScaleUsedGame(GameStructure.mapName);
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public void SetIsLoad(bool isLoad)
    {
        ReadSlot.isLoad = isLoad;
    }

    public void LoadActualMap()
    {
        LoadSceneStatic(GameStructure.GetLevelName());
    }
}
