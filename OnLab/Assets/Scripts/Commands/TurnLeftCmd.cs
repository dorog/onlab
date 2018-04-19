using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftCmd : Command
{
    public TurnLeftCmd(int id, string charName) : base(id, charName) {
        this.sprite = Resources.Load<Sprite>("Icons/leftarrow");
    }

    public override void Effect()
    {
        Debug.Log("left" + System.DateTime.Now);
        character.GetComponent<JoeCommandControl>().TurnLeft();
        
    }
}
