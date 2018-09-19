using System;
using UnityEngine;

[Serializable]
public class PlayerSlotData {

    public int slotType;
    public int maxMap;
    public MapResult[] mapResults;
}

[Serializable]
public class MapResult
{
    public MapResult()
    {
        Score = 0;
        ScarabNumber = 0;
        Key = 0;
    }
    public int Score;
    public int ScarabNumber;
    public int Key;
}
