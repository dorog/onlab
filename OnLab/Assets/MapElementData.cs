using System.Collections.Generic;
using UnityEngine;

public class MapElementData : MapElementBox
{ 
    [SerializeField]
    private int height;
    [SerializeField]
    private int modelGround;
    [SerializeField]
    private List<GameObject> boxes = new List<GameObject>();

    private int boxOnItCount = 0;

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

    public int Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
        }
    }

    public int BoxOnItCount
    {
        get
        {
            return boxOnItCount;
        }

        set
        {
            boxOnItCount = value;
        }
    }

    public void AddBox(GameObject box)
    {
        boxes.Add(box);
    }

    public GameObject GetTopBox()
    {
        return boxes[boxes.Count - 1];
    }

    public void RemoveLast()
    {
        boxes.RemoveAt(boxes.Count-1);
    }
}
