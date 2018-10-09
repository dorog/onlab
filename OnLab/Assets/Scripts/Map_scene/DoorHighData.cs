using UnityEngine;
using System.Collections.Generic;

public class DoorHighData : HighData {

    public int openedHeight = 2;
    public bool opened = false;
    public List<GameObject> boxesOnRoof = new List<GameObject>();

    private GameObject character;

    private void Start()
    {
        character = GameObject.Find(Configuration.characterName);
    }

    public override Configuration.CanGoForward HeightCalculateTo(int fromHeight)
    {
        if (opened)
        {
            if ((fromHeight >= baseHigh + boxesOnRoof.Count))
            {
                Configuration.fallDistance = (fromHeight - (baseHigh + boxesOnRoof.Count)) * Configuration.unit;
                return Configuration.CanGoForward.Go;
            }
            else if ((fromHeight == openedHeight || fromHeight == openedHeight + 1)) {
                Configuration.fallDistance = (fromHeight - openedHeight) * Configuration.unit;
                return Configuration.CanGoForward.Go;
            }
            else if ((fromHeight >= baseHigh + boxesOnRoof.Count - 1) && boxesOnRoof.Count > 0)
            {
                Configuration.fallDistance = 0;
                return Configuration.CanGoForward.OneDiff;
            }
            Configuration.fallDistance = 0;
            return Configuration.CanGoForward.CantGo;
        }
        else if(fromHeight >= baseHigh + boxesOnRoof.Count)
        {
            Configuration.fallDistance = (fromHeight - (baseHigh + boxesOnRoof.Count)) * Configuration.unit;
            return Configuration.CanGoForward.Go;
        }
        else if(fromHeight >= (baseHigh + boxesOnRoof.Count - 1) && boxesOnRoof.Count > 0)
        {
            Configuration.fallDistance = 0;
            return Configuration.CanGoForward.OneDiff;
        }
        Configuration.fallDistance = 0;
        return  Configuration.CanGoForward.CantGo;
    }

    public override bool HeightCalculateToBox(int fromHeight)
    {
        float originFallSpeed = Configuration.fallDistance;
        Configuration.CanGoForward result = HeightCalculateTo(fromHeight);
        Configuration.fallDistance = originFallSpeed;
        if (result == Configuration.CanGoForward.Go)
        {
            return true;
        }
        return false;
    }

    public override void AddBox(GameObject box)
    {
        if(box.transform.position.y > Configuration.hight_0_Ground + Configuration.unit * baseHigh)
        {
            boxesOnRoof.Add(box);
            return;
        }
        base.AddBox(box);
    }

    public override GameObject GetTopBox()
    {
        if (character.transform.position.y > Configuration.hight_0_Ground + Configuration.unit * baseHigh)
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
        if (character.transform.position.y > Configuration.hight_0_Ground + Configuration.unit * baseHigh)
        {
            boxesOnRoof.RemoveAt(boxesOnRoof.Count - 1);
        }
        base.GetTopBox();
    }

    public override int HeighCalculateFrom()
    {
        return (baseHigh + boxesOnRoof.Count);
    }
}
