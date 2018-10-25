using UnityEngine;

public class ActivateCmd : CharacterMovingCommand
{
    public ActivateCmd(int id) : base(id)
    {
        Sprite = Resources.Load<Sprite>(SharedData.activateIcon);
    }

    public override void Effect()
    {
        mapGen.Activate();
    }
}
