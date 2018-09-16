using UnityEngine;

public class GoBackwardCmd : Command
{

    public GoBackwardCmd(int id) : base(id)
    {
        this.sprite = Resources.Load<Sprite>(Configuration.forwardIcon);
    }

    public override void Effect()
    {
        //character.GetComponent<JoeCommandControl>().GoForward();
        //GameObject.Find(Configuration.mapGeneratorName).GetComponent<MapGenerator>().RightToMove();
        Debug.Log("In progress...");
    }

    public override void Identity(int i, int aimnumber)
    {
        Debug.Log("backward " + i + " " + aimnumber);
    }
}
