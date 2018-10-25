using UnityEngine;

public class TrapHighData : HighData
{
    [SerializeField]
    private int HeighCalculateFromNumber = -1;

    public override CanGoForward HeightCalculateTo(int fromHeight)
    {
        if (boxes.Count < BaseHigh)
        {
            if(BaseHigh <= fromHeight)
            {
                SharedData.fallDistance = (fromHeight - boxes.Count) * SharedData.unit;
                return CanGoForward.Go;
            }
            else
            {
                SharedData.fallDistance = 0;
                return CanGoForward.CantGo;
            }
        }
        else
        {
            if(boxes.Count <= fromHeight)
            {
                SharedData.fallDistance = (fromHeight - boxes.Count) * SharedData.unit;
                return CanGoForward.Go;
            }
            else if(boxes.Count-1 <= fromHeight && boxes.Count > 0)
            {
                SharedData.fallDistance = 0;
                return CanGoForward.OneDiff;
            }
            else
            {
                SharedData.fallDistance = 0;
                return CanGoForward.CantGo;
            }
        }
    }

    public override bool HeightCalculateToBox(int fromHeight)
    {
        CanGoForward result = HeightCalculateTo(fromHeight);
        if (result == CanGoForward.Go)
        {
            return true;
        }
        return false;
    }

    public override int HeighCalculateFrom()
    {
        if(boxes.Count < BaseHigh)
        {
            return HeighCalculateFromNumber;
        }
        return boxes.Count;
    }

    public override int GetBoxCount()
    {
        if(boxes.Count <= BaseHigh)
        {
            return 0;
        }
        return boxes.Count - BaseHigh;
    }

    public int GetRealBoxCount()
    {
        return boxes.Count;
    }
}
