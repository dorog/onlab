using UnityEngine;

public class TurnLeftCmd : Command
{
    public TurnLeftCmd(int id) : base(id) {
        this.sprite = Resources.Load<Sprite>(Configuration.leftIcon);
    }

    public override void Effect()
    {
        //Debug.Log("left" + System.DateTime.Now);
        character.GetComponent<JoeCommandControl>().TurnLeft();   
    }
    public override void Identity(int i, int aimnumber)
    {
        Debug.Log("left " +i+" "+aimnumber);
    }
}
