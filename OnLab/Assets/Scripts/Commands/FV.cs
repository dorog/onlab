using UnityEngine;

public class FV : Command {

    private int fvNumber = 0;
    private StartActions sa;

    public FV(int id, int fvNumber) : base(id)
    {
        
        this.fvNumber = fvNumber;
        if(fvNumber == 1)
        {
            this.sprite = Resources.Load<Sprite>(Configuration.fv1IconLocation);
        }
        else {
            this.sprite = Resources.Load<Sprite>(Configuration.fv2IconLocation);
        }
        sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();
    }

    public override void Effect()
    {
        sa.fvStart(fvNumber);
    }
}
