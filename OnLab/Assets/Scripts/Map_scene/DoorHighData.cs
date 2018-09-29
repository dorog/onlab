using UnityEngine;

public class DoorHighData : HighData {

    public int openedHeight = 2;
    public bool opened = false;

    public override int HeightCalculateTo()
    {
        if (opened)
        {
            return openedHeight;
        }
        return baseHigh;
    }

    public override int RealHeight()
    {
        return HeightCalculateTo();
    }
}
