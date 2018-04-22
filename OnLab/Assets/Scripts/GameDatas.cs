using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatas{

    public int maxMap { get; set; }
    public List<MapDatas> mapDatas = new List<MapDatas>();

    public GameDatas(int lastMap)
    {
        this.maxMap = lastMap;
    }

    public GameDatas()
    {
        this.maxMap = 1;
    }

    public void AddMapData(MapDatas newMapData)
    {
        mapDatas.Add(newMapData);
    }
}
