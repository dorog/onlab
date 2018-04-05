using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForwardCmd : Command
{

    public GoForwardCmd(int id) : base(id) {
        this.sprite = Resources.Load<Sprite>("Icons/uparrow");
    }
}
