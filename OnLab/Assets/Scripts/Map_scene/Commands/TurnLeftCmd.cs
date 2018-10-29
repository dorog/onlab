using UnityEngine;

public class TurnLeftCmd : CharacterMovingCommand
{
    public TurnLeftCmd(int id) : base(id) {
        Sprite = Resources.Load<Sprite>(SharedData.leftIcon);
    }

    public override void Effect()
    {
        base.Effect();
        mapGen.CharacterTurnLeft();
    }
}
