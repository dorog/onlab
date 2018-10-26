using UnityEngine;
using System.Collections.Generic;

public class LaserGateHighData : HighData {
    
    [SerializeField]
    private int offedHigh = 2;
    private List<GameObject> boxesOnRoof = new List<GameObject>();

    private GameObject character;

    private void Start()
    {
        GameObject[] gameobjectsWithPlayerTag = GameObject.FindGameObjectsWithTag(SharedData.playerTag);
        if (gameobjectsWithPlayerTag.Length > 1)
        {
            Debug.LogWarning("LaserGateHighData: There are more than one GameObject with " + SharedData.playerTag + " tag, it may won't work fine");
        }
        else if (gameobjectsWithPlayerTag.Length == 0)
        {
            Debug.LogError("LaserGateHighData: There is no GameObject with " + SharedData.playerTag + " tag!");
        }

        if (gameobjectsWithPlayerTag.Length >= 1)
        {
            character = gameobjectsWithPlayerTag[0];
        }
    }

    public override CanGoForward HeightCalculateTo(int fromHeight)
    {
        int activeSwitches = transform.GetComponent<LaserGate>().ActiveSwitches;
        if (activeSwitches == 0)
        {
            if(fromHeight == offedHigh || fromHeight == offedHigh+1)
            {
                SharedData.fallDistance = (fromHeight - offedHigh) * SharedData.heightUnit;
                return CanGoForward.Go;
            }
            else if (fromHeight >= BaseHigh + boxesOnRoof.Count){
                SharedData.fallDistance = (fromHeight - (BaseHigh + boxesOnRoof.Count)) * SharedData.heightUnit;
                return CanGoForward.Go;
            }
            else if (fromHeight >= BaseHigh + boxesOnRoof.Count-1 && boxesOnRoof.Count > 0)
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
        else
        {
            if(boxesOnRoof.Count + BaseHigh <= fromHeight)
            {
                SharedData.fallDistance = (fromHeight - (boxesOnRoof.Count + BaseHigh)) * SharedData.heightUnit;
                return CanGoForward.Go;
            }
            else if(boxesOnRoof.Count-1 + BaseHigh <= fromHeight && boxesOnRoof.Count > 0)
            {
                SharedData.fallDistance = 0;
                return CanGoForward.OneDiff;
            }
            SharedData.fallDistance = 0;
            return CanGoForward.CantGo;
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
        int activeSwitches = transform.GetComponent<LaserGate>().ActiveSwitches;
        if (activeSwitches == 0)
        {
            if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHigh)
            {
                return BaseHigh + boxesOnRoof.Count;
            }
            return offedHigh + boxes.Count;
        }
        else
        {
            return (BaseHigh + boxesOnRoof.Count);
        }
    }

    public override void AddBox(GameObject box)
    {
        if (box.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHigh)
        {
            boxesOnRoof.Add(box);
            return;
        }
        base.AddBox(box);
    }

    public override GameObject GetTopBox()
    {
        if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHigh)
        {
            return boxesOnRoof[boxesOnRoof.Count-1];
        }
        return base.GetTopBox();
    }

    public override void RemoveTopBox()
    {
        if (character.transform.position.y > SharedData.hight_0_Ground + SharedData.heightUnit * BaseHigh)
        {
           boxesOnRoof.RemoveAt(boxesOnRoof.Count - 1);
        }
        else
        {
            boxes.RemoveAt(boxes.Count - 1);
        }
    }
}
