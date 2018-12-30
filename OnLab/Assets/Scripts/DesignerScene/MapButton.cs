using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;

public class MapButton : MonoBehaviour {

    public int MapIndex { get; set; }

    public void OnClick()
    {
        if (ExtraButtons.deleteMode)
        {
            RemoveThisMap();
            Destroy(gameObject);
            return;
        }
        ActualMapData.mapNumber = GameStructure.createdMapNumber;
        ActualMapData.createdMapIndex = MapIndex;
        SceneLoader.LoadSceneStatic(GameStructure.mapName);
    }

    private void RemoveThisMap()
    {
        string deviceCreatedMapFileLocation = Application.persistentDataPath + SharedData.deviceCreatedMapFileLocation;
        if (File.Exists(deviceCreatedMapFileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceCreatedMapFileLocation, FileMode.Open);
            CreatedMaps maps = (CreatedMaps)bf.Deserialize(file);
            file.Close();

            if (maps.maps == null || maps.maps.Length-1 < MapIndex)
            {
                return;
            }

            List<MapSer> newList = maps.maps.ToList();
            newList.RemoveAt(MapIndex);
            maps.maps = newList.ToArray();

            FileStream fileForSave = File.Create(deviceCreatedMapFileLocation);
            bf.Serialize(fileForSave, maps);
            fileForSave.Close();
        }
    }
}
