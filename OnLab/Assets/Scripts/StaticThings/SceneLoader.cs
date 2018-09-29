using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadSceneAndSaveSpeed(string sceneName)
    {
        if(CurrentGameDatas.savedSpeed != CurrentGameDatas.speed)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(CurrentGameDatas.slotName, FileMode.Open);
            PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
            file.Close();

            data.speed = CurrentGameDatas.speed;
            FileStream fileForSave = File.Create(CurrentGameDatas.slotName);
            bf.Serialize(fileForSave, data);
            fileForSave.Close();
            CurrentGameDatas.savedSpeed = CurrentGameDatas.speed;
        }
        LoadScene(sceneName);
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
