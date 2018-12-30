using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class ExtraButtons : MonoBehaviour {

    [SerializeField]
    private Image deleteBtn;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private GameObject noMapText;

    public static bool deleteMode = false;

    private void Update()
    {
        if (content.childCount == 0 && !noMapText.activeSelf)
        {
            noMapText.SetActive(true);
        }
        else if(content.childCount != 0 && noMapText.activeSelf)
        {
            noMapText.SetActive(false);
        }
    }

    public void DeleteClick()
    {
        ExtraButtons.deleteMode = !ExtraButtons.deleteMode;
        deleteBtn.color = ExtraButtons.deleteMode ? Color.red : Color.white;
    }

    public void ReturnToMainMenu()
    {
        SceneLoader.LoadSceneStatic(GameStructure.mainMenuName);
    }

    public void GoToMapDesignerScene()
    {
         SceneLoader.LoadSceneStatic(GameStructure.mapDesignerName);
    }

    public void DeleteAll()
    {
        string deviceCreatedMapFileLocation = Application.persistentDataPath + SharedData.deviceCreatedMapFileLocation;
        if (File.Exists(deviceCreatedMapFileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceCreatedMapFileLocation, FileMode.Open);
            CreatedMaps maps = (CreatedMaps)bf.Deserialize(file);
            file.Close();

            if (maps.maps == null)
            {
                return;
            }

            maps.maps = null;

            FileStream fileForSave = File.Create(deviceCreatedMapFileLocation);
            bf.Serialize(fileForSave, maps);
            fileForSave.Close();

            for (int i = 0; i < content.childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
            noMapText.SetActive(true);
        }
    }
}
