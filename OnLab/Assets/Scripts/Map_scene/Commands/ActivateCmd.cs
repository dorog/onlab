using UnityEngine;

public class ActivateCmd : CharacterMovingCommand
{
    public ActivateCmd(int _PanelSlot) : base(_PanelSlot)
    {
        Img = Resources.Load<Sprite>(SharedData.activateIcon);
    }

    public override void Effect()
    {
        base.Effect();
        mapGen.Activate();
    }
}
