using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CurrentGameDatas{

    static public string slotName = "Slot0.txt";
    static public string buggSystemFile = "ScarabCmdMin.txt";
    static public int mapNumber = 1;
    static public int lastMap = 1;
    static public List<MapDatas> mapDatas = new List<MapDatas>();
    static public int maxLevel = 13;

    static public MapDatas solvedMap = new MapDatas();

    static public void CopyTheDatas(GameDatas data, string filename)
    {
        using (StreamReader sr = new StreamReader(CurrentGameDatas.buggSystemFile))
        {
            string line = sr.ReadToEnd();
            string[] datas = line.Split('\n');
            maxLevel = datas.Length;
            Debug.Log(maxLevel);
        }
        slotName = filename;
        mapDatas.Clear();
        lastMap = data.lastMap;
        for(int i=0; i<data.mapDatas.Count; i++)
        {
            mapDatas.Add(new MapDatas(data.mapDatas[i].mapScore, data.mapDatas[i].scarab));
        }
    }
}
