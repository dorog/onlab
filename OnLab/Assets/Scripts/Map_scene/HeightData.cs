using System.Collections.Generic;
using UnityEngine;

public class HeightData : MonoBehaviour {

    protected List<GameObject> boxes = new List<GameObject>();

    [SerializeField]
    private int baseHeight;
    [SerializeField]
    private int modelGround;
    [SerializeField]
    private Vector3 quatVector = Vector3.right;
    [SerializeField]
    private float quatFloat = -90;

    public Quaternion GetQuat()
    {
        return Quaternion.AngleAxis(quatFloat, quatVector);
    }

    public int BaseHeight
    {
        get
        {
            return baseHeight;
        }

        set
        {
            baseHeight = value;
        }
    }

    public int ModelGround
    {
        get
        {
            return modelGround;
        }

        set
        {
            modelGround = value;
        }
    }

    public virtual CanGoForward HeightCalculateTo(int fromHeight)
    {
        if((BaseHeight + boxes.Count) <= fromHeight)
        {
            SharedData.fallDistance = (fromHeight - (BaseHeight + boxes.Count)) * SharedData.heightUnit;
            return CanGoForward.Go;
        }
        else if((BaseHeight + boxes.Count)-1 == fromHeight && boxes.Count > 0)
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

    public virtual int HeightCalculateFrom()
    {
        return BaseHeight + boxes.Count;
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
