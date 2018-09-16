using UnityEngine;

public class TrapHighData : HighData
{
    public override int HeightCalculate()
    {
        if (boxes.Count < 3)
        {
            return baseHigh;
        }
        else
        {
            return baseHigh + boxes.Count - 2;
        }
    }   
}
