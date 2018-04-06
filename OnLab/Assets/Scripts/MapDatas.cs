using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDatas{

    public int mapScore { get; set; }
    public int scarab { get; set; }
    
    public MapDatas()
    {
        mapScore = 0;
        scarab = 0;
    }

    public MapDatas(int mapScr, int bug)
    {
        mapScore = mapScr;
        scarab = bug;
    }
}
