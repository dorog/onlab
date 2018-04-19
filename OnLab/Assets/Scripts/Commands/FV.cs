using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FV : Command {

    private int fvNumber = 0;
    private StartActions sa;

    public FV(int id, string charName, int fvNumber) : base(id, charName)
    {
        
        this.fvNumber = fvNumber;
        if(fvNumber == 1)
        {
            this.sprite = Resources.Load<Sprite>("Icons/FV1");
        }
        else {
            this.sprite = Resources.Load<Sprite>("Icons/FV2");
        }
        sa = GameObject.Find("ActionMenuGO").GetComponent<StartActions>();
    }

    public override void Effect()
    {
        //Debug.Log("effect");
        sa.fvStart(fvNumber);
    }

    /*public override void Identity(int i, int aimnumber)
    {
        Debug.Log("FV "+i+" "+aimnumber);
    }*/
}
