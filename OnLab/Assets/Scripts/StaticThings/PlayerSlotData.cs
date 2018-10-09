using System;
using UnityEngine;

[Serializable]
public class PlayerSlotData {

    public int slotType;
    public int maxMap;
    public int speed;
    public int onLevel;
    public MapResult[] mapResults;
    public int[] levelMapsNumber;
}

[Serializable]
public class MapResult
{
    public MapResult()
    {
        Score = 0;
        ScarabNumber = 0;
        Item = 0;
        ItemType = 1;
    }
    public int Score;
    public int ScarabNumber;
    public int Item;
    public int ItemType;
}
