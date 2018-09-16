using UnityEngine;

public class DoorHighData : HighData {

    public int openedHeight = 2;
    public bool opened = false;

    public override int HeightCalculate()
    {
        if (opened)
        {
            return openedHeight;
        }
        return baseHigh;
    }
}
