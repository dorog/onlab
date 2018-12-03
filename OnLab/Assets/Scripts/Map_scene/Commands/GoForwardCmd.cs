using UnityEngine;

public class GoForwardCmd : CharacterMovingCommand
{
    public GoForwardCmd(int id) : base(id) {
        Img = Resources.Load<Sprite>(SharedData.forwardIcon);
    }

    public override void Effect()
    {
        base.Effect();
        mapGen.RightToMove();
    }
}
