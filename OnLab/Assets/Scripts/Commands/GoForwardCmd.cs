using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForwardCmd : Command
{
    public GoForwardCmd(int id, string charName) : base(id, charName) {
        this.sprite = Resources.Load<Sprite>("Icons/uparrow");
    }

    public override void Effect()
    {
        character.GetComponent<JoeCommandControl>().GoForward();
    }
}
