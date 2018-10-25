using System.Collections.Generic;
using UnityEngine;

public class HighData : MonoBehaviour {

    protected List<GameObject> boxes = new List<GameObject>();

    [SerializeField]
    private int baseHigh;

    public int BaseHigh
    {
        get
        {
            return baseHigh;
        }

        set
        {
            baseHigh = value;
        }
    }

    public virtual CanGoForward HeightCalculateTo(int fromHeight)
    {
        if((BaseHigh + boxes.Count) <= fromHeight)
        {
            SharedData.fallDistance = (fromHeight - (BaseHigh + boxes.Count)) * SharedData.unit;
            return CanGoForward.Go;
        }
        else if((BaseHigh + boxes.Count)-1 == fromHeight && boxes.Count > 0)
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

    public virtual bool HeightCalculateToBox(int fromHeight)
    {
        CanGoForward result = HeightCalculateTo(fromHeight);
        if(result == CanGoForward.Go)
        {
            return true;
        }
        return false;
    }

    public virtual int HeighCalculateFrom()
    {
        return BaseHigh + boxes.Count;
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
