using System.Collections.Generic;

public static class CurrentGameDatas{

    
    static public int mapNumber = 8;
    static public int maxMap = 1;
    static public int Scarab3PartCmd;
    static public int Scarab2PartCmd;
    static public bool HaveKey = false;
    static public List<MapDatas> mapDatas = new List<MapDatas>();
    static public bool HaveNewKey = false;
    static public int KeyNumber = 0;
    static public string slotName;

    static public MapDatas solvedMap = new MapDatas();

    static public void CopyTheDatas(GameDatas data, string filename)
    {
        slotName = filename;
        mapDatas.Clear();
        maxMap = data.maxMap;
        for(int i=0; i<data.mapDatas.Count; i++)
        {
            mapDatas.Add(new MapDatas(data.mapDatas[i].mapScore, data.mapDatas[i].scarab, data.mapDatas[i].key));
        }
    }
}
