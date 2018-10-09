using UnityEngine;

public class TrapHighData : HighData
{
    public int HeighCalculateFromNumber = -1;

    public override Configuration.CanGoForward HeightCalculateTo(int fromHeight)
    {
        if (boxes.Count < baseHigh)
        {
            if(baseHigh <= fromHeight)
            {
                Configuration.fallDistance = (fromHeight - boxes.Count) * Configuration.unit;
                return Configuration.CanGoForward.Go;
            }
            else
            {
                Configuration.fallDistance = 0;
                return Configuration.CanGoForward.CantGo;
            }
        }
        else
        {
            if(boxes.Count <= fromHeight)
            {
                Configuration.fallDistance = (fromHeight - boxes.Count) * Configuration.unit;
                return Configuration.CanGoForward.Go;
            }
            else if(boxes.Count-1 <= fromHeight && boxes.Count > 0)
            {
                Configuration.fallDistance = 0;
                return Configuration.CanGoForward.OneDiff;
            }
            else
            {
                Configuration.fallDistance = 0;
                return Configuration.CanGoForward.CantGo;
            }
        }
    }

    public override bool HeightCalculateToBox(int fromHeight)
    {
        float originFallSpeed = Configuration.fallDistance;
        Configuration.CanGoForward result = HeightCalculateTo(fromHeight);
        Configuration.fallDistance = originFallSpeed;
        if (result == Configuration.CanGoForward.Go)
        {
            return true;
        }
        return false;
    }

    public override int HeighCalculateFrom()
    {
        if(boxes.Count < baseHigh)
        {
            return HeighCalculateFromNumber;
        }
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

    public int GetRealBoxCount()
    {
        return boxes.Count;
    }
}
