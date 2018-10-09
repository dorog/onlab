using System.Collections.Generic;
using UnityEngine;

public class HighData : MonoBehaviour {

    protected List<GameObject> boxes = new List<GameObject>();
    public int baseHigh;

    public virtual Configuration.CanGoForward HeightCalculateTo(int fromHeight)
    {
        if((baseHigh + boxes.Count) <= fromHeight)
        {
            Configuration.fallDistance = (fromHeight - (baseHigh + boxes.Count)) * Configuration.unit;
            return Configuration.CanGoForward.Go;
        }
        else if((baseHigh + boxes.Count)-1 == fromHeight && boxes.Count > 0)
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

    public virtual bool HeightCalculateToBox(int fromHeight)
    {
        float originFallSpeed = Configuration.fallDistance;
        Configuration.CanGoForward result = HeightCalculateTo(fromHeight);
        Configuration.fallDistance = originFallSpeed;
        if(result == Configuration.CanGoForward.Go)
        {
            return true;
        }
        return false;
    }

    public virtual int HeighCalculateFrom()
    {
        return baseHigh + boxes.Count;
    }

    public virtual int GetBoxCount()
    {
        return boxes.Count;
    }

    public virtual void AddBox(GameObject box)
    {
        boxes.Add(box);
    } 

    public GameObject GetBox(int number)
    {
        return boxes[number];
    }

    public void RemoveBox(int number)
    {
        boxes.RemoveAt(number);
    }

    public void RemoveAllBox()
    {
        boxes.Clear();
    }

    public virtual GameObject GetTopBox()
    {
        if (boxes.Count == 0)
        {
            return null;
        }
        return boxes[boxes.Count - 1];
    }

    public virtual void RemoveTopBox()
    {
        boxes.RemoveAt(boxes.Count - 1);
    }
}
