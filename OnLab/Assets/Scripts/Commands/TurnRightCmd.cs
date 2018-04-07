using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightCmd : Command{

    public TurnRightCmd(int id) : base(id) {
        this.sprite = Resources.Load<Sprite>("Icons/rightarrow");
    }

    public override void Effect()
    {
        character.GetComponent<CharacterActions>().TurnRight();
    }
}
