using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightCmd : Command{

    public TurnRightCmd(int id) : base(id) {
        this.sprite = Resources.Load<Sprite>(Configuration.rightIcon);
    }

    public override void Effect()
    {
        //Debug.Log("right" + System.DateTime.Now);
        character.GetComponent<JoeCommandControl>().TurnRight();
        
    }

    public override void Identity(int i, int aimnumber)
    {
        Debug.Log("right "+i+" "+aimnumber);
    }
}
