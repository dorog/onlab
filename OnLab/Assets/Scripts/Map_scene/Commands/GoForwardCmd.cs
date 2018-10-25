using UnityEngine;

public class GoForwardCmd : CharacterMovingCommand
{
    public GoForwardCmd(int id) : base(id) {
        Sprite = Resources.Load<Sprite>(SharedData.forwardIcon);
    }

    public override void Effect()
    {
        mapGen.RightToMove();
    }
}
