using System;
using UnityEngine;

[Serializable]
public class PlayerSlotData {

    public int slotType;
    public int maxMap;
    public int speed;
    public int onLevel;
    public MapData[] mapResults;
    public int[] levelMapsNumber;
}
