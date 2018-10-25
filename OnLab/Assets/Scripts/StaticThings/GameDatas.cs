using System.Collections.Generic;

public class GameDatas{

    public int maxMap { get; set; }
    public List<MapDatas> mapDatas = new List<MapDatas>();

    public GameDatas(int lastMap)
    {
        maxMap = lastMap;
    }

    public GameDatas()
    {
        maxMap = 1;
    }

    public void AddMapData(MapDatas newMapData)
    {
        mapDatas.Add(newMapData);
    }
}
