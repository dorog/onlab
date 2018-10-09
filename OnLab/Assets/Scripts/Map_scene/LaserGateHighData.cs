using UnityEngine;
using System.Collections.Generic;

public class LaserGateHighData : HighData {

    public int offedHigh = 2;
    public List<GameObject> boxesOnRoof = new List<GameObject>();

    private GameObject character;

    private void Start()
    {
        character = GameObject.Find(Configuration.characterName);
    }

    public override Configuration.CanGoForward HeightCalculateTo(int fromHeight)
    {
        int activeSwitches = transform.GetComponent<LaserGate>().activeSwitches;
        if (activeSwitches == 0)
        {
            if(fromHeight == offedHigh || fromHeight == offedHigh+1)
            {
                Configuration.fallDistance = (fromHeight - offedHigh) * Configuration.unit;
                return Configuration.CanGoForward.Go;
            }
            else if (fromHeight >= baseHigh + boxesOnRoof.Count){
                Configuration.fallDistance = (fromHeight - (baseHigh + boxesOnRoof.Count)) * Configuration.unit;
                return Configuration.CanGoForward.Go;
            }
            else if (fromHeight >= baseHigh + boxesOnRoof.Count-1 && boxesOnRoof.Count > 0)
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
        else
        {
            if(boxesOnRoof.Count + baseHigh <= fromHeight)
            {
                Configuration.fallDistance = (fromHeight - (boxesOnRoof.Count + baseHigh)) * Configuration.unit;
                return Configuration.CanGoForward.Go;
            }
            else if(boxesOnRoof.Count-1 + baseHigh <= fromHeight && boxesOnRoof.Count > 0)
            {
                Configuration.fallDistance = 0;
                return Configuration.CanGoForward.OneDiff;
            }
            Configuration.fallDistance = 0;
            return Configuration.CanGoForward.CantGo;
        }
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

    public override int HeighCalculateFrom()
    {
        int activeSwitches = transform.GetComponent<LaserGate>().activeSwitches;
        if (activeSwitches == 0)
        {
            if (character.transform.position.y > Configuration.hight_0_Ground + Configuration.unit * baseHigh)
            {
                return baseHigh + boxesOnRoof.Count;
            }
            return offedHigh + boxes.Count;
        }
        else
        {
            return (baseHigh + boxesOnRoof.Count);
        }
    }

    public override void AddBox(GameObject box)
    {
        if (box.transform.position.y > Configuration.hight_0_Ground + Configuration.unit * baseHigh)
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
            return boxesOnRoof[boxesOnRoof.Count-1];
        }
        return base.GetTopBox();
    }

    public override void RemoveTopBox()
    {
        if (character.transform.position.y > Configuration.hight_0_Ground + Configuration.unit * baseHigh)
        {
           boxesOnRoof.RemoveAt(boxesOnRoof.Count - 1);
        }
        else
        {
            boxes.RemoveAt(boxes.Count - 1);
        }
    }
}
