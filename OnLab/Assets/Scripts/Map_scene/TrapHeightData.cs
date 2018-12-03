using UnityEngine;

public class TrapHeightData : HeightData
{
    [SerializeField]
    private int HeighCalculateFromNumber = -1;

    public override CanGoForward HeightCalculateTo(int fromHeight)
    {
        if (boxes.Count < BaseHeight)
        {
            if(BaseHeight <= fromHeight)
            {
                SharedData.fallDistance = (fromHeight - boxes.Count) * SharedData.heightUnit;
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
                SharedData.fallDistance = (fromHeight - boxes.Count) * SharedData.heightUnit;
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

    public override int HeightCalculateFrom()
    {
        if(boxes.Count < BaseHeight)
        {
            return HeighCalculateFromNumber;
        }
        return boxes.Count;
    }

    public override int GetBoxCount()
    {
        if(boxes.Count <= BaseHeight)
        {
            return 0;
        }
        return boxes.Count - BaseHeight;
    }

    public int GetRealBoxCount()
    {
        return boxes.Count;
    }
}
