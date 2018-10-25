using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CurrentGameDatas
{
    static public List<MapDatas> mapDatas = new List<MapDatas>();
    static public int ItemCount = 0;
    static public string slotName;
    static public int savedSpeed = 1;
    static public int speed = 1;
    static public int onLevel = 1;

    static public void CopyTheDatas(GameDatas data, string filename)
    {
        slotName = filename;
        mapDatas.Clear();
        for (int i = 0; i < data.mapDatas.Count; i++)
        {
            mapDatas.Add(new MapDatas(data.mapDatas[i].mapScore, data.mapDatas[i].scarab, data.mapDatas[i].item, data.mapDatas[i].itemType));
        }
    }

    static public void SaveLevel()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(slotName, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.onLevel = onLevel;
        FileStream fileForSave = File.Create(slotName);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();
    }

    static public void SaveSpeed()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(slotName, FileMode.Open);
        PlayerSlotData data = (PlayerSlotData)bf.Deserialize(file);
        file.Close();

        data.speed = speed;
        FileStream fileForSave = File.Create(slotName);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();
        savedSpeed = speed;
    }

    static public int GetActualLevelMapCount()
    {
        if(onLevel > GameStructure.levelMapsCount.Length)
        {
            return 0;
        }
        return GameStructure.levelMapsCount[onLevel - 1];
    }

    static public int GetActualLevelFirstMapNumber()
    {
        int firstLevel = 0;
        for(int i=1; i<onLevel; i++)
        {
            firstLevel += GameStructure.levelMapsCount[i-1];
        }
        return firstLevel;
    }

    static public int GetActualLevelLastMapNumber()
    {
        return GetActualLevelFirstMapNumber() + GameStructure.levelMapsCount[onLevel - 1];
    }
}
