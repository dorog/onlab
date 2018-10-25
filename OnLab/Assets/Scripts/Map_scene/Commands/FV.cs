using UnityEngine;

public class FV : Command
{

    private int FvNumber = 0;
    private StartActions sa;

    public FV(int _PanelSlot, int fvNumber)
    {
        ID = SharedData.realCommandID;
        PanelSlot = _PanelSlot;
        FvNumber = fvNumber;
        if(fvNumber == 1)
        {
            Sprite = Resources.Load<Sprite>(SharedData.fv1Icon);
        }
        else {
            Sprite = Resources.Load<Sprite>(SharedData.fv2Icon);
        }
        sa = StartActions.GetStartActions();
    }

    public override void Effect()
    {
        sa.FvStart(FvNumber);
    }
}
