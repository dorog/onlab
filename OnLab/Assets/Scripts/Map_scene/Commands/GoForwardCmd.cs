using UnityEngine;

public class GoForwardCmd : Command
{
    public GoForwardCmd(int id) : base(id) {
        this.sprite = Resources.Load<Sprite>(Configuration.forwardIcon);
    }

    public override void Effect()
    {
        //character.GetComponent<JoeCommandControl>().GoForward();
        GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>().RightToMove();
    }

    public override void Identity(int i, int aimnumber)
    {
        Debug.Log("forward " +i + " "+aimnumber);
    }
}
