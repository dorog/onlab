using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentGameDatas{

    static public int mapNumber = 1;
    static public int lastMap = 1;
    static public List<MapDatas> mapDatas = new List<MapDatas>();

    static public void CopyTheDatas(GameDatas data)
    {
        mapDatas.Clear();
        lastMap = data.lastMap;
        for(int i=0; i<data.mapDatas.Count; i++)
        {
            mapDatas.Add(new MapDatas(data.mapDatas[i].mapScore, data.mapDatas[i].scarab));
        }
    }
}
