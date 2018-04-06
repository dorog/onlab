using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftCmd : Command
{
    public TurnLeftCmd(int id) : base(id) {
        this.sprite = Resources.Load<Sprite>("Icons/leftarrow");
    }

    public override void Effect()
    {
        character.GetComponent<CharacterActions>().TurnLeft();
    }
}
