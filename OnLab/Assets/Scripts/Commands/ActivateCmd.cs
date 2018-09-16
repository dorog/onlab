using UnityEngine;

public class ActivateCmd : Command {

    public ActivateCmd(int id) : base(id)
    {
        this.sprite = Resources.Load<Sprite>(Configuration.activateIcon);
    }

    public override void Effect()
    {
        GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>().Activate();
    }

    public override void Identity(int i, int aimnumber)
    {
        Debug.Log("activate " + i + " " + aimnumber);
    }
}
