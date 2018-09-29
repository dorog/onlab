using System.Collections.Generic;
using UnityEngine;

public class HighData : MonoBehaviour {

    public List<GameObject> boxes = new List<GameObject>();
    public int baseHigh;

    public virtual int HeightCalculateTo()
    {
        return baseHigh + boxes.Count;
    }

    public virtual int HeighCalculateFrom()
    {
        return HeightCalculateTo();
    }

    public virtual int RealHeight() {
        return baseHigh + boxes.Count;
    }

    public virtual int GetBoxCount()
    {
        return boxes.Count;
    }
}
