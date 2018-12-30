using UnityEngine;
using System.Collections.Generic;

public class GateHeightData : HeightData
{
    [SerializeField]
    private int openedHeight = 2;

    private List<GameObject> boxesOnRoof = new List<GameObject>();

    private GameObject character;

    public bool Opened { get; set; }

    private void Start()
    {
        GameObject[] gameobjectsWithPlayerTag = GameObject.FindGameObjectsWithTag(SharedData.playerTag);
        if (gameobjectsWithPlayerTag.Length > 1)
        {
            Debug.LogWarning("GateHeightData: There are more than one GameObject with " + SharedData.playerTag + " tag, it may won't work fine");
        }
        else if (gameobjectsWithPlayerTag.Length == 0)
        {
            Debug.LogError("GateHeightData: There is no GameObject with " + SharedData.playerTag + " tag!");
        }

        if (gameobjectsWithPlayerTag.Length >= 1)
        {
            character = gameobjectsWithPlayerTag[0];
        }
    }

    public override CanGoForward HeightCalculateTo(int fromHeight)
    {
        if (Opened)
        {
            if ((fromHeight >= BaseHeight + boxesOnRoof.Count))
            {
                SharedData.fallDistance = (fromHeight - (BaseHeight + boxesOnRoof.Count)) * SharedData.heightUnit;
                return CanGoForward.Go;
            }
            else if ((fromHeight == openedHeight || fromHeight == openedHeight + 1))
            {
                SharedData.fallDistance = (fromHeight - openedHeight) * SharedData.heightUnit;
                return CanGoForward.Go;
            }
            else if ((fromHeight >= BaseHeight + boxesOnRoof.Count - 1) && boxesOnRoof.Count > 0)
            {
                SharedData.fallDistance = 0;
                return CanGoForward.OneDiff;
            }
            SharedData.fallDistance = 0;
            return CanGoForward.CantGo;
        }
        else if (fromHeight >= BaseHeight + boxesOnRoof.Count)
        {
            SharedData.fallDistance = (fromHeight - (BaseHeight + boxesOnRoof.Count)) * SharedData.heightUnit;
            return CanGoForward.Go;
        }
        else if (fromHeight >= (BaseHeight + boxesOnRoof.Count - 1) && boxesOnRoof.Count > 0)
        {
            SharedData.fallDistance = 0;
            return CanGoForward.OneDiff;
        }
        SharedData.fallDistance = 0;
        return CanGoForward.CantGo;
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

    public override void RemoveTopBox()
    {
        if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHeight)
        {
            boxesOnRoof.RemoveAt(boxesOnRoof.Count - 1);
        }
        else
        {
            boxes.RemoveAt(boxes.Count - 1);
        }
    }

    public override GameObject GetTopBox()
    {
        if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHeight)
        {
            return boxesOnRoof[boxesOnRoof.Count - 1];
        }
        return base.GetTopBox();
    }

    public override void AddBox(GameObject box)
    {
        if (box.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHeight)
        {
            boxesOnRoof.Add(box);
            return;
        }
        base.AddBox(box);
    }

    public override int HeightCalculateFrom()
    {
        if (Opened)
        {
            if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHeight)
            {
                return BaseHeight + boxesOnRoof.Count;
            }
            return openedHeight + boxes.Count;
        }
        else
        {
            return (BaseHeight + boxesOnRoof.Count);
        }
    }

    protected virtual void OpenCheck(){}

    public override int GetBoxCount()
    {
        return boxesOnRoof.Count;
    }
}
