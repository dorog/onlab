using UnityEngine;

public class TurnRightCmd : CharacterMovingCommand
{
    public TurnRightCmd(int id) : base(id) {
        Img = Resources.Load<Sprite>(SharedData.rightIcon);
    }

    public override void Effect()
    {
        base.Effect();
        mapGen.CharacterTurnRight();
    }
}
