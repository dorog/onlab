using UnityEngine;

public class FV : Command
{

    private int FvNumber = 0;

    public FV(int _PanelSlot, int fvNumber)
    {
        Type = SharedData.realCommandID;
        PanelSlot = _PanelSlot;
        FvNumber = fvNumber;
        if(fvNumber == 1)
        {
            Img = Resources.Load<Sprite>(SharedData.fv1Icon);
        }
        else {
            Img = Resources.Load<Sprite>(SharedData.fv2Icon);
        }
        sa = StartActions.GetStartActions();
    }

    public override void Effect()
    {
        sa.FvStart(FvNumber);
    }
}
