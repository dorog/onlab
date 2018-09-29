using UnityEngine;

public class TrapHighData : HighData
{
    public int HeighCalculateFromNumber = -1;

    public override int HeightCalculateTo()
    {
        if (boxes.Count < baseHigh)
        {
            return baseHigh;
        }
        else
        {
            return boxes.Count;
        }
    }

    public override int HeighCalculateFrom()
    {
        if(boxes.Count < baseHigh)
        {
            return HeighCalculateFromNumber;
        }
        return boxes.Count;
    }

    public override int RealHeight()
    {
        return boxes.Count;
    }

    public override int GetBoxCount()
    {
        if(boxes.Count <= baseHigh)
        {
            return 0;
        }
        return boxes.Count - baseHigh;
    }
}
