using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatas{

    public int lastMap { get; set; }
    public List<MapDatas> mapDatas = new List<MapDatas>();

    public GameDatas(int lastMap)
    {
        this.lastMap = lastMap;
    }

    public GameDatas()
    {
        this.lastMap = 1;
    }

    public void AddMapData(MapDatas newMapData)
    {
        mapDatas.Add(newMapData);
    }
}
