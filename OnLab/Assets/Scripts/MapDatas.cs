using UnityEngine;

public class MapDatas{

    public int mapScore { get; set; }
    public int scarab { get; set; }

    public bool key { get; set; }
    
    public MapDatas()
    {
        mapScore = 0;
        scarab = 0;
        key = false;
    }

    public MapDatas(int mapScr, int bug, bool key)
    {
        mapScore = mapScr;
        scarab = bug;
        this.key = key;
    }
}
