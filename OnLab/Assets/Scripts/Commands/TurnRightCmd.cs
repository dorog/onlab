using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightCmd : Command{

    public TurnRightCmd(int id, string charName) : base(id, charName) {
        this.sprite = Resources.Load<Sprite>("Icons/rightarrow");
    }

    public override void Effect()
    {
        Debug.Log("right" + System.DateTime.Now);
        character.GetComponent<JoeCommandControl>().TurnRight();
        
    }
}
