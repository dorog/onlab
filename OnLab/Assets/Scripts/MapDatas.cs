using UnityEngine;

public class MapDatas{

    public int mapScore { get; set; }
    public int scarab { get; set; }

    public bool item { get; set; }
    public int itemType { get; set; }
    
    public MapDatas()
    {
        mapScore = 0;
        scarab = 0;
        item = false;
    }

    public MapDatas(int mapScr, int bug, bool key, int itemType)
    {
        mapScore = mapScr;
        scarab = bug;
        this.item = key;
        this.itemType = itemType;
    }
}
