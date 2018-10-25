using UnityEngine;
using System.Collections.Generic;

public class DoorHighData : HighData {

    [SerializeField]
    private int openedHeight = 2;

    private List<GameObject> boxesOnRoof = new List<GameObject>();

    private GameObject character;

    public bool Opened { get; set; }

    private void Start()
    {
        GameObject[] gameobjectsWithPlayerTag = GameObject.FindGameObjectsWithTag(SharedData.playerTag);
        if(gameobjectsWithPlayerTag.Length > 1)
        {
            Debug.LogWarning("DoorHighData: There are more than one GameObject with " + SharedData.playerTag + " tag, it may won't work fine");
        }
        else if(gameobjectsWithPlayerTag.Length == 0)
        {
            Debug.LogError("DoorHighData: There is no GameObject with " + SharedData.playerTag + " tag!");
        }

        if(gameobjectsWithPlayerTag.Length >= 1)
        {
            character = gameobjectsWithPlayerTag[0];
        }
    }

    public override CanGoForward HeightCalculateTo(int fromHeight)
    {
        if (Opened)
        {
            if ((fromHeight >= BaseHigh + boxesOnRoof.Count))
            {
                SharedData.fallDistance = (fromHeight - (BaseHigh + boxesOnRoof.Count)) * SharedData.unit;
                return CanGoForward.Go;
            }
            else if ((fromHeight == openedHeight || fromHeight == openedHeight + 1)) {
                SharedData.fallDistance = (fromHeight - openedHeight) * SharedData.unit;
                return CanGoForward.Go;
            }
            else if ((fromHeight >= BaseHigh + boxesOnRoof.Count - 1) && boxesOnRoof.Count > 0)
            {
                SharedData.fallDistance = 0;
                return CanGoForward.OneDiff;
            }
            SharedData.fallDistance = 0;
            return CanGoForward.CantGo;
        }
        else if(fromHeight >= BaseHigh + boxesOnRoof.Count)
        {
            SharedData.fallDistance = (fromHeight - (BaseHigh + boxesOnRoof.Count)) * SharedData.unit;
            return CanGoForward.Go;
        }
        else if(fromHeight >= (BaseHigh + boxesOnRoof.Count - 1) && boxesOnRoof.Count > 0)
        {
            SharedData.fallDistance = 0;
            return CanGoForward.OneDiff;
        }
        SharedData.fallDistance = 0;
        return  CanGoForward.CantGo;
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

    public override void AddBox(GameObject box)
    {
        if(box.transform.position.y > SharedData.hight_0_Ground + SharedData.unit * BaseHigh)
        {
            boxesOnRoof.Add(box);
            return;
        }
        base.AddBox(box);
    }

    public override GameObject GetTopBox()
    {
        if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.unit * BaseHigh)
        {
            return boxesOnRoof[boxesOnRoof.Count - 1];
        }
        return base.GetTopBox();
    }

    public override int GetBoxCount()
    {
        return boxesOnRoof.Count;
    }

    public override void RemoveTopBox()
    {
        if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.unit * BaseHigh)
        {
            boxesOnRoof.RemoveAt(boxesOnRoof.Count - 1);
        }
        base.GetTopBox();
    }

    public override int HeighCalculateFrom()
    {
        return (BaseHigh + boxesOnRoof.Count);
    }
}
