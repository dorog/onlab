using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CreatedMapReader : MonoBehaviour {

    [SerializeField]
    private MapButton mapButton;
    [SerializeField]
    private Transform scrollViewContent;

    private void Awake()
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

            for (int i = 0; i < maps.maps.Length; i++)
            {
                GameObject mapButtonGO = Instantiate(mapButton.gameObject, scrollViewContent);
                MapButton mapButtonScript = mapButtonGO.GetComponent<MapButton>();
                mapButtonScript.MapIndex = i;
                Text text = mapButtonGO.GetComponentInChildren<Text>();
                if (text != null)
                {
                    text.text = maps.maps[i].name;
                }
            }
        }
    }

    private void Start()
    {
        Time.timeScale = SharedData.basicSpeed;
    }
}
