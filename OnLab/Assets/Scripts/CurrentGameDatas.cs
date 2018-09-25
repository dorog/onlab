using System.Collections.Generic;

public static class CurrentGameDatas
{


    static public int mapNumber = 9;
    static public int maxMap = 1;
    static public int Scarab3PartCmd;
    static public int Scarab2PartCmd;
    static public bool HaveItem = false;
    static public List<MapDatas> mapDatas = new List<MapDatas>();
    static public bool HawNewItem = false;
    static public int ItemCount = 0;
    static public string slotName;
    static public int savedSpeed = 1;
    static public int speed = 1;

    static public MapDatas solvedMap = new MapDatas();

    static public void CopyTheDatas(GameDatas data, string filename)
    {
        HawNewItem = false;
        slotName = filename;
        mapDatas.Clear();
        maxMap = data.maxMap;
        for (int i = 0; i < data.mapDatas.Count; i++)
        {
            mapDatas.Add(new MapDatas(data.mapDatas[i].mapScore, data.mapDatas[i].scarab, data.mapDatas[i].item, data.mapDatas[i].itemType));
        }
    }
}
